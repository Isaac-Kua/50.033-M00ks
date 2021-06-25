using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
	public GameObject shield;
	public float rotationPerSec = 1f;
	public float length = 1f;
	public float lifeTime = 1f;
	
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*length,transform.localScale.z);
		StartCoroutine(LifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(shield.transform.position, Vector3.forward, rotationPerSec * 360 * Time.deltaTime);
    }
	
	void  OnBecameInvisible()
	{
		Destroy(gameObject);	
	}
	
	IEnumerator LifeTime(){
		yield return new WaitForSeconds(lifeTime);
		OnBecameInvisible();
	}
}
