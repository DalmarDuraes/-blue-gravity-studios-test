using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public static class EventManager
{
	private static readonly Dictionary<Enum,Delegate> _events = new Dictionary<Enum, Delegate>();

	private static void OnRegister(Enum eventType, Delegate callback)
	{
		if(!_events.ContainsKey(eventType))
			_events.Add(eventType, null);

		var foundDelegate = _events[eventType];

		if(foundDelegate != null && foundDelegate.GetType() != callback.GetType())
		{
			Debug.LogWarning("Trying to add a callback of a different type than the event registered");
			return;
		}

		_events[eventType] = Delegate.Combine(_events[eventType], callback);
	}

	private static void OnUnregister(Enum eventType, Delegate callback)
	{
		if(_events.ContainsKey(eventType))
		{
			var foundDelegate = _events[eventType];

			if(foundDelegate == null)
			{
				Debug.LogWarning("There are no more callbacks registered for this event");
				return;
			}

			if(foundDelegate.GetType() != callback.GetType())
			{
				Debug.LogWarning("Trying to remove a callback from a different type than the registered event type");
				return;
			}

			_events[eventType] = Delegate.Remove(_events[eventType], callback);

			if(_events[eventType] == null)
				_events.Remove(eventType);
		}
		else
		{
			Debug.LogWarning("There are no events registered for this type yet");
		}
	}

	private static T[] GetAllListeners<T>(Enum eventType)
	{
		Delegate foundDelegate;

		if(_events.TryGetValue(eventType, out foundDelegate))
		{
			if(foundDelegate == null)
				return new T[0];
				
			var listeners = foundDelegate.GetInvocationList().Cast<T>().ToArray();
			return listeners;
		}
		else
			return new T[0];
	}

	public static void Register(Enum eventType, Action callbackFunction)
	{
		OnRegister(eventType, callbackFunction);
	}

	public static void Unregister(Enum eventType, Action callbackFunction)
	{
		OnUnregister(eventType, callbackFunction);
	}

	public static void Trigger(Enum eventType)
	{
		var listeners = GetAllListeners<Action>(eventType);

		if(listeners.Length == 0)
		{
			Debug.LogWarning("No listeners registered for the triggered event");
			return;
		}

		foreach(var listener in listeners)
			listener.Invoke();
	}

	public static void Register<T>(Enum eventType, Action<T> callbackFunction)
	{
		OnRegister(eventType, callbackFunction);
	}

	public static void Unregister<T>(Enum eventType, Action<T> callbackFunction)
	{
		OnUnregister(eventType, callbackFunction);
	}

	public static void Trigger<T>(Enum eventType, T param)
	{
		var listeners = GetAllListeners<Action<T>>(eventType);

		if(listeners.Length == 0)
		{
			Debug.LogWarning("No listeners registered for the triggered event");
			return;
		}

		foreach(var listener in listeners)
			listener.Invoke(param);
	}

	public static void Register<T,U>(Enum eventType, Action<T,U> callbackFunction)
	{
		OnRegister(eventType, callbackFunction);
	}

	public static void Unregister<T,U>(Enum eventType, Action<T,U> callbackFunction)
	{
		OnUnregister(eventType, callbackFunction);
	}

	public static void Trigger<T,U>(Enum eventType, T param1, U param2)
	{
		var listeners = GetAllListeners<Action<T,U>>(eventType);

		if(listeners.Length == 0)
		{
			Debug.LogWarning("No listeners registered for the triggered event: "+ eventType);
			return;
		}

		foreach(var listener in listeners)
			listener.Invoke(param1, param2);
	}

	public static void RegisterReturn<R>(Enum eventType, Func<R> callback)
	{
		OnRegister(eventType, callback);
	}
	
	public static void UnregisterReturn<R>(Enum eventType, Func<R> callback)
	{
		OnUnregister(eventType, callback);
	}

	public static void TriggerReturn<R>(Enum eventType, Action<R> returnCallback)
	{
		var listeners = GetAllListeners<Func<R>>(eventType);

		if(listeners.Length == 0)
		{
			Debug.LogWarning("No listeners registered for the triggered event");
			return;
		}

		foreach(var variable in listeners.Select(listener => listener.Invoke()).Cast<R>())
			returnCallback.Invoke(variable);
	}

	public static void RegisterReturn<T,R>(Enum eventType, Func<T,R> callback)
	{
		OnRegister(eventType, callback);
	}
	
	public static void UnregisterReturn<T,R>(Enum eventType, Func<T,R> callback)
	{
		OnUnregister(eventType, callback);
	}

	public static void TriggerReturn<T,R>(Enum eventType, T param1, Action<R> returnCallback)
	{
		var listeners = GetAllListeners<Func<T,R>>(eventType);

		if(listeners.Length == 0)
		{
			Debug.LogWarning("No listeners registered for the triggered event");
			return;
		}

		foreach(var variable in listeners.Select(listener => listener.Invoke(param1)).Cast<R>())
			returnCallback.Invoke(variable);
	}
}
