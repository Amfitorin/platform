using System;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.InputControllers
{
    /// <summary>
    /// Controller key for jump
    /// </summary>
    public class JumpInputController : IInputController
    {
        /// <summary>
        /// event on jump key
        /// </summary>
        public event Action JumpEvent;

        public void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                JumpEvent?.Invoke();
            }
        }
    }
}
