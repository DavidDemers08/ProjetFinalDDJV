using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRotation : MonoBehaviour
{
    public Camera cam;
    private Quaternion m_MyQuaternion;

    // Start is called before the first frame update
    void Start()
    {
        m_MyQuaternion = new Quaternion();
    }

    // Update is called once per frame
    void Update()
    {

        // Start is called before the first frame update
        Vector3 positionOnScreen = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = positionOnScreen - transform.position;



        //float angle = Vector3.Angle(difference, Vector3.right);
        difference.z = 0.0f;

        transform.right = difference.normalized;
    }
}

