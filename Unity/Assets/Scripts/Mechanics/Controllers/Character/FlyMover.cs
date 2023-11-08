using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Mechanics.LoopCycle;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character
{
    public class FlyMover : IMover, IUpdateListener
    {
        private readonly CharacterConfig _config;
        private readonly float _minSpeed;
        private readonly float _maxSpeed;
        private readonly Vector2 _mainDirection;
        private float _moveSpeed;
        private float _maxSpeedModifier;
        private Vector2 _flyDirection;

        public FlyMover(ICharacterView characterView, CharacterConfig config, Vector2 direction, float speed)
        {
            CharacterView = characterView;
            _config = config;
            _minSpeed = -config.MaxSpeed;
            _maxSpeed = config.MaxSpeed;
            _mainDirection = direction;
            _moveSpeed = speed;
            SceneStarter.Instance.UpdateProvider.RegisterUpdateListener(this);
        }
        private ICharacterView CharacterView { get; }

        public void Dispose()
        {
            var sceneStarter = SceneStarter.Instance;
            if (sceneStarter == null)
                return;
            sceneStarter.UpdateProvider.RemoveUpdateListener(this);
        }

        public float CurrentSpeed => _moveSpeed;
        public void ApplySpeedModifier(float maxSpeed)
        {
            _maxSpeedModifier += maxSpeed;
        }

        private float NormalizeSpeed()
        {
            if (CharacterView.Collided)
                return -1;

            return Mathf.Clamp(_moveSpeed + _config.Acceleration, _minSpeed + _maxSpeedModifier, _maxSpeed + _maxSpeedModifier);
        }
        public void Update()
        {
            _moveSpeed = NormalizeSpeed();
            CharacterView.UpdateCollides(_mainDirection);
            
            if (CharacterView.Collided)
            {
                CharacterView.Collide(_mainDirection);
                _moveSpeed = 0;
            }
            
            var characterPosition = CharacterView.Position;
            characterPosition += (_moveSpeed * _mainDirection + _config.FlyHeightSpeed * _flyDirection) * Time.deltaTime;
            
            CharacterView.ApplyPosition(characterPosition);
        }
        public void ApplyFlyDirection(Vector2 direction)
        {
            _flyDirection = direction;
        }
    }
}
