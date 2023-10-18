using UnityEngine;

namespace Game.UI
{
    public abstract class UIElement : MonoBehaviour
    {
        public abstract void UpdateElement(IUIElementData data);
        public abstract void Cleare();
    }

    public interface IUIElementData
    {
    }
}