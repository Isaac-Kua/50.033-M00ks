using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScene : MonoBehaviour
{
    public bool stop = false;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    private Coroutine intro;

    // Start is called before the first frame update
    void Start()
    {
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        five.SetActive(false);
        intro = StartCoroutine(cutscene());
        GameManager.Instance.cutscene = true;
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
            GameManager.Instance.cutscene = false;
            stop = false;
        }
    }

    IEnumerator cutscene()
    {
        one.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        one.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        two.SetActive(false);
        three.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        three.SetActive(false);
        four.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        four.SetActive(false);
        five.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        five.SetActive(false);
        GameManager.Instance.cutscene = false;
    }
}
