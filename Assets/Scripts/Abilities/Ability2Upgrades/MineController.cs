using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
	public GameConstants gameConstants;
	private bool armed = false;
	
    // Start is called before the first frame update
    void Start()
    {
		transform.position= transform.position + new Vector3(0,0,1);
		StartCoroutine(Arm());
		
    }

	IEnumerator Arm(){
		yield return new WaitForSeconds(gameConstants.armDuration);
		armed = true;
		GetComponent<SpriteRenderer>().color = Color.red;
		StartCoroutine(Disarm());
	}
	IEnumerator Disarm(){
		yield return new WaitForSeconds(gameConstants.mineLifeTime);
		if (gameObject!=null){
			Destroy(gameObject);
		}
	}
    // Update is called once per frame
	
	void OnTriggerEnter2D(Collider2D other){
		if (armed) {
			GetComponent<Collider2D>().enabled = false;
			if (other.gameObject.CompareTag("Player")){
				other.gameObject.GetComponent<M00ksDeathHandler>().OnStunned();
			} else {
				other.gameObject.GetComponent<DeathHandler>().OnStunned();
			}
			Destroy(gameObject);
		}
	}
}
