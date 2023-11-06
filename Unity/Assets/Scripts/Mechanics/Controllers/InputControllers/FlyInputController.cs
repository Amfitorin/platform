using System;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.InputControllers
{
    public class FlyInputController : IInputController
    {

        public event Action UpEvent;
        public event Action DownEvent;
        
        public void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                UpEvent?.Invoke();
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                DownEvent?.Invoke();
            }
        }
    }
}
