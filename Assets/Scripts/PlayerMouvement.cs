using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController2D controller2D;
    public SpriteRenderer sprite;
    public Animator animator;
    float horizontal = 0;
    float moveSpeed = 40f;
    private bool jump = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;

        animator.SetFloat("Vitesse",Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
        }
        animator.SetBool("IsJumping", jump);

    }

    private void FixedUpdate()
    {
        controller2D.Move(horizontal * Time.fixedDeltaTime, false, jump);
        

    }

    public void OnLanded()
    {
        jump = false;
        animator.SetBool("IsJumping", jump);
    }
}
