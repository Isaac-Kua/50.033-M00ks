using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;
    
    [SerializeField]
    private GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {  
        var playerConfigs = PlayerConfigurationManager.Instance.getListOfPlayerConfigs().ToArray();
        
        GameManager.Instance.totalPlayers = playerConfigs.Length;
        for(int i =0; i<playerConfigs.Length; i++){
            var playerSprite = PlayerConfigurationManager.Instance.getPlayerSprite(i);
            Debug.Log("INSTATIATING " + i.ToString());
            var player = Instantiate(playerPrefab,playerSpawns[i].position,playerSpawns[i].rotation,gameObject.transform);
            player.GetComponent<M00ks1Controller>().InitializePlayer(playerConfigs[i],playerSprite);
            player.GetComponent<PlayerSoulController>().playerNo = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
