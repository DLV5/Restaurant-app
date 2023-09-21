using NUnit.Framework;
using System;
using System.Collections.Generic;

public class JsonHelper
{

    public static List<T> FromJson<T>(string json)
    {
        Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(List<T> list)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = list;
        return UnityEngine.JsonUtility.ToJson(wrapper, true);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public List<T> Items;
    }
}