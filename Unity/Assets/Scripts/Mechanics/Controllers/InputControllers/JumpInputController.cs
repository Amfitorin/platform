using System;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.InputControllers
{
    public class JumpInputController : IInputController
    {
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
