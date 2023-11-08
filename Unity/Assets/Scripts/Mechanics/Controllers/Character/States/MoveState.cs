using MyRI.Components.Character;
using MyRI.Configs;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    public class MoveState : ICharacterState
    {
        private readonly ICharacterController _character;
        private readonly CharacterConfig _config;
        private readonly ICharacterView _view;
        private DblJumpMover _mover;

        public IMover Mover => _mover;
        public MoveState(ICharacterController character, ICharacterView view, CharacterConfig config)
        {
            _character = character;
            _view = view;
            _config = config;
            
        }
        public void ApplyState(Vector2 direction, float speed)
        {
            _mover = new DblJumpMover(_view, _config, direction, speed);
            var hud = SceneStarter.Instance.HUD;
            hud.BaseMove.SetActive(true);
            hud.JumpButton.OnClickEvent += OnJumpEvent;
            _view.DisableGravity(false);
        }
        public void RemoveState()
        {
            _mover.Dispose();
            var sceneStarter = SceneStarter.Instance;
            if (sceneStarter == null)
                return;
            var hud = sceneStarter.HUD;
            hud.JumpButton.OnClickEvent -= OnJumpEvent;
            hud.BaseMove.SetActive(false);
        }
        private void OnJumpEvent()
        {
            _mover.Jump();
        }
    }
}
