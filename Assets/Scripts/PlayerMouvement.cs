using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update

    
    private float horizontal;
    private readonly float moveSpeed = 8f;
    private readonly float jumpingPower = 16f;

    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private Animator animator;

    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private Rigidbody2D rig;
    private bool alive = true;



    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Vitesse", Math.Abs(horizontal));

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rig.velocity = new Vector2(rig.velocity.x, jumpingPower);
            }



            if (Input.GetButtonUp("Jump") && rig.velocity.y > 0f)
            {
                rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y * 0.5f);
            }

            if (IsGrounded())
            {
                animator.SetBool("IsJumping", false);
            }
            else
            {
                animator.SetBool("IsJumping", true);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector2(horizontal * moveSpeed, rig.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mechant"))
        {
            StartCoroutine(CoroutineDead());
        }
    }

    IEnumerator CoroutineDead()
    {
        alive = false;
        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.8f);
        EventManager.TriggerEvent("GameOver", null);

    }
}
