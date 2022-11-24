using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonhommeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float vitesse = 5.0f;
    Vector3 mouvement;
    public Animator animator;
    private Rigidbody2D rig;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        mouvement.z = 0;
        
    }



    // Update is called once per frame
    void Update()
    {


        // gerer les entrées

        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");
       

    }

    private void FixedUpdate()
    {
        rig.velocity = mouvement.normalized * vitesse;
    }
}
