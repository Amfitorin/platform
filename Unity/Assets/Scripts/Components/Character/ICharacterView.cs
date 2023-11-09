using MyRI.Configs.Collectables;
using UnityEngine;


namespace MyRI.Components.Character
{
    /// <summary>
    ///     View interface for character
    /// </summary>
    public interface ICharacterView
    {
        /// <summary>
        /// Flag for character collision of horizontal
        /// </summary>
        bool Collided { get; }
        
        /// <summary>
        /// Flag for character placed on ground
        /// </summary>
        bool Grounded { get; }
        
        /// <summary>
        /// Current transform position of character
        /// </summary>
        Vector2 Position { get; }
        
        /// <summary>
        /// Apply new transform position charater
        /// </summary>
        /// <param name="position"> new character position</param>
        void ApplyPosition(Vector2 position);
        
        /// <summary>
        /// Apply rigidbody2d velocity
        /// </summary>
        /// <param name="velocity"> new velocity</param>
        void ApplyVelocity(float velocity);
        
        /// <summary>
        /// Return player from collided horizontal object on direction
        /// </summary>
        /// <param name="direction">Move direction</param>
        void Collide(Vector2 direction);
        
        /// <summary>
        /// Disable rigidBody gravity scale
        /// </summary>
        /// <param name="state">Disable state value</param>
        void DisableGravity(bool state);
        
        /// <summary>
        /// Play Double jump character state
        /// </summary>
        void DoubleJump();
        
        /// <summary>
        /// Play character Jump
        /// </summary>
        void Jump();
        
        /// <summary>
        /// Set character view to ground state(after jumping)
        /// </summary>
        void ToGround();
        
        /// <summary>
        /// Update collides states on move direction
        /// </summary>
        void UpdateCollides(Vector2 mainDirection);
        void ToCar(CarGun gun);
    }
}
