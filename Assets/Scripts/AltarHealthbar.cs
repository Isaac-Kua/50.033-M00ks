using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltarHealthbar : MonoBehaviour
{
    private Image healthbar;
    public GameObject altar;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthBarValue(altar.GetComponent<AltarManager>().altarHealth * 0.01f);
    }

    void SetHealthBarValue(float value)
    {
        healthbar.fillAmount = value;
        if(healthbar.fillAmount < 0.25f)
        {
            SetHealthBarColor(Color.red);
        }
        else if(healthbar.fillAmount < 0.7f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    void SetHealthBarColor(Color healthColor)
    {
        healthbar.color = healthColor;
    }
}
