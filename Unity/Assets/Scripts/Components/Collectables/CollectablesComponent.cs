using System;
using System.Linq;
using MyRI.Configs.Collectables;
using MyRI.Mechanics.Effects;
using Unity.Mathematics;
using UnityEngine;

namespace MyRI.Components.Collectables
{
    /// <summary>
    /// Collectables view on main hud interface
    /// </summary>
    public class CollectablesComponent : MonoBehaviour, ICollectableView
    {
        /// <summary>
        /// Car part huds elements
        /// </summary>
        [SerializeField]
        private CarPatHudItem[] _partHuds;

        /// <summary>
        /// Transform for use as spawn parent for buff items
        /// </summary>
        [SerializeField]
        private Transform _buffParent;

        /// <summary>
        /// Prefab for spawn as buff item
        /// </summary>
        [SerializeField]
        private GameObject _buff;

        public CarPatHudItem[] PartHuds => _partHuds;

        public Transform BuffParent => _buffParent;

        public void ShowCarPart(CarPartType part, int count)
        {
            var partHud = _partHuds.FirstOrDefault(x => x.CarPart == part);
            if (partHud == null)
                return;
            for (var i = 0; i < partHud.Objects.Length; i++)
            {
                partHud.Objects[i].SetActive(i < count);
            }
        }

        public void ApplyBuff(BuffData buff)
        {
            var buffItem = Instantiate(_buff, _buff.transform.position, quaternion.identity, _buffParent);
            var component = buffItem.GetComponent<BuffItem>();
            component.gameObject.SetActive(true);
            component.SetData(buff);
        }
    }

    [Serializable]
    public class CarPatHudItem
    {
        [SerializeField]
        private CarPartType _carPart;

        [SerializeField]
        private GameObject[] _objects;

        public CarPartType CarPart => _carPart;

        public GameObject[] Objects => _objects;
    }
}
