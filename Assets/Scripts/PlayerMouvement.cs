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



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Vitesse", Math.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
        }

        

        if (Input.GetButtonUp("Jump") && rig.velocity.y > 0f)
        {
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y * 0.5f);
        }

        if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
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
}
