using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character.States
{
    /// <summary>
    /// Character car state, started when character collect all part items
    /// </summary>
    public class CarState : ICharacterState
    {
        /// <summary>
        /// Current character for state
        /// </summary>
        private readonly ICharacterController _character;

        /// <summary>
        /// Mover in current state 
        /// </summary>
        public IMover Mover { get; }
        public CarState(ICharacterController character)
        {
            _character = character;
        }


        /// <summary>
        /// Apply character state
        /// </summary>
        /// <param name="direction">Character move direction </param>
        /// <param name="speed">Character move speed </param>
        public void ApplyState(Vector2 direction, float speed)
        {

        }
        /// <summary>
        /// Remove character state
        /// </summary>
        public void RemoveState()
        {

        }
    }
}
