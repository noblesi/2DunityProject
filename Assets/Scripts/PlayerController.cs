using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 inputVector;
    public Scanner scanner;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public Hand[] hands;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.isLive) return;

        transform.Translate(inputVector * speed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        if (!GameManager.Instance.isLive) return;

        anim.SetFloat("Speed", inputVector.magnitude);

        if(inputVector.x != 0)
        {
            spriteRenderer.flipX = inputVector.x < 0;
        }
    }
}
