using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class portal2 : MonoBehaviour
{
    public UnityEvent unityEvent;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            unityEvent?.Invoke();
        }


    }

    public void NextScene()
    {
        SceneManager.LoadScene(3);
    }
}
