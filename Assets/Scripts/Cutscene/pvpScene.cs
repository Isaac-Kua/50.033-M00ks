using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pvpScene : MonoBehaviour
{
    public GameObject levelInitializer;    
    public GameObject msgBox;
    public GameObject skipText;
    public GameObject img;
    public GameObject text;
    public bool playing = false;
    private List<PlayerConfiguration> playerConfigs;
    private Coroutine pvp;
    public bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        img.SetActive(false);
        msgBox.SetActive(false);
        text.SetActive(false);
        playerConfigs = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
        GameManager.PVPStage += play;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop){
            StopCoroutine(pvp);
            img.SetActive(false);
            msgBox.SetActive(false);
            text.SetActive(false);
            skipText.SetActive(false);
            GameManager.Instance.cutscene = false;
            stop = false;
            playing = false;
            for(int i =0; i<GameManager.Instance.totalPlayers; i++){
                playerConfigs[i].playerPrefab.GetComponent<M00ks1Controller>().StartActions();
            }
            levelInitializer.GetComponent<AudioSource>().Stop();
            levelInitializer.GetComponent<AudioSource>().clip = levelInitializer.GetComponent<Initializer>().getAudioClip(4);
            levelInitializer.GetComponent<AudioSource>().Play();
            Time.timeScale = 1f;
        }
    }

    IEnumerator cutscene()
    {
        Time.timeScale = 0f;
        for(int i = 0; i<GameManager.Instance.totalPlayers; i++){
            playerConfigs[i].playerPrefab.GetComponent<M00ks1Controller>().StopActions();
        }
        msgBox.SetActive(true);
        skipText.SetActive(true);
        text.SetActive(true);
        img.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        img.SetActive(false);
        msgBox.SetActive(false);
        text.SetActive(false);
        skipText.SetActive(false);
        levelInitializer.GetComponent<AudioSource>().Stop();
        levelInitializer.GetComponent<AudioSource>().clip = levelInitializer.GetComponent<Initializer>().getAudioClip(4);
        levelInitializer.GetComponent<AudioSource>().Play();
        for(int i =0; i<GameManager.Instance.totalPlayers; i++){
            playerConfigs[i].playerPrefab.GetComponent<M00ks1Controller>().StartActions();
        }
        Time.timeScale = 1f;
    }

    public void play()
    {
        pvp = StartCoroutine(cutscene());
        playing = true;
        GameManager.Instance.cutscene = true;
    }
}
