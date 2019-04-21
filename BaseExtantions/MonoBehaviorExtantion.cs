using UnityEngine;
using System.Collections;
using System.Linq;

public static class MonoBehaviorExtantion
{
    public static T GetInterfase<T>(this GameObject thisGo) where T : class
    {
        foreach (MonoBehaviour beh in thisGo.GetComponents<MonoBehaviour>())
        {
            T inter = beh as T;
            if (inter != null)
            {
                return inter;
            }
        }

        return null;
    }

    public static T[] GetInterfases<T>(this GameObject thisGo) where T : class
    {
        var res = thisGo.GetComponents<MonoBehaviour>().Select((monoBeh) => { return monoBeh as T; }).Where((t) => { return t != null; });

        return res.ToArray();
    }

    public static void Invoke(this MonoBehaviour thisGo, System.Action method, float time)
    {
        if ((MonoBehaviour)method.Target != thisGo) throw new System.Exception("Можно вызывать только методы внутри скрипта");
        //Debug.Log("Invoke +" + method.Method.Name);
        thisGo.Invoke(method.Method.Name, time);
    }
}