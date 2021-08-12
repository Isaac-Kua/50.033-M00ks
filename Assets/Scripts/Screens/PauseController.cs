using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseController : MonoBehaviour
{
    public GameObject select;
    public static PauseController Instance;

    void Awake()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "PauseScreen")
            {
                eachChild.gameObject.SetActive(true);
            }
        }
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(select, new BaseEventData(eventSystem));
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        foreach (Transform eachChild in transform)
        {
            eachChild.gameObject.SetActive(false);
        }
    }
}
