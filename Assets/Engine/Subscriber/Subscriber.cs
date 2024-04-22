using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace Engine
{
		public enum EventType { OnComplete, OnStart, OnChange }
		static public class Subscriber
		{
				static private Dictionary<string, object> m_ActionsMap = new Dictionary<string, object>();

				static public SubscriberType Subscribe<SubscriberType>(this SubscriberType current, EventType eventType, UnityAction<SubscriberType> action)
				{
						string key = GetValidEventName(current, eventType);
						if (!m_ActionsMap.ContainsKey(key))
						{
								UnityEvent<SubscriberType> newEvent = new UnityEvent<SubscriberType>();
								m_ActionsMap.Add(key, newEvent);
						}
						((UnityEvent<SubscriberType>)m_ActionsMap[key]).AddListener(action);
						return current;
				}
				static public SubscriberType Unsubscribe<SubscriberType>(this SubscriberType current, EventType eventType, UnityAction<SubscriberType> action)
				{
						string key = GetValidEventName(current, eventType);
						if (m_ActionsMap.ContainsKey(key))
						{
								((UnityEvent<SubscriberType>)m_ActionsMap[key]).RemoveListener(action);
						}
						
						return current;
				}
				static public void InvokeEvent<SubscriberType>(this SubscriberType current, EventType eventType)
				{
						string key = GetValidEventName(current, eventType);
						if (m_ActionsMap.ContainsKey(key) && m_ActionsMap[key] != null)
								((UnityEvent<SubscriberType>)m_ActionsMap[key]).Invoke(current);
				}

				static private string GetValidEventName(object current, EventType eventType)
				{
						return $"{current.GetType()}_{eventType}";
				}
		}
}