using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZangiefFistController : MonoBehaviour
{
	public GameObject player;
	public float rotationPerSec;
	public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = player.transform;
		StartCoroutine(LifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, Vector3.forward, rotationPerSec * 360 * Time.deltaTime);	
    }
	
	IEnumerator LifeTime(){
		yield return new WaitForSeconds(lifeTime);
		Destroy(gameObject);
	}
}
