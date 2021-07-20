using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnMenu : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> playerSetupMenus;
    private List<PlayerConfiguration> playerConfigs;
    public PlayerInput input;
    private void Awake() {
        playerConfigs = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
        Debug.Log(playerConfigs);
        for(int i=0;i<playerSetupMenus.Count;i++){
            try{
                if(playerConfigs[i]!=null){
                    Debug.Log("Player "+i.ToString()+" menu is active");
                    playerSetupMenus[i].SetActive(true);
                    input.uiInputModule = playerSetupMenus[i].GetComponentInChildren<InputSystemUIInputModule>();
                    playerSetupMenus[i].GetComponent<PlayerReadyController>().SetPlayerIndex(input.playerIndex);
                }
            }catch{
                 playerSetupMenus[i].SetActive(false);
            }
            
        }
        
    }
    private void Update(){
        
    }
}
