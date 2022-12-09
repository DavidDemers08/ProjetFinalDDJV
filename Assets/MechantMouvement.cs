using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechantMouvement : MonoBehaviour
{
    public GameObject cible;
    public float distanceVision = 10.0f;
    public LayerMask masqueRaycast;
    public float vitesseChasse = 3.0f;
    private Animator anim;
    private Rigidbody2D rig;
    private Vector3 visionDirection;
    private bool alive = true;


    
   

    
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }


    void FixedUpdate()
    {
        if (alive) { 
            visionDirection = cible.transform.position - transform.position;
            visionDirection.Normalize();
            RaycastHit2D rayon = Physics2D.Raycast(transform.position, visionDirection, distanceVision, masqueRaycast);

            float distance_destination = distanceVision;
            
            if (rayon.collider != null)
            {
                distance_destination = rayon.distance;
                if (rayon.collider.gameObject.layer == LayerMask.NameToLayer("Joueur"))
                {
                Vector3 objectif = cible.transform.position - transform.position;
                objectif.Normalize();

                rig.velocity = objectif*vitesseChasse;


                anim.SetBool("chasse", true);
                }
            }

        }

    }

    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Joueur"))
        {
            Debug.Log("MORT");
            alive = false;
            anim.SetBool("Dead", true);
        }
    }
}