using System;
using System.Collections.Generic;
using System.Linq;
using MyRI.Configs.Collectables;
using MyRI.Mechanics.Effects;

namespace MyRI.Mechanics.Controllers.Collect
{
    
    /// <summary>
    /// Controller for collectables elements 
    /// </summary>
    public class CollectablesController : ICollectablesController, IBuffNotify
    {
        
        /// <summary>
        /// event invoked when character collect buff item
        /// </summary>
        public event Action<BuffData> BuffGained;
        
        /// <summary>
        ///  event invoked when character collect car part item
        /// </summary>
        public event Action CarPartGained;
        
        /// <summary>
        /// map spawner need for controll spawn new map levels
        /// </summary>
        private readonly MapSpawner _mapSpawner;

        /// <summary>
        /// collectable points on map subscribed to collect event
        /// </summary>
        private readonly List<CollectablePoint> _points = new();
        
        /// <summary>
        /// all collected car parts
        /// </summary>
        public Dictionary<CarPartCollectable, int> CarParts { get; } = new();
        
        /// <summary>
        /// current collected and not expired buffs
        /// </summary>
        public List<BuffData> GainedBuffs { get; } = new();

        public CollectablesController(MapSpawner mapSpawner)
        {
            _mapSpawner = mapSpawner;
            _mapSpawner.MapSpawned += OnMapSpawned;
            TrackMaps();
        }

        public void Dispose()
        {
            _mapSpawner.MapSpawned -= OnMapSpawned;
            foreach (var point in _points)
            {
                point.CollectableTaken -= OnCollectableTaken;
            }
            _points.Clear();
            CarParts.Clear();
        }

        private void ApplyBuff(BuffCollectable buff)
        {
            var buffData = new BuffData(buff);
            SceneStarter.Instance.HUD.Collectables.ApplyBuff(buffData);
            BuffGained?.Invoke(buffData);
        }

        private void ApplyCarPart(CarPartCollectable carPart)
        {
            if (!CarParts.TryGetValue(carPart, out var count))
            {
                count = 1;
                CarParts.Add(carPart, count);
            }
            else if (count >= carPart.MaxCount)
            {
                return;
            }
            else
            {
                CarParts[carPart] = ++count;
            }

            CarPartGained?.Invoke();
            SceneStarter.Instance.HUD.Collectables.ShowCarPart(carPart.PartType, count);
        }

        private void OnCollectableTaken(CollectablePoint point)
        {
            switch (point.Config)
            {
                case CarPartCollectable carPart:
                    ApplyCarPart(carPart);
                    break;
                case BuffCollectable buff:
                    ApplyBuff(buff);
                    break;
            }
        }
        private void OnMapSpawned(UnityEngine.Tilemaps.Tilemap tile)
        {
            var points = tile.gameObject.GetComponentsInChildren(typeof(CollectablePoint)).Where(x => x != null).Select(x => (CollectablePoint) x).ToArray();
            foreach (var point in points)
            {
                point.CollectableTaken += OnCollectableTaken;
                _points.Add(point);
            }
        }
        private void TrackMaps()
        {

            foreach (var tilemap in _mapSpawner.Levels)
            {
                OnMapSpawned(tilemap);
            }
        }
    }
}
