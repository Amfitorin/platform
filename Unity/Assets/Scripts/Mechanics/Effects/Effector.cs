using System;
using System.Collections.Generic;
using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    /// <summary>
    /// Controller for effect and effect targets
    /// </summary>
    public class Effector : IEffector
    {
        /// <summary>
        /// Notifier for buff collectables taken
        /// </summary>
        private readonly IBuffNotify _buffNotify;
        
        /// <summary>
        /// registered effect targets for buff types
        /// </summary>
        private readonly Dictionary<Type, IEffectTarget> _targets = new();

        public Effector(IBuffNotify buffNotify)
        {
            _buffNotify = buffNotify;
            _buffNotify.BuffGained += OnBuffGained;
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
        private void OnBuffGained(BuffData buff)
        {
            if (!_targets.TryGetValue(buff.Config.GetType(), out var target))
            {
                return;
            }

            var effect = EffectFactory.GetEffect(buff);
            effect.ApplyEffect(target);
        }
    }
}
