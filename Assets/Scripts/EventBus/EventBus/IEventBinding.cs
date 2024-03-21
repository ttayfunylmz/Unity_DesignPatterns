using System;

//Generic interface for event bindings.
public interface IEventBinding<T>
{
    //Action to be invoked when the event occurs with a payload of type T.
    public Action<T> OnEvent { get; set; }
    //Action to be invoked when the event occurs with no arguments.
    public Action OnEventNoArgs { get; set; }
}