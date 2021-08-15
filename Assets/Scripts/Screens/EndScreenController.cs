using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    public GameObject select;
    public GameObject levelInitializer;
    
    // Start is called before the first frame update
    void Start()
    {
        AltarManager.Lose += GameOver;
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        levelInitializer.GetComponent<AudioSource>().Pause();
        levelInitializer.GetComponent<AudioSource>().clip = levelInitializer.GetComponent<Initializer>().getAudioClip(1);
        levelInitializer.GetComponent<AudioSource>().loop = false;
        levelInitializer.GetComponent<AudioSource>().Play();
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "EndScreen")
            {
                eachChild.gameObject.SetActive(true);
            }
        }
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(select, new BaseEventData(eventSystem));
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        Debug.Log("RESTARTING");
        PlayerConfigurationManager.Instance.destroyInstance();
        SceneManager.LoadScene("Initial");
    }
}
