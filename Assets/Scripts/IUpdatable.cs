using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdatable
{
    public void OnUpdate(float deltaTime);

    public void OnLateUpdate(float deltaTime);  

    public void OnFixedUpdate(float deltaTime);
}
