using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stage = 1;

    public void increaseStage(){
        stage += 1;
    }
}
