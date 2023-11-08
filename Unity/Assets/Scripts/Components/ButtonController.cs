using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MyRI.Components
{
    /// <summary>
    /// Handler for take unity ui pointer events
    /// </summary>
    public class ButtonController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler, IButtonController
    {
        /// <summary>
        /// Events on up pointers
        /// </summary>
        [SerializeField]
        private UnityEvent _onPointerUp;

        /// <summary>
        /// Events on down pointer
        /// </summary>
        [SerializeField]
        private UnityEvent _onPointerDown;

        /// <summary>
        /// Events on pointers click
        /// </summary>
        [SerializeField]
        private UnityEvent _onPointerClick;

        /// <summary>
        /// Subscribe event for up pointer
        /// </summary>
        public event Action OnUpEvent;
        
        /// <summary>
        /// Subscribe event for down pointer
        /// </summary>
        public event Action OnDownEvent;
        
        /// <summary>
        /// Subscribe event for click pointer
        /// </summary>
        public event Action OnClickEvent;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _onPointerClick?.Invoke();
            OnClickEvent?.Invoke();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            _onPointerDown?.Invoke();
            OnDownEvent?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _onPointerUp?.Invoke();
            OnUpEvent?.Invoke();
        }
    }
}
