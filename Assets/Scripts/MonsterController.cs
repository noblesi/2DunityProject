using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterController : MonoBehaviour
{
    public float curHp;
    public float maxHp;

    public float speed;

    public bool isLive = true;

    public RuntimeAnimatorController[] animCon;
    [SerializeField] private Transform target;
    private SpriteRenderer spriteRenderer;
    Animator animator;

    private void Awake()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!isLive) return;

        float dirVector = Vector3.Distance(transform.position, target.position);
        
        if (dirVector <= 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }

        spriteRenderer.flipX = target.position.x < transform.position.x;
    }

    private void OnEnable()
    {
        target = GameManager.Instance.controller.transform;
        isLive = true;
        curHp = maxHp;
    }

    public void Init(SpawnData data)
    {
        animator.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHp = data.hp;
        curHp = data.hp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet")) return;

        curHp -= collision.GetComponent<Bullet>().damage;

        if(curHp > 0)
        {

        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
