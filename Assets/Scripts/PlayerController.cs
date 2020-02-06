using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    public float speed = 2f;

    public float checkRadius;
    public LayerMask platform;
    public GameObject groundCheckPoint;
    public bool isOnGround;

    private bool playerDead;
    
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    public void LeftBtnClick()
    {
        rigidbody.velocity = new Vector2(-1 * speed, rigidbody.velocity.y);
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void RightBtnClick()
    {
        rigidbody.velocity = new Vector2(1 * speed, rigidbody.velocity.y);
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.transform.position, checkRadius, platform);
        animator.SetBool("isOnGround", isOnGround);
        animator.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spike"))
        {
            animator.SetTrigger("die");
        }
    }

    public void PlayerDead()
    {
        playerDead = true;
    }

    public void PlayerJump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 8f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.transform.position, checkRadius);
    }
}
