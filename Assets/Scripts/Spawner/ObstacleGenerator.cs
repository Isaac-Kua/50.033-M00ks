using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameConstants gameConstants;
    private GameObject Debris;
    private bool displaced = false;
    private bool respawning = false;

    // Start is called before the first frame update
    void Start()
    {
        Debris = Instantiate(gameConstants.StaticDebris, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Debris != null)
        {
            if (Debris.transform.position != transform.position && !displaced)
            {
                displaced = true;
                StartCoroutine(LifeTime());
            }
        } else if (Debris == null && !respawning)
        {
            respawning = true;
            StartCoroutine(SpawnDebris());
        }
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(gameConstants.DebrisLifeTime);
        Destroy(Debris);
        StartCoroutine(SpawnDebris());
        respawning = true;
    }

    IEnumerator SpawnDebris()
    {
        yield return new WaitForSeconds(gameConstants.DebrisSpawnTime);
        Debris = Instantiate(gameConstants.StaticDebris, transform.position, transform.rotation);
        displaced = false;
        respawning = false;
    }
}
