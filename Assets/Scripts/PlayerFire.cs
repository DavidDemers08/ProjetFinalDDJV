using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform endPointGun;
    private bool canFire = true;
    public float rateFireInSeconds;
    

    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canFire)
        {
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        canFire = false;
        Instantiate(bulletPrefab, endPointGun.position, endPointGun.rotation);
        yield return new WaitForSeconds(1f);
        canFire = true;
    }
}
