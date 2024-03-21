using System;

//Concrete implementation of the generic event binding interface.
public class EventBinding<T> : IEventBinding<T> where T : IEvent
{
    //Private fields to store the actions for event handling.
    private Action<T> onEvent = _ => { };
    private Action onEventNoArgs = () => { };

    //Implementation of OnEvent property from the interface. (Explicit Interface Implementation)
    Action<T> IEventBinding<T>.OnEvent 
    {
        get => onEvent;
        set => onEvent = value;
    }

    //Implementation of OnEventNoArgs property from the interface. (Explicit Interface Implementation)
    Action IEventBinding<T>.OnEventNoArgs 
    {
        get => onEventNoArgs;
        set => onEventNoArgs = value;
    }

    //Constructors
    public EventBinding(Action<T> onEvent) => this.onEvent = onEvent;
    public EventBinding(Action onEventNoArgs) => this.onEventNoArgs = onEventNoArgs;

    //Methods to add & remove actions to handle events with payload of type T.
    public void Add(Action<T> onEvent) => this.onEvent += onEvent;
    public void Remove(Action<T> onEvent) => this.onEvent -= onEvent;

    //Methods to add & remove actions to handle events with no arguments.
    public void Add(Action onEvent) => onEventNoArgs += onEvent;
    public void Remove(Action onEvent) => onEventNoArgs -= onEvent;

}
