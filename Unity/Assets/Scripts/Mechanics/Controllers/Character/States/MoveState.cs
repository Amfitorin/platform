using MyRI.Components.Character;
using MyRI.Configs;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    /// <summary>
    /// Character move state working without buffs
    /// </summary>
    public class MoveState : ICharacterState
    {
        /// <summary>
        /// Character configuration settings
        /// </summary>
        private readonly CharacterConfig _config;
        
        /// <summary>
        /// Character view need for controll postition from mover
        /// </summary>
        private readonly ICharacterView _view;
        
        /// <summary>
        /// mover with double jump
        /// </summary>
        private DblJumpMover _mover;

        public IMover Mover => _mover;
        public MoveState(ICharacterView view, CharacterConfig config)
        {
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
