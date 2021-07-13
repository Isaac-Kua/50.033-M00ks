using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    public EnemyType enemyType;
    void Start()
    {   
        spawnFromPooler();
    }


    void spawnFromPooler()
    {
        GameObject item = EnemyPool.SharedInstance.GetPooledObject(enemyType);

        if (item != null)
        {
            //set position
            item.transform.position = this.transform.position;
            item.SetActive(true);
        }
        else
        {
            Debug.Log("not enough items in the pool!");
        }
    }


}