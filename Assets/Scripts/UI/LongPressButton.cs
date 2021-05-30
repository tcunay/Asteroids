using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class LongPressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        private bool _isPressed;

        public bool IsPressed => _isPressed;

        public UnityEvent OnLongPress;

        private void Awake()
        {
            ResetButton();
        }

        private void Update()
        {
            if (_isPressed == false) return;

            OnLongPress.Invoke();
        }

        private void ResetButton()
        {
            _isPressed = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ResetButton();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ResetButton();
        }
    }
}
