using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    public EnemyType enemyType;

    void Start()
    {   
        Debug.Log("Spawning");
        EnemyPool.SharedInstance.spawnEnemy(EnemyType.Lina);
        EnemyPool.SharedInstance.spawnEnemy(EnemyType.Davion);
        EnemyPool.SharedInstance.spawnEnemy(EnemyType.Traxex);
        EnemyPool.SharedInstance.spawnEnemy(EnemyType.Rylai);
    }

}