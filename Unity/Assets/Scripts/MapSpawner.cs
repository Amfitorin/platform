using System;
using System.Collections.Generic;
using System.Linq;
using MyRI.Components.Character;
using UnityEngine;
using UnityEngine.Serialization;
using CharacterController=MyRI.Mechanics.Controllers.Character.CharacterController;
using Random = System.Random;

namespace MyRI
{
    public class MapSpawner : MonoBehaviour
    {
        [FormerlySerializedAs("DefaultPoint")]
        [SerializeField]
        private Transform _defaultPoint;

        [FormerlySerializedAs("tracker")]
        [FormerlySerializedAs("mover")]
        [SerializeField]
        private PlayerTracker _tracker;

        [SerializeField]
        private PlayerAtacker attacker;

        [FormerlySerializedAs("player")]
        [SerializeField]
        private CharacterViewComponent _player;

        [FormerlySerializedAs("Enemy")]
        [SerializeField]
        private GameObject _enemy;

        [FormerlySerializedAs("starter")]
        [SerializeField]
        private SceneStarter _starter;

        private readonly List<UnityEngine.Tilemaps.Tilemap> _levels = new();
        private CharacterController _characterController;
        private UnityEngine.Tilemaps.Tilemap _current;

        private int _currentMap = int.MaxValue;
        private List<MapSpawnSelector> _maps;

        private int _orientation = 1;
        private Random _random;
        private float _totalWeight;

        public SceneStarter Starter => _starter;

        public List<UnityEngine.Tilemaps.Tilemap> Levels => _levels;

        private void OnEnable()
        {
            _maps = ResourcesManager.Instance.Maps.ToList();
            _maps.Sort((f, s) => -1 * f.Weight.CompareTo(s.Weight));
            _random = RandomUtils.Instance.Random;
            _totalWeight = _maps.Sum(x => x.Weight);
            UpdateMaps();
            _enemy.SetActive(true);
        }

        private void OnDisable()
        {
            foreach (var tilemap in _levels)
            {
                Destroy(tilemap.gameObject);
            }

            if (_player != null)
                Destroy(_player.gameObject);

            _levels.Clear();
            _orientation = 1;
            _currentMap = int.MaxValue;
            _current = null;
            _maps.Clear();
            _maps = null;
            _random = null;
            _totalWeight = 0f;
            if (_enemy != null)
                _enemy.SetActive(false);
            _characterController?.Destroy();
            MapSpawned = null;
        }
        public event Action<UnityEngine.Tilemaps.Tilemap> MapSpawned;

        private void UpdateMaps()
        {
            SpawnMap();
            if (_levels.Count == 1)
            {
                _currentMap = 0;
                SpawnPlayer();
            }

            SpawnMap();
        }

        private void SpawnPlayer()
        {
            var tilemap = _levels.Last().gameObject.GetComponent<Tilemap>();
            var go = Instantiate(ResourcesManager.Instance.Player, tilemap.PlayerSpawnPoint.position,
                Quaternion.identity);
            _tracker.player = go.transform;
            _player = go.GetComponent<CharacterViewComponent>();
            _characterController = new CharacterController(_player, ResourcesManager.Instance.PlayerConfig);
            _player.Spawner = this;
            attacker.player = _player;
        }

        private void SpawnMap()
        {
            var next = _random.NextDouble();

            var lastMapItem = _levels.Count == 0 ? null : _orientation == 1 ? _levels.Last() : _levels.First();
            var position = lastMapItem == null ? Vector2.zero : (Vector2) lastMapItem.gameObject.transform.position;
            foreach (var map in _maps)
            {
                var chance = map.Weight / _totalWeight;
                if (chance <= next)
                {
                    next -= chance;
                    continue;
                }

                var currentPosition = lastMapItem == null
                    ? Vector2.zero
                    : position + _orientation * new Vector2(lastMapItem.size.x, 0);
                var go = Instantiate(map.Map, currentPosition, Quaternion.identity, _defaultPoint);
                var tile = go.GetComponent<UnityEngine.Tilemaps.Tilemap>();
                if (_orientation == 1)
                    _levels.Add(tile);
                else
                {
                    _levels.Insert(0, tile);
                }
                MapSpawned?.Invoke(tile);
                
                break;
            }

            for (int i = 0; i < _levels.Count; i++)
            {
                var tilemap = _levels[i];
                var level = tilemap.GetComponent<Tilemap>();
                level.index = i;
                level.spawner = this;
                if (_current == tilemap)
                    _currentMap = i;
            }
        }

        public void ChangeMap(Tilemap tile)
        {
            _current = tile.tile;
            _currentMap = tile.index;
            if (_orientation == 1 && _levels.Count - _currentMap <= 2 || _orientation == -1 && _currentMap <= 1)
            {
                SpawnMap();
            }
        }
    }
}