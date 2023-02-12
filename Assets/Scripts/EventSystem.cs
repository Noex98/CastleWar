/* Call RegisterDelegate to register a script as an eventlistener. The provided delegate will then be called when an event of the eventType is fired.
 * Call FireEvent when a certain event happens
 * You can add new eventTypes by appending the EventType enum
 * IMPORTANT: Remember to unregister the delegate before the parent object is destroyed. 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum EventType { //Write the events that you need in the game, in this enum.
	CastleHit,
	BaseHit,
	TurnOver,
    TurnStart
}

public static class EventSystem {
	private static EventDelegate[] _registrants = new EventDelegate[System.Enum.GetValues(typeof(EventType)).Length];
    
	public static void RegisterForEvent(EventDelegate eventDelegate, EventType eventType) {
		_registrants [(int)eventType] += eventDelegate;
	}

	public static void FireEvent(EventType eventType) {
		if(_registrants[(int)eventType] != null)
			_registrants [(int)eventType] ();
	}

	public static void UnRegisterFromEvent(EventDelegate eventDelegate, EventType eventType) {
		_registrants [(int)eventType] -= eventDelegate;
	}
}

public delegate void EventDelegate();

// Implementation Example
/*
public class Test {
	void MethodToExecuteOnEventTrigger() {
		// Code here
	}

	void OnEnable() {
		EventSystem.RegisterForEvent(MethodToExecuteOnEventTrigger, EventType.NameOfEvent);
	}

	void OnDisable() {
		EventSystem.UnRegisterFromEvent(MethodToExecuteOnEventTrigger, EventType.NameOfEvent);
	}
}
*/

