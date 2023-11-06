using UnityEngine;

namespace MyRI.Configs.Collectables
{
    
    [CreateAssetMenu(menuName = "Configs/Collectables/CarPart")]
    public class CarPartCollectable : CollectableConfig
    {
        public override CollectableType CollType => CollectableType.CarPart;

        [SerializeField]
        private CarPartType _partType;

        [SerializeField]
        private int _maxCount;

        public CarPartType PartType => _partType;

        public int MaxCount => _maxCount;
    }
}
