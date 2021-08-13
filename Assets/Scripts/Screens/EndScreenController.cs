using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ExitButton()
    {
        Application.Quit();
    }
}
