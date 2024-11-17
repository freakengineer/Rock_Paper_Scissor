using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace StellarPlay.Common.Manager
{
    public class EventManager
    {

        private Dictionary<Enum, Action<string>> enumBasedDictionary = new();

        private static EventManager _instance;

        public static EventManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventManager();
                }
                return _instance;
            }
        }

        public void SubscribeEvent<T>(T gameEvent, Action<string> action) where T : Enum
        {
            if (enumBasedDictionary.ContainsKey(gameEvent))
            {
                enumBasedDictionary[gameEvent] += action;
            }
            else
            {
                enumBasedDictionary.Add(gameEvent, action);
            }
        }

        public void UnSubscribeEvent<T>(T gameEvent, Action<string> action) where T : Enum
        {
            if (enumBasedDictionary.ContainsKey(gameEvent))
            {
                enumBasedDictionary[gameEvent] -= action;
            }
            else
            {
                enumBasedDictionary.Remove(gameEvent);
            }
        }

        public void TriggerEvent<T>(T gameEvent, string eventInfo = null) where T : Enum
        {
            if (enumBasedDictionary.ContainsKey(gameEvent))
            {
                enumBasedDictionary[gameEvent].Invoke(eventInfo);
            }
            else
            {
                Debug.Log("event not found");
            }
        }

    }
}
