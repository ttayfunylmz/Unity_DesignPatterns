using System;
using System.Collections.Generic;
using UnityEngine;


// Settings the Execution Order to -1 to ensure this component is initialized before any other component.
[DefaultExecutionOrder(-1)]
/// <summary>
/// A simple Service Locator pattern implementation for managing game services.
/// </summary>
public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new();

    /// <summary>
    /// Registers a service instance of type T.
    /// </summary>
    /// <typeparam name="T">The service type.</typeparam>
    /// <param name="service">The service instance to register.</param>
    public static void RegisterService<T>(T service) where T : class
    {
        var type = typeof(T);
        if (_services.ContainsKey(type))
        {
            Debug.LogWarning($"{type} already registered.");
            return;
        }
        _services[type] = service;
    }

    /// <summary>
    /// Attempts to register a service instance of type T.
    /// </summary>
    /// <typeparam name="T">The service type.</typeparam>
    /// <param name="service">The service instance to register.</param>
    /// <returns>True if the service was registered successfully, otherwise false.</returns>
    public static bool TryRegisterService<T>(T service) where T : class
    {
        var type = typeof(T);
        if (_services.ContainsKey(type))
        {
            return false;
        }
        _services[type] = service;
        return true;
    }

    /// <summary>
    /// Retrieves a registered service instance of type T.
    /// </summary>
    /// <typeparam name="T">The service type.</typeparam>
    /// <returns>The registered service instance, or null if not found.</returns>
    public static T GetService<T>() where T : class
    {
        var type = typeof(T);
        if (_services.TryGetValue(type, out var service))
        {
            return service as T;
        }
        Debug.LogError($"{type} is not registered in the service locator.");
        return null;
    }

    /// <summary>
    /// Attempts to retrieve a registered service instance of type T.
    /// </summary>
    /// <typeparam name="T">The service type.</typeparam>
    /// <param name="service">The output parameter that will contain the service instance if found.</param>
    /// <returns>True if the service was found, otherwise false.</returns>
    public static bool TryGetService<T>(out T service) where T : class
    {
        var type = typeof(T);
        if (_services.TryGetValue(type, out var foundService))
        {
            service = foundService as T;
            return true;
        }
        service = null;
        return false;
    }

    /// <summary>
    /// Checks if a service of type T is registered.
    /// </summary>
    /// <typeparam name="T">The service type.</typeparam>
    /// <returns>True if the service is registered, otherwise false.</returns>
    public static bool IsRegistered<T>() where T : class
    {
        return _services.ContainsKey(typeof(T));
    }

    /// <summary>
    /// Unregisters a service instance of type T.
    /// </summary>
    /// <typeparam name="T">The service type.</typeparam>
    public static void UnregisterService<T>() where T : class
    {
        var type = typeof(T);
        _services.Remove(type);
    }
}