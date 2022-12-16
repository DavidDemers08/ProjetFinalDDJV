using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rig;
    private float rebond = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mechant") || collision.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            Object.Destroy(this.gameObject);
        }
        else
        {
            rebond += 1;
            if (rebond >= 3)
            {
                Object.Destroy(this.gameObject);
            }
        }
    }
}
