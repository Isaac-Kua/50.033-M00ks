using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 0f;
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name != "StartScreen")
            {
                eachChild.gameObject.SetActive(false);
            }                
        }
    }

    public void StartButtonClicked()
    {
        Debug.Log("Start");
        foreach (Transform eachChild in transform)
        {
            eachChild.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
