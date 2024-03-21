//Interface representing a generic event. 
//This can be implemented by various event types to be handled by the event bus.
public interface IEvent {}

//Struct representing an event related to sound.
public struct SoundEvent : IEvent {}

//Struct representing an event related to the user interface (UI).
public struct UIEvent : IEvent
{
    public int value; //For score.
}
