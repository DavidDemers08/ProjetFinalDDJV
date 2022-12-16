using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    private UnityAction<object> LorsDead;
    private UnityAction<object> ProchainNiveau;

    private void Awake()
    {
        LorsDead = new UnityAction<object>(RetourMenu);
    }
    private void OnEnable()
    {
        EventManager.StartListening("GameOver", LorsDead);

    }

    private void OnDisable()
    {
        EventManager.StopListening("GameOver", LorsDead);
    }

    void RetourMenu(object data)
    {
        StartCoroutine(CoroutineRetourMenu());
    }

    IEnumerator CoroutineRetourMenu()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Menu");

    }
}
