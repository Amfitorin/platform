using UnityEngine;

namespace MyRI.Configs.Collectables
{

    public class BuffCollectable : CollectableConfig, IBaff
    {

        [SerializeField]
        private float _time;

        public override CollectableType CollType => CollectableType.Buff;

        public float Time => _time;
    }
}
