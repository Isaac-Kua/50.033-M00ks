using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerReadyController : MonoBehaviour
{
    private int PlayerIndex;
    [SerializeField]
    private TextMeshProUGUI titleText;
    // [SerializeField]
    // private GameObject readyPanel;
    // [SerializeField]
    // private GameObject menuPanel;
    [SerializeField]
    private Button readyButton;
    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;

    public void SetPlayerIndex(int pi){
        PlayerIndex = pi;
        titleText.SetText("Player "+(pi+1).ToString());
        ignoreInputTime = Time.time +ignoreInputTime;
    }
    void Update(){

        if(Time.time>ignoreInputTime){
            inputEnabled = true;
        }

    }

    // public void SetColor(Color color){
    //     if (!inputEnabled){return;}
    //     PlayerConfigurationManager.Instance.SetPlayerColor(PlayerIndex,color);
    //     readyPanel.SetActive(true);
    //     readyButton.Select();
    //     //menuPanel.SetActive(false);
    // }

    public void ReadyButton(){
        
        if(!inputEnabled){return;}
        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex);
        readyButton.gameObject.SetActive(false);

    }
}
