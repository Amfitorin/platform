using UnityEngine;

namespace MyRI.Configs.Collectables
{

    [CreateAssetMenu(menuName = "Configs/Collectables/CarGun")]
    public class CarGun : CarPartCollectable
    {
        [SerializeField]
        private int _damage;

        [SerializeField]
        private float _precast;

        [SerializeField]
        private float _cooldown;

        public int Damage => _damage;

        public float Precast => _precast;

        public float Cooldown => _cooldown;
    }
}
