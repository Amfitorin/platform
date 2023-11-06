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
        public void ApplyState()
        {
            _mover = new DblJumpMover(_view, _config, Vector2.right);
            var hud = SceneStarter.Instance.HUD;
            hud.BaseMove.SetActive(true);
            hud.JumpEvent += OnJumpEvent;
        }
        public void RemoveState()
        {
            var hud = SceneStarter.Instance.HUD;
            hud.JumpEvent -= OnJumpEvent;
            hud.BaseMove.SetActive(false);
            _mover.Dispose();
        }
        private void OnJumpEvent()
        {
            _mover.Jump();
        }
    }
}
