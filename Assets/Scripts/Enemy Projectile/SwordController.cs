using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject shield;
	
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y* gameConstants.knightSwordlength, transform.localScale.z);
		StartCoroutine(LifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(shield.transform.position, Vector3.forward, gameConstants.knightSwordRotationPerSec * 360 * Time.deltaTime);
    }
	
	void  OnBecameInvisible()
	{
		Destroy(gameObject);	
	}
	
	IEnumerator LifeTime(){
		yield return new WaitForSeconds(gameConstants.knightSwordLifeTime);
		OnBecameInvisible();
	}
}
