using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarlensFin : MonoBehaviour
{
    public Transform objectif;
    public GameObject bulle;
    public float speed = 1;
    public TextMeshProUGUI texte;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, objectif.position, speed * Time.deltaTime);

        if (transform.position.y == objectif.position.y)
        {
            GetComponent<Animator>().SetBool("Angry", true);
            StartCoroutine(AfficherBulle());
        }
    }

    private IEnumerator AfficherBulle()
    {
        
        yield return new WaitForSeconds(0.8f);
        bulle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        texte.gameObject.SetActive(true);
    }
}
