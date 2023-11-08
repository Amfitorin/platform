using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Mechanics.LoopCycle;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character
{
    
    /// <summary>
    /// mover with height position controll
    /// </summary>
    public class FlyMover : IMover, IUpdateListener
    {
        /// <summary>
        /// character configuration settings 
        /// </summary>
        private readonly CharacterConfig _config;
        
        /// <summary>
        /// character move direction
        /// </summary>
        private readonly Vector2 _mainDirection;
        
        /// <summary>
        /// max character speed
        /// </summary>
        private readonly float _maxSpeed;
        
        /// <summary>
        /// min character speed
        /// </summary>
        private readonly float _minSpeed;
        
        /// <summary>
        /// character fly direction changed, when player press and hold height button
        /// </summary>
        private Vector2 _flyDirection;
        
        /// <summary>
        /// speed modifier from buffs
        /// </summary>
        private float _maxSpeedModifier;
        
        /// <summary>
        /// character view for control position
        /// </summary>
        private ICharacterView CharacterView { get; }

        
        /// <summary>
        /// current character speed
        /// </summary>
        public float CurrentSpeed { get; private set; }

        public FlyMover(ICharacterView characterView, CharacterConfig config, Vector2 direction, float speed)
        {
            CharacterView = characterView;
            _config = config;
            _minSpeed = -config.MaxSpeed;
            _maxSpeed = config.MaxSpeed;
            _mainDirection = direction;
            CurrentSpeed = speed;
            SceneStarter.Instance.UpdateProvider.RegisterUpdateListener(this);
        }

        public void Dispose()
        {
            var sceneStarter = SceneStarter.Instance;
            if (sceneStarter == null)
                return;
            sceneStarter.UpdateProvider.RemoveUpdateListener(this);
        }
        public void ApplySpeedModifier(float maxSpeed)
        {
            _maxSpeedModifier += maxSpeed;
        }
        public void Update()
        {
            CurrentSpeed = NormalizeSpeed();
            CharacterView.UpdateCollides(_mainDirection);

            if (CharacterView.Collided)
            {
                CharacterView.Collide(_mainDirection);
                CurrentSpeed = 0;
            }

            var characterPosition = CharacterView.Position;
            characterPosition += (CurrentSpeed * _mainDirection + _config.FlyHeightSpeed * _flyDirection) * Time.deltaTime;

            CharacterView.ApplyPosition(characterPosition);
        }
        public void ApplyFlyDirection(Vector2 direction)
        {
            _flyDirection = direction;
        }

        private float NormalizeSpeed()
        {
            if (CharacterView.Collided)
                return -1;

            return Mathf.Clamp(CurrentSpeed + _config.Acceleration, _minSpeed + _maxSpeedModifier, _maxSpeed + _maxSpeedModifier);
        }
    }
}
