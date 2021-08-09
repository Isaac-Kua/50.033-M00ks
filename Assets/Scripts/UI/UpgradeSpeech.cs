using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSpeech : MonoBehaviour
{
    public Text text;
    public Image skull1;
    public Image skull2;
    public Image skull3;

    public void threeStar()
    {
        text.text = "Excellent!";
        skull1.gameObject.SetActive(true);
        skull2.gameObject.SetActive(true);
        skull3.gameObject.SetActive(true);
    }

    public void twoStar()
    {
        text.text = "Try harder next time...";
        skull1.gameObject.SetActive(true);
        skull2.gameObject.SetActive(true);
        skull3.gameObject.SetActive(false);
    }

    public void oneStar()
    {
        text.text = "Disappointing";
        skull1.gameObject.SetActive(true);
        skull2.gameObject.SetActive(false);
        skull3.gameObject.SetActive(false);
    }
}
