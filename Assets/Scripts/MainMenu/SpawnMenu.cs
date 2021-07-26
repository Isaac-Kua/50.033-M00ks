using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject playerSetupMenu;
    [SerializeField]
   
    private List<PlayerConfiguration> playerConfigs;
    public PlayerInput input;

    private void Awake() {
   
        playerConfigs = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
        var rootMenu = GameObject.Find("ReadyMenuLayout");
      
        if(rootMenu!=null){
            var menu = Instantiate(playerSetupMenu, rootMenu.transform);
            
            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            menu.GetComponent<PlayerReadyController>().SetPlayerIndex(input.playerIndex);
        }
        

    }

    private void Start(){
       
    }

    private void Update(){
        
    }

    // public void spawnMenu(int i){
    //     playerSetupMenus[i].SetActive(true);
    //     Debug.Log("Player "+i.ToString()+" menu is active");
    //     playerConfigs[i].Input.uiInputModule = playerSetupMenus[i].GetComponentInChildren<InputSystemUIInputModule>();
    //     playerSetupMenus[i].GetComponent<PlayerReadyController>().SetPlayerIndex(playerConfigs[i].Input.playerIndex);
    // }
}
