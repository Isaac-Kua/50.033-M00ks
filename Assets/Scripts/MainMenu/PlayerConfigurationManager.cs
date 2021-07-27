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
    private int MinPlayers = 1;
    public static PlayerConfigurationManager Instance {get; private set;}
    public GameObject M00ksPrefab;


    private void Awake(){
        //MinPlayers = 2;
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
            // for(int i=0;i<playerConfigs.Count;i++){
            //     var newPosition = new Vector3(2*i,2*i,1);
            //     var mook = Instantiate(M00ksPrefab,this.transform.position+ newPosition,Quaternion.identity);
            //     playerConfigs[index].M00ks = mook;  
            // }
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
    public GameObject playerPrefab;
}
