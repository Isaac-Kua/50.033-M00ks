using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
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
    }

    public void ReturnToMenuButton()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "StartScreen")
            {
                eachChild.gameObject.SetActive(true);
            }
            else
            {
                eachChild.gameObject.SetActive(false);
            }
        }
    }
}
