using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ServiceLocator
{
    private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

    public static void Register<T>(object serviceInstance)
    {
        Services[typeof(T)] = serviceInstance;
    }

    public static bool HasService<T>()
    {
        return Services.ContainsKey(typeof(T));
    }

    public static T GetService<T>()
    {
        return (T)Services[typeof(T)];
    }

    public static void Reset()
    {
        Services.Clear();
    }
}
