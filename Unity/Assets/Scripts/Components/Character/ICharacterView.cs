using UnityEngine;

namespace MyRI.Components.Character
{
    public interface ICharacterView
    {
        bool Grounded { get; }
        bool Collided { get; }
        Vector2 Position { get; }
        void DoubleJump();
        void Jump();
        void ApplyVelocity(float velocity);
        void Collide(Vector2 direction);
        void ToGround();
        void UpdateCollides(Vector2 mainDirection);
        void ApplyPosition(Vector2 position);
        void DisableGravity(bool state);
    }
}
