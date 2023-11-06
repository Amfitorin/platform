using UnityEngine;

namespace MyRI.Configs.Collectables
{
    [CreateAssetMenu(menuName = "Configs/Collectables/SpeedBuff")]
    public class SpeedBuff : BuffCollectable
    {
        [SerializeField]
        private float _staticSpeed;

        public float StaticSpeed => _staticSpeed;
    }
}
