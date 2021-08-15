using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slides : MonoBehaviour
{
    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    public GameObject slide4;
    public GameObject slide5;
    public GameObject howToPlay;

    public GameObject next1;
    public GameObject next2;
    public GameObject next3;
    public GameObject next4;
    public GameObject next5;
    public GameObject pauseMenuButton;
    public GameObject howToPlayButton;

    // Start is called before the first frame update
    void Start()
    {
        hide();
    }

    public void hide()
    {
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(false);
        slide4.SetActive(false);
        slide5.SetActive(false);
        howToPlay.SetActive(false);
    }

    public void back()
    {
        hide();
        howToPlay.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(howToPlayButton, new BaseEventData(eventSystem));
    }

    public void showSlide1()
    {
        hide();
        slide1.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(next1, new BaseEventData(eventSystem));
    }

    public void showSlide2()
    {
        hide();
        slide2.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(next2, new BaseEventData(eventSystem));
    }

    public void showSlide3()
    {
        hide();
        slide3.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(next3, new BaseEventData(eventSystem));
    }

    public void showSlide4()
    {
        hide();
        slide4.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(next4, new BaseEventData(eventSystem));
    }

    public void showSlide5()
    {
        hide();
        slide5.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(next5, new BaseEventData(eventSystem));
    }

    public void done()
    {
        hide();
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "PauseScreen")
            {
                eachChild.gameObject.SetActive(true);
            }
        }
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(pauseMenuButton, new BaseEventData(eventSystem));
    }
}
