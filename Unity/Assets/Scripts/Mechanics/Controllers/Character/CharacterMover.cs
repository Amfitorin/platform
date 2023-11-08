using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Mechanics.LoopCycle;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character
{
    public class CharacterMover : IMover, IUpdateListener
    {
        private readonly CharacterConfig _config;

        private readonly Vector2 _mainDirection;
        private readonly float _maxSpeed;
        private readonly float _minSpeed;
        protected readonly ICharacterView CharacterView;
        private float _inTimeSpeedModifier;
        private float _maxSpeedModifier;
        private float _moveSpeed;

        public CharacterMover(ICharacterView characterView, CharacterConfig config, Vector2 direction, float speed)
        {
            CharacterView = characterView;
            _config = config;
            _minSpeed = -config.MaxSpeed;
            _maxSpeed = config.MaxSpeed;
            _mainDirection = direction;
            _moveSpeed = speed;
            SceneStarter.Instance.UpdateProvider.RegisterUpdateListener(this);
        }

        public virtual void Update()
        {
            _moveSpeed = NormalizeSpeed();
            CharacterView.UpdateCollides(_mainDirection);
            var velocity = _moveSpeed * _mainDirection.x;
            CharacterView.ApplyVelocity(velocity);

            if (CharacterView.Collided)
            {
                CharacterView.Collide(_mainDirection);
                _moveSpeed = 0;
            }

            CharacterView.ApplyVelocity(velocity);
        }

        public float CurrentSpeed => _moveSpeed;
        public void ApplySpeedModifier(float maxSpeed)
        {
            _maxSpeedModifier += maxSpeed;
        }
        public virtual void Dispose()
        {
            var sceneStarter = SceneStarter.Instance;
            if (sceneStarter == null)
                return;
                
            sceneStarter.UpdateProvider.RemoveUpdateListener(this);
        }
        
        private float NormalizeSpeed()
        {
            if (CharacterView.Collided)
                return -1;
            
            return Mathf.Clamp(_moveSpeed + _config.Acceleration, _minSpeed + _maxSpeedModifier, _maxSpeed + _maxSpeedModifier);
        }
    }
}
