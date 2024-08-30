using System.Collections.Generic;
using UnityEngine;

//Static class representing an event bus for a specific event type T.
public static class EventBus<T> where T : IEvent
{
    //HashSet to store event bindings of type IEventBinding<T>.
    private static readonly HashSet<IEventBinding<T>> bindings = new HashSet<IEventBinding<T>>();

    // Methods to subscribe & unsubscribe an EventBinding<T> to & from the event bus.
    public static void Subscribe(EventBinding<T> binding) => bindings.Add(binding);
    public static void Unsubscribe(EventBinding<T> binding) => bindings.Remove(binding);

    //Method to publish an event of type T to all subscribed event bindings.
    public static void Publish(T eventToRaise)
    {
        foreach(var binding in bindings)
        {
            binding.OnEvent.Invoke(eventToRaise);
            binding.OnEventNoArgs.Invoke();
        }
    }

    //Method to clear all event bindings.
    private static void Clear()
    {
        bindings.Clear();
    }
}
