using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private Animator anim;
    public GameObject heartContainer;
    public PlayerLife vie;
    private void Start()
    {
        anim = GetComponent<Animator>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (vie.vie >0)
            {
                Destroy(heartContainer.transform.GetChild(0).gameObject);
                StartCoroutine(Hurt());
                vie.vie -= 0;
            }
            else
            {
                Death();
            }
           


            

            
        }
    }

    private void Death()
    {
        throw new NotImplementedException();
    }

    private IEnumerator Hurt()
    {
        anim.SetBool("IsHurt", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsHurt", false);

    }

    IEnumerator CoroutineDead()
    {
        //animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.8f);
        EventManager.TriggerEvent("GameOver", null);

    }
}
