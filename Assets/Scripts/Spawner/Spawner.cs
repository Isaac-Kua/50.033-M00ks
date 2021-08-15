using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    private GameObject[] enemies;
    // public List<>

    void spawn()
    {   
        Debug.Log("Spawning");
        // EnemyPool.SharedInstance.spawnEnemy(EnemyType.Lina);
        // EnemyPool.SharedInstance.spawnEnemy(EnemyType.Davion);
        // EnemyPool.SharedInstance.spawnEnemy(EnemyType.Traxex);
        // EnemyPool.SharedInstance.spawnEnemy(EnemyType.Rylai);
        // EnemyPool.SharedInstance.spawnEnemy(EnemyType.bara);
        // for (int i = 0; i < 3; i++){
        //     spawnOne();
        // }
    }

    void Update()
    {
        if (!GameManager.Instance.upgradeSelection)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length <= 2)
            {
                spawn();
            }
        }
    }

    void spawnOne()
    {
        int rand = Random.Range(0,5);
        switch(rand){
            case(0):
                EnemyPool.SharedInstance.spawnEnemy(EnemyType.Lina);
                break;
            case(1):
                EnemyPool.SharedInstance.spawnEnemy(EnemyType.Davion);
                break;
            case(2):
                EnemyPool.SharedInstance.spawnEnemy(EnemyType.Traxex);
                break;
            case(3):
                EnemyPool.SharedInstance.spawnEnemy(EnemyType.Rylai);
                break;
            case(4):
                EnemyPool.SharedInstance.spawnEnemy(EnemyType.bara);
                break;
        }
    }

}