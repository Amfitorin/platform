using MyRI.Components.Character;
using MyRI.Configs;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    public class FlyState : ICharacterState
    {
        private readonly ICharacterView _characterView;
        private readonly CharacterConfig _config;
        private FlyMover _mover;
        private Vector2 _flyDirection;

        public FlyState(ICharacterView characterView, CharacterConfig config)
        {
            _characterView = characterView;
            _config = config;
            
        }

        public IMover Mover => _mover;
        public void ApplyState(Vector2 direction, float speed)
        {
            _mover = new FlyMover(_characterView, _config, direction, speed);
            var hud = SceneStarter.Instance.HUD;
            hud.FlyMove.SetActive(true);
            hud.FlyUp.OnUpEvent += OnFlyBtnUpEvent;
            hud.FlyUp.OnDownEvent += OnFlyUpDownEvent;
            hud.FlyDown.OnUpEvent += OnFlyBtnUpEvent;
            hud.FlyDown.OnDownEvent += OnFlyDownDownEvent;
            _characterView.DisableGravity(true);
        }

        public void RemoveState()
        {
            var hud = SceneStarter.Instance.HUD;
            hud.FlyMove.SetActive(false);
            hud.FlyUp.OnUpEvent -= OnFlyBtnUpEvent;
            hud.FlyUp.OnDownEvent -= OnFlyUpDownEvent;
            hud.FlyDown.OnUpEvent -= OnFlyBtnUpEvent;
            hud.FlyDown.OnDownEvent -= OnFlyDownDownEvent;
            _mover.Dispose();
        }

        private void OnFlyDownDownEvent()
        {
            _mover.ApplyFlyDirection(Vector2.down);
        }
        private void OnFlyBtnUpEvent()
        {
            _mover.ApplyFlyDirection(Vector2.zero);
        }
        private void OnFlyUpDownEvent()
        {
            _mover.ApplyFlyDirection(Vector2.up);
        }
    }
}
