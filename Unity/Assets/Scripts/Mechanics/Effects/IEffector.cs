using System;
using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    /// <summary>
    /// Effector for control effects and effect targets
    /// </summary>
    public interface IEffector : IDisposable
    {
        /// <summary>
        /// register effect target for type
        /// </summary>
        void RegisterTarget<T>(IEffectTarget<T> target) where T : BuffCollectable;
        
        /// <summary>
        /// remove effect target from registered
        /// </summary>
        void RemoveTarget<T>(IEffectTarget<T> target) where T : BuffCollectable;
    }
}
