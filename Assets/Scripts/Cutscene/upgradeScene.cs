using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeScene : MonoBehaviour
{
    public bool stop = false;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject msgBox;
    public GameObject skipText;
    public GameObject text;
    private Coroutine upgrade;
    private bool played = false;
    public bool playing = false;
    private List<PlayerConfiguration> playerConfigs;

    // Start is called before the first frame update
    void Start()
    {
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        text.SetActive(false);
        msgBox.SetActive(false);
        playerConfigs = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
    }

    // Update is called once per frame
    void Update()
    {
        if (stop){
            StopCoroutine(upgrade);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            msgBox.SetActive(false);
            text.SetActive(false);
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
        for(int i = 0; i<GameManager.Instance.totalPlayers; i++){
            playerConfigs[i].playerPrefab.GetComponent<M00ks1Controller>().StopActions();
        }
        Time.timeScale = 0f;
        msgBox.SetActive(true);
        text.SetActive(true);
        skipText.SetActive(true);
        one.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        one.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        two.SetActive(false);
        three.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        three.SetActive(false);
        msgBox.SetActive(false);
        text.SetActive(false);
        skipText.SetActive(false);
        GameManager.Instance.cutscene = false;
        for(int i =0; i<GameManager.Instance.totalPlayers; i++){
            playerConfigs[i].playerPrefab.GetComponent<M00ks1Controller>().StartActions();
        }
        Time.timeScale = 1f;
    }

    public void play()
    {
        if (!played) {
            upgrade = StartCoroutine(cutscene());
            playing = true;
            GameManager.Instance.cutscene = true;
            played = true;
        }
    }
}
