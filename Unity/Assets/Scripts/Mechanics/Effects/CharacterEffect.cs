using System;
using System.Threading.Tasks;
using MyRI.Configs.Collectables;
using UnityEngine.Assertions;

namespace MyRI.Mechanics.Effects
{
    public interface ICharacterEffect
    {
        event Action<IBaff> EffectRemovedEvent;
        public void ApplyEffect(IEffectTarget effectTarget);
    }

    public abstract class CharacterEffect<T, C> : ICharacterEffect where T : class, IEffectTarget<C> where C : BuffCollectable
    {
        private bool _applyed;
        public BuffData BuffData { get; }

        public C Config { get; }
        protected T Target { get; private set; }

        protected CharacterEffect(BuffData data)
        {
            BuffData = data;
            Config = (C) data.Config;
        }
        
        
        private async void ApplyEffect(T target)
        {
            if (_applyed)
                return;
            Target = target;
            ApplyEffectInternal();
            _applyed = true;
            await Task.Delay(BuffData.Remaining);
            RemoveEffectInternal();
            SendRemove();
        }
        protected abstract void ApplyEffectInternal();
        public event Action<IBaff> EffectRemovedEvent;

        public void ApplyEffect(IEffectTarget effectTarget)
        {
            var target = effectTarget as T;
            Assert.IsNotNull(target);
            ApplyEffect(target);
        }
        private void SendRemove()
        {
            EffectRemovedEvent?.Invoke(Config);
        }
        protected abstract void RemoveEffectInternal();
    }
}
