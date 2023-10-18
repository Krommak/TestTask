using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class UIManager : MonoBehaviour
    {
        [HideInInspector]
        public static UIManager Instance { get; private set; }
        
        [SerializeField]
        private UIElement[] _uiElements;

        private UIElement _activeElement;
        private Dictionary<Type, UIElement> _elementsByType;

        private void OnEnable()
        {
            Instance = this;
            _elementsByType = new Dictionary<Type, UIElement>();

            foreach (var item in _uiElements)
            {
                _elementsByType.Add(item.GetType(), item);
                item.gameObject.SetActive(false);
            }
        }

        public void UpdateElement<T>(IUIElementData data) where T : UIElement
        {
            if(_elementsByType.ContainsKey(typeof(T)))
            {
                _activeElement?.Cleare();
                _activeElement?.gameObject.SetActive(false);

                var element = _elementsByType[typeof(T)];
                element.gameObject.SetActive(true);
                element.UpdateElement(data);
                _activeElement = element;
            }
        }

        public void CleareaAndHideElement<T>()
        {
            if (_elementsByType.ContainsKey(typeof(T)))
            {
                var element = _elementsByType[typeof(T)];
                element.Cleare();
                element.gameObject.SetActive(false);
                _activeElement = null;
            }
        }
    }
}