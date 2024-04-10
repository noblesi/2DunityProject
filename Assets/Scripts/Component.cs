using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour, IUpdatable
{
    public bool isDestroy { get; private set; } = false;

    public virtual void OnUpdate(float deltaTime)
    {

    }

    public virtual void OnLateUpdate(float deltaTime)
    {

    }

    public virtual void OnFixedUpdate(float deltaTime)
    {

    }

    public virtual void Awake()
    {

    }

    public virtual void Start()
    {

    }

    public virtual void OnDestroy()
    {
        this.isDestroy = true;
    }
}
