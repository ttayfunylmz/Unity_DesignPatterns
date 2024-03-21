using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Utility class for managing event buses.
public static class EventBusUtil 
{
    //Properties to get the list of event types & event bus types.
    public static IReadOnlyList<Type> EventTypes { get; set; }
    public static IReadOnlyList<Type> EventBusTypes { get; set; }
    
#if UNITY_EDITOR
    public static PlayModeStateChange PlayModeState { get; set; }
   
    //Method called when the Unity Editor is initialized.
    [InitializeOnLoadMethod]
    public static void InitializeEditor() 
    {
        //Subscribing to play mode state change events.
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }
    
    //Method to handle play mode state changes in the Unity Editor.
    private static void OnPlayModeStateChanged(PlayModeStateChange state) 
    {
        PlayModeState = state;
        if (state == PlayModeStateChange.ExitingPlayMode) 
        {
            ClearAllBuses();
        }
    }
#endif

    //Method called when the application is initialized.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize() 
    {
        EventTypes = AssemblyUtil.GetTypes(typeof(IEvent));
        EventBusTypes = InitializeAllBuses();
    }

    // Method to initialize all event buses.
    private static List<Type> InitializeAllBuses() 
    {
        List<Type> eventBusTypes = new List<Type>();
        
        var typedef = typeof(EventBus<>);
        foreach (var eventType in EventTypes) 
        {
            var busType = typedef.MakeGenericType(eventType);
            eventBusTypes.Add(busType);
            Debug.Log($"Initialized EventBus<{eventType.Name}>");
        }
        
        return eventBusTypes;
    }

    //Method to clear all event buses.
    public static void ClearAllBuses()
    {
        Debug.Log("Clearing all buses...");
        for (int i = 0; i < EventBusTypes.Count; i++) 
        {
            var busType = EventBusTypes[i];
            var clearMethod = busType.GetMethod("Clear", BindingFlags.Static | BindingFlags.NonPublic);
            clearMethod?.Invoke(null, null);
        }
    }
}