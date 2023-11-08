using System;
using System.Threading.Tasks;
using MyRI.Configs.Collectables;
using UnityEngine.Assertions;

namespace MyRI.Mechanics.Effects
{
    /// <summary>
    /// character effect
    /// </summary>
    public interface ICharacterEffect
    {
        /// <summary>
        /// event when buff is expired
        /// </summary>
        event Action<IBaff> EffectRemovedEvent;
        
        /// <summary>
        /// apply effect to effect target
        /// </summary>
        public void ApplyEffect(IEffectTarget effectTarget);
    }

    /// <summary>
    /// typed character effect for BuffConfig and EffectTarget
    /// </summary>
    public abstract class CharacterEffect<T, C> : ICharacterEffect where T : class, IEffectTarget<C> where C : BuffCollectable
    {
        /// <summary>
        /// event when buff is expired
        /// </summary>
        public event Action<IBaff> EffectRemovedEvent;
        
        /// <summary>
        /// value is true if effect applyed to target
        /// </summary>
        private bool _applyed;
        
        /// <summary>
        /// Buff data
        /// </summary>
        public BuffData BuffData { get; }

        /// <summary>
        /// Buff config
        /// </summary>
        public C Config { get; }
        
        /// <summary>
        /// buff target
        /// </summary>
        protected T Target { get; private set; }

        protected CharacterEffect(BuffData data)
        {
            BuffData = data;
            Config = (C) data.Config;
        }

        public void ApplyEffect(IEffectTarget effectTarget)
        {
            var target = effectTarget as T;
            Assert.IsNotNull(target);
            ApplyEffect(target);
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
        private void SendRemove()
        {
            EffectRemovedEvent?.Invoke(Config);
        }
        protected abstract void ApplyEffectInternal();
        protected abstract void RemoveEffectInternal();
    }
}
