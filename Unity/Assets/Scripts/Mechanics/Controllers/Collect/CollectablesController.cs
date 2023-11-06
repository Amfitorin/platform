using System;
using System.Collections.Generic;
using System.Linq;
using MyRI.Configs.Collectables;
using MyRI.Mechanics.Effects;

namespace MyRI.Mechanics.Controllers.Collect
{
    public class CollectablesController : ICollectablesController, IBuffNotify
    {
        private readonly MapSpawner _mapSpawner;
        public event Action CarPartGained;
        public event Action<BuffData> BuffGained;

        private readonly List<CollectablePoint> _points = new();
        public Dictionary<CarPartCollectable, int> CarParts { get; } = new();
        public List<BuffData> GainedBuffs { get; } = new();

        public CollectablesController(MapSpawner mapSpawner)
        {
            _mapSpawner = mapSpawner;
            _mapSpawner.MapSpawned += OnMapSpawned;
            TrackMaps();
        }
        private void TrackMaps()
        {

            foreach (var tilemap in _mapSpawner.Levels)
            {
                OnMapSpawned(tilemap);
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
    }
}
