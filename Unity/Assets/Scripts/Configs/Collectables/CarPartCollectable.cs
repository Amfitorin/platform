using UnityEngine;

namespace MyRI.Configs.Collectables
{

    [CreateAssetMenu(menuName = "Configs/Collectables/CarPart")]
    public class CarPartCollectable : CollectableConfig
    {

        [SerializeField]
        private CarPartType _partType;

        [SerializeField]
        private int _maxCount;

        public override CollectableType CollType => CollectableType.CarPart;

        public CarPartType PartType => _partType;

        public int MaxCount => _maxCount;
    }
}
