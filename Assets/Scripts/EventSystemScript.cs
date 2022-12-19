using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventSystemScript : MonoBehaviour
{
    //private EnumChoix choix = EnumChoix.eCommencerJeu;
    public GameObject fade;
    

    //private enum EnumChoix
    //{
    //    eQuitter = 1,
    //    eCommencerJeu = 2,
    //};
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void ChangerChoix()
    //{
    //    if (EventSystem.current.currentSelectedGameObject.name.Equals("Item 1: Quitter la partie"))
    //    {
    //        choix = EnumChoix.eQuitter;
    //    }
    //    else
    //    {
    //        choix = EnumChoix.eCommencerJeu;
    //    }

    //}

    public void Confirmer()
    {
            StartCoroutine(Niveau1());
    }

    public void Quitter()
    {
        Application.Quit();
    }

    private IEnumerator Niveau1()
    {
        fade.SetActive(true);
        fade.GetComponent<Animator>().Play("FadeIn");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Niveau1");
    }
}
