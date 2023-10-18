using UnityEngine;

namespace Game.UI
{
    public abstract class UIElement : MonoBehaviour
    {
        public abstract void UpdateElement(IUIElementData data = null);
        public abstract void Cleare();
    }

    public interface IUIElementData
    {
    }

    public interface IDontDeactivateOnOtherPanelOpened
    {

    }
}