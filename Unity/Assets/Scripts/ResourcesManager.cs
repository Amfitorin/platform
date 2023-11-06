using System;
using MyRI.Configs;
using MyRI.Configs.Collectables;
using UnityEngine;
using UnityEngine.Serialization;

namespace MyRI
{
    [CreateAssetMenu(menuName = "Configs/ResourcesManager")]
    public class ResourcesManager : ScriptableObject
    {
        [FormerlySerializedAs("Player")]
        [SerializeField]
        private GameObject _player;
        [FormerlySerializedAs("Bullet")]
        [SerializeField]
        private GameObject _bullet;
        [FormerlySerializedAs("PlayerBullet")]
        [SerializeField]
        private GameObject _playerBullet;
        [FormerlySerializedAs("PlayerConfig")]
        [SerializeField]
        private CharacterConfig _playerConfig;
        [FormerlySerializedAs("Maps")]
        [SerializeField]
        private MapSpawnSelector[] _maps;
        [SerializeField]
        private CarPartCounts[] _partCounts;
        
        private const string PATH = "Configs/ResourcesManager";

        private static ResourcesManager _instance;

        public static ResourcesManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Resources.Load<ResourcesManager>(PATH);
                return _instance;
            }
        }

        public GameObject Player => _player;

        public GameObject Bullet => _bullet;

        public GameObject PlayerBullet => _playerBullet;

        public CharacterConfig PlayerConfig => _playerConfig;

        public MapSpawnSelector[] Maps => _maps;

        public CarPartCounts[] PartCounts => _partCounts;

        public void Release()
        {
            _instance = null;
        }
    }

    [Serializable]
    public struct MapSpawnSelector
    {
        [FormerlySerializedAs("Map")]
        [SerializeField]
        private GameObject _map;
        [FormerlySerializedAs("weight")]
        [SerializeField]
        private float _weight;

        public GameObject Map => _map;

        public float Weight => _weight;
    }

    [Serializable]
    public struct CarPartCounts
    {
        [SerializeField]
        private CarPartType _part;
        [SerializeField]
        private int _count;

        public CarPartType Part => _part;

        public int Count => _count;
    }
}
