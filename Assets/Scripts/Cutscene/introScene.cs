using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class introScene : MonoBehaviour
{
    public bool stop = false;
    public bool playing = false;
    public GameObject levelInitializer;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject msgBox;
    public GameObject skipText;
    private Coroutine intro;
    public GameObject subtitle;
    private List<PlayerConfiguration> playerConfigs;
    

    // Start is called before the first frame update
    void Start()
    {
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        five.SetActive(false);
        msgBox.SetActive(false);
        subtitle.SetActive(false);
        playerConfigs = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
        skipText.SetActive(false);
        intro = StartCoroutine(cutscene());
        GameManager.Instance.cutscene = true;
        playing = true;
    }

    void Update()
    {
        if (stop){
            StopCoroutine(intro);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            msgBox.SetActive(false);
            subtitle.SetActive(false);
            skipText.SetActive(false);
            GameManager.Instance.cutscene = false;
            stop = false;
            playing = false;
            for(int i =0; i<GameManager.Instance.totalPlayers; i++){
                playerConfigs[i].playerPrefab.GetComponent<M00ks1Controller>().StartActions();
            }
            Time.timeScale = 1f;
        }
    }

    IEnumerator cutscene()
    {
        Debug.Log("Intro Cutscene");
        for(int i = 0; i<GameManager.Instance.totalPlayers; i++){
            playerConfigs[i].playerPrefab.GetComponent<M00ks1Controller>().StopActions();
            Debug.Log("Stop Action " + i);
        }
        Time.timeScale = 0f;
        msgBox.SetActive(true);
        skipText.SetActive(true);
        one.SetActive(true);
        subtitle.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        one.SetActive(false);
        two.SetActive(true);
        subtitle.GetComponent<Text>().text = "You work relentlessly for the overlord day and night like a skele-dog that you are.\nKilling enemies and collecting their souls for the overlord to make him stronger.";
        yield return new WaitForSecondsRealtime(5);
        two.SetActive(false);
        three.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        three.SetActive(false);
        four.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        four.SetActive(false);
        five.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        five.SetActive(false);
        msgBox.SetActive(false);
        subtitle.SetActive(false);
        skipText.SetActive(false);
        GameManager.Instance.cutscene = false;
        levelInitializer.GetComponent<AudioSource>().clip = levelInitializer.GetComponent<Initializer>().getAudioClip(0);
        levelInitializer.GetComponent<AudioSource>().Play();
        for(int i =0; i<GameManager.Instance.totalPlayers; i++){
            playerConfigs[i].playerPrefab.GetComponent<M00ks1Controller>().StartActions();
        }
        Time.timeScale = 1f;
    }
}
