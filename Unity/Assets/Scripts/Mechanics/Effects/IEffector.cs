using System;
using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    public interface IEffector: IDisposable
    {
        void RegisterTarget<T>(IEffectTarget<T> target) where T : BuffCollectable;
        void RemoveTarget<T>(IEffectTarget<T> target) where T : BuffCollectable;
    }
}
