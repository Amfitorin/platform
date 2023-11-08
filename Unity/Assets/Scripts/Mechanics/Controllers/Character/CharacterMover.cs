using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Mechanics.LoopCycle;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character
{
    /// <summary>
    /// base character mover, move character with rigidBody velocity 
    /// </summary>
    public class CharacterMover : IMover, IUpdateListener
    {
        /// <summary>
        /// character configuration settings
        /// </summary>
        private readonly CharacterConfig _config;

        /// <summary>
        /// move direction
        /// </summary>
        private readonly Vector2 _mainDirection;
        
        /// <summary>
        /// max character speed without modify effects
        /// </summary>
        private readonly float _maxSpeed;
        
        /// <summary>
        /// min character speed without modify effects
        /// </summary>
        private readonly float _minSpeed;
        
        /// <summary>
        /// character view need for use velocity
        /// </summary>
        protected readonly ICharacterView CharacterView;
        
        /// <summary>
        /// modifier for character speed, applyed from buffs
        /// </summary>
        private float _maxSpeedModifier;

        /// <summary>
        /// current character speed
        /// </summary>
        public float CurrentSpeed { get; private set; }

        public CharacterMover(ICharacterView characterView, CharacterConfig config, Vector2 direction, float speed)
        {
            CharacterView = characterView;
            _config = config;
            _minSpeed = -config.MaxSpeed;
            _maxSpeed = config.MaxSpeed;
            _mainDirection = direction;
            CurrentSpeed = speed;
            SceneStarter.Instance.UpdateProvider.RegisterUpdateListener(this);
        }
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

        public virtual void Update()
        {
            CurrentSpeed = NormalizeSpeed();
            CharacterView.UpdateCollides(_mainDirection);
            var velocity = CurrentSpeed * _mainDirection.x;
            CharacterView.ApplyVelocity(velocity);

            if (CharacterView.Collided)
            {
                CharacterView.Collide(_mainDirection);
                CurrentSpeed = 0;
            }

            CharacterView.ApplyVelocity(velocity);
        }

        private float NormalizeSpeed()
        {
            if (CharacterView.Collided)
                return -1;

            return Mathf.Clamp(CurrentSpeed + _config.Acceleration, _minSpeed + _maxSpeedModifier, _maxSpeed + _maxSpeedModifier);
        }
    }
}
