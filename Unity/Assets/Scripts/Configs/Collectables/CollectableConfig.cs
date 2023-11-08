using UnityEngine;

namespace MyRI.Configs.Collectables
{
    public abstract class CollectableConfig : ScriptableObject
    {
        [SerializeField]
        private Sprite _icon;

        public virtual CollectableType CollType => CollectableType.None;

        public Sprite Icon => _icon;
    }
}
