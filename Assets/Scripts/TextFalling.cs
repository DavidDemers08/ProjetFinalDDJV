using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFalling : MonoBehaviour
{
    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        for (int i = 800; i >= 400; i--)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, i);
            yield return new WaitForSeconds(0.005f);
        }
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
