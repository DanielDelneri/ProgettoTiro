
using System.Collections.Generic;
using UnityEngine;
public static class JsonHelper
{
    public static string ToJson<T>(List<T> array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public List<T> Items;
    }


}