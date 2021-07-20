using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField]
    private int MinPlayers = 4;
    public static PlayerConfigurationManager Instance {get; private set;}

    private void Awake(){
        if(Instance!=null){
            Debug.Log("Trying to create another instance of singleton!");
        }else{
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();    
        }
    }

    public List<PlayerConfiguration> getListOfPlayerConfigs(){
        return playerConfigs;
    }

    public void SetPlayerColor(int index, Color color){
        playerConfigs[index].PlayerColor = color;
    }

    public void ReadyPlayer(int index){
        playerConfigs[index].isReady = true;
        if(AllPlayerReady()){
            SceneManager.LoadScene("SampleScene");
        }else{
            Debug.Log("Players not readied");
        }
    }

    private bool AllPlayerReady(){
        if (playerConfigs.Count > MinPlayers && playerConfigs.All(p=>p.isReady==true)){    
            return true;
        }
        else{
            return false;
        }
    }

    public void HandlePlayerJoined(PlayerInput pi){
        Debug.Log("Player Joined: "+pi.playerIndex);
        
        if(!playerConfigs.Any(p=>p.PlayerIndex==pi.playerIndex)){
            pi.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }
}

public class PlayerConfiguration{

    public PlayerConfiguration(PlayerInput pi){
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }
    public PlayerInput Input {get;set;}
    public int PlayerIndex{get;set;}
    public bool isReady {get;set;}
    public Color PlayerColor {get;set;}
}
