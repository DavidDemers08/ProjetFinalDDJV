using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventSystemScript : MonoBehaviour
{
    private EnumChoix choix = EnumChoix.eCommencerJeu;
    

    private enum EnumChoix
    {
        eQuitter = 1,
        eCommencerJeu = 2,
    };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changerChoix()
    {
        if (EventSystem.current.currentSelectedGameObject.name.Equals("Item 1: Quitter la partie"))
        {
            choix = EnumChoix.eQuitter;
        }
        else
        {
            choix = EnumChoix.eCommencerJeu;
        }

    }

    public void onClick()
    {
        if (choix == EnumChoix.eCommencerJeu)
        {
           SceneManager.LoadScene("Niveau1");
        }
        else
        {
            Application.Quit();
        }
    }
    
}
