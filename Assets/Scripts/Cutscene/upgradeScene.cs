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
    private Coroutine upgrade;
    private bool played = false;
    public bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        msgBox.SetActive(false);
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
            skipText.SetActive(false);
            GameManager.Instance.cutscene = false;
            stop = false;
            playing = false;
            Time.timeScale = 1f;
        }
    }

    IEnumerator cutscene()
    {
        Time.timeScale = 0f;
        msgBox.SetActive(true);
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
        skipText.SetActive(false);
        GameManager.Instance.cutscene = false;
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
