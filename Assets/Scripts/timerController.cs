using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerController : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool startTimer = false;
    private Text timerText;
    public GameObject winScene;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer){
            if (timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
            }
            else{
                startTimer = false;
                timeRemaining = 0;
                winScene.SetActive(true);
                winScene.GetComponent<winScene>().getWinner();
                SetLevel.Instance.winner();
            }
        }
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = seconds.ToString();
    }
}
