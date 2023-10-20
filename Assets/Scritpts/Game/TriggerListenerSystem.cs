using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Systems
{
    public class TriggerListenerSystem : Singleton<TriggerListenerSystem>, IDisposable
    {
        private Dictionary<Type, List<IListener>> _listenersByType;

        public TriggerListenerSystem()
        {
            _listenersByType = new Dictionary<Type, List<IListener>>();
        }

        public virtual void AddListener(IListener listener, Type messageType)
        {
            var type = messageType;
            if (_listenersByType.ContainsKey(type))
            {
                if(!_listenersByType[type].Contains(listener))
                    _listenersByType[type].Add(listener);
                else
                    Debug.LogWarning($"Listeners {type} contains in dictionary");
            }
            else
            {
                _listenersByType.Add(type, new List<IListener>() { listener});
            }
        }

        public void OnTrigger(IMessage message)
        {
            var type = message.GetType();
            if (_listenersByType.ContainsKey(type))
            {
                _listenersByType[type].ForEach(x => x.OnTrigger(message));
                return;
            }

            Debug.LogWarning($"Key {type} not contains in listeners dictionary");
        }

        public virtual void RemoveListener(IListener listener, Type messageType)
        {
            var type = listener.GetType();
            if (_listenersByType.ContainsKey(type))
            {
                if (_listenersByType[type].Contains(listener))
                    _listenersByType[type].Remove(listener);
                else
                    Debug.LogWarning($"Listener {type} not contains in dictionary");

                return;
            }

            Debug.LogWarning($"Key {type} not contains in listeners dictionary");
        }

        public override void Dispose()
        {
            base.Dispose();
            _listenersByType.Clear();
        }
    }

    public interface IListener
    {
        public abstract void OnTrigger(IMessage message = null);
    }

    public interface IMessage
    {
    }
}