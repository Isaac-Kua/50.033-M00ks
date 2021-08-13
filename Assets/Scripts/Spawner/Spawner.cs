using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    private GameObject[] enemies;

    void spawn()
    {   
        Debug.Log("Spawning");
        EnemyPool.SharedInstance.spawnEnemy(EnemyType.Lina);
        EnemyPool.SharedInstance.spawnEnemy(EnemyType.Davion);
        EnemyPool.SharedInstance.spawnEnemy(EnemyType.Traxex);
        EnemyPool.SharedInstance.spawnEnemy(EnemyType.Rylai);
        EnemyPool.SharedInstance.spawnEnemy(EnemyType.bara);
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

}