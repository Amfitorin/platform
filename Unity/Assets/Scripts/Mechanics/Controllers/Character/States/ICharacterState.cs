using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    public interface ICharacterState
    {
        IMover Mover { get; }
        void ApplyState(Vector2 direction, float speed);
        void RemoveState();
    }
}
