using MyRI.Components.Character;
using MyRI.Configs;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    
    /// <summary>
    /// Fly character state. Working after collect fly buff. Change mover to height controll
    /// </summary>
    public class FlyState : ICharacterState
    {
        /// <summary>
        /// Character view need for controll postition from mover
        /// </summary>
        private readonly ICharacterView _characterView;
        
        /// <summary>
        /// Character configuration settings
        /// </summary>
        private readonly CharacterConfig _config;
        
        /// <summary>
        /// character fly direction changed, when player press and hold height button
        /// </summary>
        private Vector2 _flyDirection;
        
        /// <summary>
        /// Mover controll character position
        /// </summary>
        private FlyMover _mover;

        public IMover Mover => _mover;

        public FlyState(ICharacterView characterView, CharacterConfig config)
        {
            _characterView = characterView;
            _config = config;

        }
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
        private void OnFlyBtnUpEvent()
        {
            _mover.ApplyFlyDirection(Vector2.zero);
        }

        private void OnFlyDownDownEvent()
        {
            _mover.ApplyFlyDirection(Vector2.down);
        }
        private void OnFlyUpDownEvent()
        {
            _mover.ApplyFlyDirection(Vector2.up);
        }
    }
}
