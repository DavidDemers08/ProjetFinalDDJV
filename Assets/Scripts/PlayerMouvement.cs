using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer sprite;
    public Rigidbody2D rig;
    public Animator animator;
    float horizontal = 0;
    readonly float moveSpeed = 5f;
    private float jumpingPower = 16f;
    private Transform groundCheck;
    private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
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
