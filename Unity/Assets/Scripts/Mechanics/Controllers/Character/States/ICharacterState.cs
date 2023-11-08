using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    /// <summary>
    /// Character state interface. Using in state pattern for change character state on some conditions
    /// </summary>
    public interface ICharacterState
    {
        /// <summary>
        /// Mover in current state 
        /// </summary>
        IMover Mover { get; }
        
        /// <summary>
        /// Apply character state
        /// </summary>
        /// <param name="direction">Character move direction </param>
        /// <param name="speed">Character move speed </param>
        void ApplyState(Vector2 direction, float speed);
        
        /// <summary>
        /// Remove character state
        /// </summary>
        void RemoveState();
    }
}
