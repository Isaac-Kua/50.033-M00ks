using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{   

    public void onClickPlay(){
        Debug.Log("Clicked PLay");
        SceneManager.LoadScene("MainMenu");
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
