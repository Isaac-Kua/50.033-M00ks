using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{  
    public GameObject levelInitializer;
    public GameObject select;
    public GameObject howToPlay;
    public GameObject exitHowToPlayButton;
    public static PauseController Instance;

    void Awake()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        levelInitializer.GetComponent<AudioSource>().Pause();
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "PauseScreen")
            {
                eachChild.gameObject.SetActive(true);
            }
        }
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(select, new BaseEventData(eventSystem));
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        levelInitializer.GetComponent<AudioSource>().Play();
        foreach (Transform eachChild in transform)
        {
            eachChild.gameObject.SetActive(false);
        }
    }

    public void endGameButton()
    {
        //Application.Quit();
        Debug.Log("RESTARTING");
        PlayerConfigurationManager.Instance.destroyInstance();
        SceneManager.LoadScene("MainMenu");
    }

    public void HowToPlayButton()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "PauseScreen")
            {
                eachChild.gameObject.SetActive(false);
            }
            if (eachChild.name == "HowToPlayScreen")
            {
                eachChild.gameObject.SetActive(true);
            }
            
        }
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(exitHowToPlayButton, new BaseEventData(eventSystem));
    }

    public void exitHowToPlay(){
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "HowToPlayScreen")
            {
                eachChild.gameObject.SetActive(false);
            }
            if (eachChild.name == "PauseScreen")
            {
                eachChild.gameObject.SetActive(true);
            }
            
        }
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(howToPlay, new BaseEventData(eventSystem));
    }

    public void exitGame(){
        Debug.Log("EXITING");
        Application.Quit();
    }
}
