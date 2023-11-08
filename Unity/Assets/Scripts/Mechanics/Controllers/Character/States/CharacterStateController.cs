using System;
using System.Threading.Tasks;
using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Configs.Collectables;
using MyRI.Mechanics.Controllers.Collect;
using MyRI.Mechanics.Effects;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    /// <summary>
    /// Check character conditions and change character state
    /// </summary>
    public class CharacterStateController : IDisposable
    {
        /// <summary>
        /// buff notifier need for check character state(current check for fly state)
        /// </summary>
        private readonly IBuffNotify _buffs;
        
        /// <summary>
        /// character controller for states check
        /// </summary>
        private readonly ICharacterController _character;
        
        /// <summary>
        /// Collectables controller for check car state (current time not working)
        /// </summary>
        private readonly ICollectablesController _collectables;
        
        /// <summary>
        /// Base character state without buffs and states
        /// </summary>
        private readonly ICharacterState _baseState;
        
        /// <summary>
        /// Car character state(attack boss and move left)
        /// </summary>
        private ICharacterState _carState;
        
        /// <summary>
        /// Current attached character state
        /// </summary>
        private ICharacterState _currentState;
        
        /// <summary>
        /// Current move direction, when collect car parts move right, after move left
        /// </summary>
        private readonly Vector2 _direction;
        
        /// <summary>
        /// fly character state, applyed, when character collect fly buff
        /// </summary>
        private readonly ICharacterState _flyState;
        
        /// <summary>
        /// previous character state, applyed after timed states
        /// </summary>
        private ICharacterState _prevState;

        public CharacterStateController(ICharacterController character, ICharacterView view, CharacterConfig config, ICollectablesController collectables, IBuffNotify buffs)
        {
            _character = character;
            _buffs = buffs;
            _collectables = collectables;
            _baseState = new MoveState(view, config);
            _carState = new CarState(character);
            _flyState = new FlyState(view, config);
            _collectables.CarPartGained += OnCarPartGained;
            _buffs.BuffGained += OnBuffGained;
            _direction = Vector2.right;
            ApplyState(_baseState);
        }

        public void Dispose()
        {
            _collectables.CarPartGained -= OnCarPartGained;
            _buffs.BuffGained -= OnBuffGained;
            _currentState.RemoveState();
            _currentState = null;
        }
        private void ApplyState(ICharacterState state)
        {
            if (state == null)
                return;
            _prevState = _currentState;
            var speed = _currentState?.Mover.CurrentSpeed ?? 0f;
            _currentState?.RemoveState();
            _currentState = state;
            _character.SetState(_currentState);
            _currentState.ApplyState(_direction, speed);

        }
        private async void OnBuffGained(BuffData buff)
        {
            if (buff.Config is not FlyBuff)
            {
                return;
            }
            ApplyState(_flyState);
            await Task.Delay(buff.Remaining);
            ApplyState(_prevState);
        }
        private void OnCarPartGained()
        {
            // _direction = Vector2.left;
        }
    }
}
