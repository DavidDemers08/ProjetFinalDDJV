using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC_Cyborg : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
            StartCoroutine(CoroutineDead());
        }
    }

    IEnumerator CoroutineDead()
    {
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(0.8f);
        EventManager.TriggerEvent("GameOver", null);

    }
   
}
