using System;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.InputControllers
{
    
    /// <summary>
    /// Controller for input keys fly state and change height
    /// </summary>
    public class FlyInputController : IInputController
    {
        /// <summary>
        /// event on start up
        /// </summary>
        public event Action UpStartEvent;
        
        /// <summary>
        /// event on start down
        /// </summary>
        public event Action DownStartEvent;

        /// <summary>
        /// event on stop height change
        /// </summary>
        public event Action StopEvent;

        private KeyCode _currentKey;

        public void CheckInput()
        {
            var wDown = Input.GetKeyDown(KeyCode.W);
            if (wDown && _currentKey != KeyCode.W)
            {
                UpStartEvent?.Invoke();
                _currentKey = KeyCode.W;
            }

            var sDown = Input.GetKeyDown(KeyCode.S);
            if (sDown && _currentKey != KeyCode.S)
            {
                DownStartEvent?.Invoke();
                _currentKey = KeyCode.S;
            }

            if (!wDown && !sDown && _currentKey != KeyCode.None)
            {
                StopEvent?.Invoke();
                _currentKey = KeyCode.None;
            }
        }
    }
}
