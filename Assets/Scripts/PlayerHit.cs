using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Hurt());
            
        }
    }

    private IEnumerator Hurt()
    {
        anim.SetBool("IsHurt", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsHurt", false);

    }
}
