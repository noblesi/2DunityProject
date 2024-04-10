using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    public Vector2 inputVector;

    private SpriteRenderer spriteRenderer;
    private Animator anim;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
        anim = GetComponent<Animator>();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        transform.Translate(inputVector * speed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVector.magnitude);

        if(inputVector.x != 0)
        {
            spriteRenderer.flipX = inputVector.x < 0;
        }
    }
}
