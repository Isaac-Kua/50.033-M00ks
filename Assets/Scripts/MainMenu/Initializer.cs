using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;
    
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]    
    private Color[] colors;
    [SerializeField]
    private AudioClip[] audioClips;
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
            player.GetComponent<SpriteRenderer>().color = colors[i];
            player.GetComponent<PlayerSoulController>().playerNo = i;
        }
    }

    public AudioClip getAudioClip(int i){
        return audioClips[i];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
