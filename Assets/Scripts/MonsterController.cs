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

    WaitForFixedUpdate wait;

    public RuntimeAnimatorController[] animCon;
    private Rigidbody2D target;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private Animator animator;
    private Collider2D col;

    private void Awake()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        wait = new WaitForFixedUpdate();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.isLive) return;

        if (!isLive || animator.GetCurrentAnimatorStateInfo(0).IsName("Hit")) return;

        Vector2 dirVector = target.position - rigid.position; 
        Vector2 nextVector = dirVector.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVector);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!GameManager.Instance.isLive) return;

        if (!isLive) return;

        spriteRenderer.flipX = target.position.x < transform.position.x;
    }

    private void OnEnable()
    {
        target = GameManager.Instance.controller.GetComponent<Rigidbody2D>();
        isLive = true;
        col.enabled = true;
        rigid.simulated = true;
        spriteRenderer.sortingOrder = 2;
        animator.SetBool("Dead", false);
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
        if (!collision.CompareTag("Bullet") || !isLive) return;

        curHp -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());

        if(curHp > 0)
        {
            animator.SetTrigger("Hit");
        }
        else
        {
            isLive = false;
            col.enabled = false;
            rigid.simulated = false;
            spriteRenderer.sortingOrder = 1;
            animator.SetBool("Dead", true);
            GameManager.Instance.kill++;
            GameManager.Instance.GetExp();
        }
    }

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.Instance.controller.transform.position;
        Vector3 dirVector = transform.position - playerPos;
        rigid.AddForce(dirVector.normalized * 3f, ForceMode2D.Impulse);

    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
