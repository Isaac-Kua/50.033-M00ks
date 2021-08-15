using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarSoulUI : MonoBehaviour
{
    private int souls;
    private int soulsUI;

    // Start is called before the first frame update
    void Start()
    {
        AltarManager.NextStage1 += resetUI;
    }
    private void OnDestroy() {
        AltarManager.NextStage1 -= resetUI;
    }
    // Update is called once per frame
    void Update()
    {
        souls = AltarManager.Instance.altarSouls;
        foreach (Transform eachchild in transform){
            if (soulsUI < souls){
                eachchild.gameObject.SetActive(true);
                soulsUI++;
            }
            else{
                eachchild.gameObject.SetActive(false);
            }
        }
        soulsUI = 0;
    }

    void resetUI()
    {
        soulsUI = 0;
    }
}
