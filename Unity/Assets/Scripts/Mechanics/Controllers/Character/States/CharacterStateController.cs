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
    public class CharacterStateController : IDisposable
    {
        private ICharacterState _baseState;
        private ICharacterState _carState;
        private ICharacterState _flyState;
        private ICharacterState _prevState;
        private ICharacterState _currentState;
        private readonly ICharacterController _character;
        private readonly IBuffNotify _buffs;
        private readonly ICollectablesController _collectables;

        public CharacterStateController(ICharacterController character, ICharacterView view, CharacterConfig config, ICollectablesController collectables, IBuffNotify buffs)
        {
            _character = character;
            _buffs = buffs;
            _collectables = collectables;
            _baseState = new MoveState(character, view, config);
            _carState = new CarState(character);
            _flyState = new FlyState(view, config, Vector2.right);
            _collectables.CarPartGained += OnCarPartGained;
            _buffs.BuffGained += OnBuffGained;
            ApplyState(_baseState);
        }
        private void ApplyState(ICharacterState state)
        {
            if (state == null)
                return;
            _prevState = _currentState;
            _currentState?.RemoveState();
            _currentState = state;
            _currentState.ApplyState();

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
            
        }


        public void Dispose()
        {
            _collectables.CarPartGained -= OnCarPartGained;
            _buffs.BuffGained -= OnBuffGained;
            _currentState.RemoveState();
            _currentState = null;
        }
    }
}
