using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{   
    public GameObject readyMenu;
    public void onClickPlay(){
        this.gameObject.SetActive(false);
        readyMenu.SetActive(true);
    }
}
