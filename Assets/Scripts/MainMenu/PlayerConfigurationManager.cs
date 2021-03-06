using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField]
    private int MinPlayers = 1;
    [SerializeField]
    private Sprite[] playerSprites;
    public static PlayerConfigurationManager Instance {get; private set;}


    private void Awake(){
        //MinPlayers = 2;
        Time.timeScale = 1.0f;
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

    public Sprite getPlayerSprite(int i){
        return playerSprites[i];
    }

    public GameObject getPlayerPrefab(int i){
        return playerConfigs[i].playerPrefab;
    }
        
    

    public void SetPlayerSprite(int index, Sprite s){
        playerConfigs[index].PlayerSprite = s;
    }

    public void ReadyPlayer(int index){
        playerConfigs[index].isReady = true;
        if(AllPlayerReady()){
            Debug.Log("Players ready");
            SceneManager.LoadScene("Level");
        }else{
            Debug.Log("Players not readied");
        }
    }

    private bool AllPlayerReady(){
        Debug.Log(playerConfigs.Count);
        Debug.Log(MinPlayers);
        if (playerConfigs.Count >= MinPlayers && playerConfigs.All(p=>p.isReady==true)){
            return true;
        }
        else{
            return false;
        }
    }

    public void OnPlayerJoined(PlayerInput pi){
        Debug.Log("Player Joined: "+pi.playerIndex);
        
        if(!playerConfigs.Any(p=>p.PlayerIndex==pi.playerIndex)){
            pi.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfiguration(pi));
            Debug.Log(pi);
        }
    }

    public void destroyInstance(){
        Destroy(this.gameObject);
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
    public Sprite PlayerSprite {get;set;}
    public GameObject playerPrefab;
}
