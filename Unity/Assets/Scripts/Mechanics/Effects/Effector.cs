using System;
using System.Collections.Generic;
using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    public class Effector : IEffector
    {
        private readonly IBuffNotify _buffNotify;
        private readonly Dictionary<Type, IEffectTarget> _targets = new();

        public Effector(IBuffNotify buffNotify)
        {
            _buffNotify = buffNotify;
            _buffNotify.BuffGained += OnBuffGained;
        }
        private void OnBuffGained(BuffData buff)
        {
            if (!_targets.TryGetValue(buff.Config.GetType(), out var target))
            {
                return;
            }

            var effect = EffectFactory.GetEffect(buff);
            effect.ApplyEffect(target);
        }

        public void RegisterTarget<T>(IEffectTarget<T> target) where T : BuffCollectable
        {
            var type = typeof(T);
            if (_targets.TryGetValue(type, out _))
            {
                return;
            }
            _targets.Add(type, target);

        }
        public void RemoveTarget<T>(IEffectTarget<T> target) where T : BuffCollectable
        {
            var type = typeof(T);
            _targets.Remove(type);
        }
        public void Dispose()
        {
            _buffNotify.BuffGained -= OnBuffGained;
        }
    }
}
