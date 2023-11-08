using System.Collections;
using MyRI.Components.Character;
using MyRI.Configs.Collectables;
using UnityEngine;

namespace MyRI
{
    /// <summary>
    /// car state component
    /// </summary>
    public class PlayerCAr : MonoBehaviour
    {
        public CharacterViewComponent player;
        public Transform _gun;

        public float bulletForce;

        public Vector2 flyVec = new(-1, 0.88f);

        public void StartAttack(CarGun config)
        {
            StartCoroutine(PlayBullet(config));
        }

        private IEnumerator PlayBullet(CarGun config)
        {
            if (config == null)
                yield break;
            while (player.Started)
            {
                var go = Instantiate(ResourcesManager.Instance.PlayerBullet, _gun);
                var bullet = go.GetComponent<Bullet>();
                bullet.SpriteRenderer.sprite = config.Icon;
                bullet.Rig2D.gravityScale = 0f;
                yield return new WaitForSeconds(config.Precast);
                bullet.Rig2D.gravityScale = 1f;
                bullet.SetDamage(config.Damage);
                bullet.transform.SetParent(null);
                bullet.Rig2D.AddForce(flyVec.normalized * bulletForce, ForceMode2D.Impulse);
                yield return new WaitForSeconds(config.Cooldown);
            }
        }
    }
}
