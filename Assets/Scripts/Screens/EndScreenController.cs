using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndScreenController : MonoBehaviour
{
    public GameObject select;
    
    // Start is called before the first frame update
    void Start()
    {
        AltarManager.Lose += GameOver;
    }

    void GameOver()
    {
        Time.timeScale = 0f;
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
}
