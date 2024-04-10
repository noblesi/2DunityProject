using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : Component where T : Singleton<T>
{
    private static T instance = null;
    private static bool isWarning = true;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var gameObj = new GameObject(typeof(T).Name);

                Singleton<T>.isWarning = false;
                Singleton<T>.instance = gameObj.AddComponent<T>();

                DontDestroyOnLoad(gameObj);
            }
            return instance;
        }
    }

    public override void Awake()
    {
        base.Awake();

        if(Singleton<T>.isWarning )
        {
            Debug.LogWarning($"{typeof(T).Name}이 씬 상에 이미 배치되어있습니다.");
        }

        if(Singleton<T>.instance == null)
        {
            Singleton<T>.instance = this as T;
        }
    }

    public static T Create()
    {
        return Singleton<T>.instance; 
    }
}
