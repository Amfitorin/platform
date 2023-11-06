using UnityEngine;

namespace MyRI.Configs.Collectables
{
    
    public class BuffCollectable : CollectableConfig, IBaff
    {
        public override CollectableType CollType => CollectableType.Buff;

        [SerializeField]
        private float _time;

        public float Time => _time;
    }
}
