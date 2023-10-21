using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Extentions;
using Game.Messages;

namespace Game.Systems
{
    public static class TriggerListenerSystem
    {
        private static Dictionary<Type, List<IListener>> _listenersByType = new Dictionary<Type, List<IListener>>();

        public static void AddListener(IListener listener, Type messageType)
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

        public static void OnTrigger(IMessage message)
        {
            var type = message.GetType();
            if (_listenersByType.ContainsKey(type))
            {
                _listenersByType[type].ForEach(x => x.OnTrigger(message));
                return;
            }

            Debug.LogWarning($"Key {type} not contains in listeners dictionary");
        }

        public static void RemoveListener(IListener listener)
        {
            foreach (var item in _listenersByType.Values)
            {
                if (item.Contains(listener))
                    item.RemoveBySwap(item.IndexOf(listener));
            }
        }

        public static void ClearAllListeners()
        {
            _listenersByType.Clear();
        }
    }

    public interface IListener
    {
        public abstract void OnTrigger(IMessage message = null);
    }
}