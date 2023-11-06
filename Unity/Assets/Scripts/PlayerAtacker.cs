using System.Collections;
using MyRI.Components.Character;
using MyRI.UIScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace MyRI
{
    public class PlayerAtacker : MonoBehaviour
    {
        [FormerlySerializedAs("Health")]
        [SerializeField]
        private float _health;
        [FormerlySerializedAs("MaxAttackCooldown")]
        [SerializeField]
        private float _maxAttackCooldown;
        [FormerlySerializedAs("MinAttackCooldown")]
        [SerializeField]
        private float _minAttackCooldown;
        [FormerlySerializedAs("cooldownChange")]
        [SerializeField]
        private float _cooldownChange = 0.3f;
        [FormerlySerializedAs("bulletSpeed")]
        [SerializeField]
        private float _bulletSpeed;
        [FormerlySerializedAs("Damage")]
        [SerializeField]
        private float _damage;
        [FormerlySerializedAs("precast")]
        [SerializeField]
        private float _precast = 3f;
        [FormerlySerializedAs("animator")]
        [SerializeField]
        private Animator _animator;
        [FormerlySerializedAs("progr")]
        [SerializeField]
        private ProgressBar _progress;


        public CharacterViewComponent player;
        public Transform BulletSlot;
        private float _currentCooldown;
        private float _currentHealth;

        private void Awake()
        {
            _progress.SetMax(_health);
        }

        private void Update()
        {
            if (player == null)
                return;
            var position = transform.position;
            position.y = player.transform.position.y;
            transform.position = position;
        }

        private void OnEnable()
        {
            _currentHealth = _health;
            _currentCooldown = _maxAttackCooldown;
            StartCoroutine(Attack());
        }

        public IEnumerator Attack()
        {
            if (player == null || !player.Started)
                yield return null;
            while (_currentHealth > 0)
            {
                yield return new WaitForSeconds(_currentCooldown);
                if (!player.Started)
                    yield break;
                StartCoroutine(SpawnBullet());
                _currentCooldown = Mathf.Clamp(_currentCooldown - _cooldownChange, _minAttackCooldown, _maxAttackCooldown);
            }
        }

        private IEnumerator SpawnBullet()
        {
            var go = Instantiate(ResourcesManager.Instance.Bullet, BulletSlot);
            var bullet = go.GetComponent<Bullet>();
            bullet.SetDamage(_damage);
            var collider = bullet.GetComponent<Collider2D>();
            collider.enabled = false;
            yield return new WaitForSeconds(_precast);
            go.transform.SetParent(null);
            collider.enabled = true;
            var vec = player.transform.position - go.transform.position;
            while (go != null && (go.transform.position - BulletSlot.position).magnitude < 100)
            {
                var position = go.transform.position;
                position += vec * _bulletSpeed * Time.deltaTime;
                go.transform.position = position;
                yield return null;
            }

            if (go != null)
                Destroy(go);
        }

        public void ApplyDamage(float damage)
        {
            _currentHealth -= damage;
            _progress.ApplyDamage(damage);
            if (_currentHealth <= 0)
            {
                _animator.SetTrigger("DEATH");
                player.Win();
            }
        }
    }
}