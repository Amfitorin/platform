using UnityEngine;

namespace MyRI.Components.Character
{
    public interface ICharacterView
    {
        bool Grounded { get; }
        bool Collided { get; }
        void DoubleJump();
        void Jump();
        void ApplyVelocity(float velocity);
        void Collide(Vector2 direction);
        void ToGround();
        void UpdateCollides(Vector2 mainDirection);
    }
}
