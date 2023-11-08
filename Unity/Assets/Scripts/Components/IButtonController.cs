using System;

namespace MyRI.Components
{
    public interface IButtonController
    {
        /// <summary>
        /// Subscribe event for click pointer
        /// </summary>
        event Action OnClickEvent;
        
        /// <summary>
        /// Subscribe event for down pointer
        /// </summary>
        event Action OnDownEvent;
        
        /// <summary>
        /// Subscribe event for up pointer
        /// </summary>
        event Action OnUpEvent;
    }
}
