using MyRI.Components.Character;
using MyRI.Configs;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    public class FlyState : ICharacterState
    {
        private readonly CharacterConfig _config;
        private readonly Vector2 _direction;
        private FlyMover _mover;
        public FlyState(ICharacterView characterView, CharacterConfig config, Vector2 direction)
        {
            _config = config;
            _direction = direction;

        }

        public IMover Mover => _mover;
        public void ApplyState()
        {
            _mover = new FlyMover();
            var hud = SceneStarter.Instance.HUD;
            hud.FlyMove.SetActive(true);
            hud.UpEvent += OnUpEvent;
            hud.DownEvent += OnDownEvent;
        }
        private void OnDownEvent()
        {
        }
        private void OnUpEvent()
        {
        }
        public void RemoveState()
        {
            var hud = SceneStarter.Instance.HUD;
            hud.FlyMove.SetActive(false);
            hud.UpEvent += OnUpEvent;
            hud.DownEvent += OnDownEvent;
            _mover.Dispose();
        }
    }
}
