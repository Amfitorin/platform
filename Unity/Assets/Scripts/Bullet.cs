using System.Threading.Tasks;
using DG.Tweening;
using MyRI.Components.Character;
using UnityEngine;
using UnityEngine.Serialization;

namespace MyRI
{
    public class Bullet : MonoBehaviour
    {

        [FormerlySerializedAs("SpriteRenderer")]
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [FormerlySerializedAs("rig2D")]
        [SerializeField]
        private Rigidbody2D _rig2D;

        [FormerlySerializedAs("anim")]
        [SerializeField]
        private GameObject _anim;

        private float _damage;

        private bool _destroyed;
        private PlayerAtacker _enemy;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public Rigidbody2D Rig2D => _rig2D;

        private void OnEnable()
        {
            _enemy = FindObjectOfType<PlayerAtacker>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_destroyed)
                return;
            var player = other.gameObject.GetComponentInParent<CharacterViewComponent>();
            if (player != null)
            {
                player.ApplyDamage(_damage);
            }

            if (gameObject.layer == 17)
            {
                if (other.gameObject.layer == 9)
                    return;

                _enemy.ApplyDamage(_damage);
            }

            _destroyed = true;
            ApplyDamage();
        }

        private async void ApplyDamage()
        {
            _anim.SetActive(true);
            _spriteRenderer.DOFade(0, 0.12f);
            await Task.Delay(250);
            Destroy(gameObject);
        }
        public void SetDamage(float damage)
        {
            _damage = damage;
        }
    }
}
