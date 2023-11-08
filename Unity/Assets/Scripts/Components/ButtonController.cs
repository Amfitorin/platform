using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MyRI.Components
{
    public class ButtonController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler, IButtonController
    {
        [SerializeField]
        private UnityEvent _onPointerUp;

        [SerializeField]
        private UnityEvent _onPointerDown;

        [SerializeField]
        private UnityEvent _onPointerClick;

        public void OnPointerUp(PointerEventData eventData)
        {
            _onPointerUp?.Invoke();
            OnUpEvent?.Invoke();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            _onPointerDown?.Invoke();
            OnDownEvent?.Invoke();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            _onPointerClick?.Invoke();
            OnClickEvent?.Invoke();
        }
        public event Action OnUpEvent;
        public event Action OnDownEvent;
        public event Action OnClickEvent;
    }
}
