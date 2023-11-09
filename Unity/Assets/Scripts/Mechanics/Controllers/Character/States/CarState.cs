using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Mechanics.Controllers.Collect;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    /// <summary>
    /// Character car state, started when character collect all part items
    /// </summary>
    public class CarState : ICharacterState
    {
        private readonly ICharacterView _characterView;
        private readonly CharacterConfig _config;
        private readonly ICollectablesController _collectables;
        private JumpMover _mover;

        /// <summary>
        /// Mover in current state 
        /// </summary>
        public IMover Mover => _mover;
        public CarState(ICharacterView characterView, CharacterConfig config, ICollectablesController collectables)
        {
            _characterView = characterView;
            _config = config;
            _collectables = collectables;

        }


        /// <summary>
        /// Apply character state
        /// </summary>
        /// <param name="direction">Character move direction </param>
        /// <param name="speed">Character move speed </param>
        public void ApplyState(Vector2 direction, float speed)
        {
            _mover = new JumpMover(_characterView, _config, direction, speed);
            var hud = SceneStarter.Instance.HUD;
            hud.BaseMove.SetActive(true);
            hud.JumpButton.OnClickEvent += OnPointerClick;
            _characterView.DisableGravity(false);
            _characterView.ToCar(_collectables.GunConfig);
        }
        private void OnPointerClick()
        {
            _mover.Jump();
        }
        /// <summary>
        /// Remove character state
        /// </summary>
        public void RemoveState()
        {
            var hud = SceneStarter.Instance.HUD;
            hud.BaseMove.SetActive(false);
            hud.JumpButton.OnClickEvent -= OnPointerClick;
        }
    }
}
