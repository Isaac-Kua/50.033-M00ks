using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooController : MonoBehaviour
{
	public GameConstants gameConstants;
	private float lifeTime;
	private float stickiness;
	private List<GameObject> targets = new List<GameObject>();
	
    // Start is called before the first frame update
    void Start()
    {
		lifeTime = gameConstants.gooPoolLifeTime;
		stickiness = gameConstants.stickiness;
        StartCoroutine(LifeTime());
    }

	IEnumerator LifeTime(){
		yield return new WaitForSeconds(lifeTime);
		Destroy(gameObject);
	}
    // Update is called once per frame


	void OnTriggerStay2D(Collider2D other)
    {
		other.GetComponent<Rigidbody2D>().drag = 1000 * stickiness;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		other.GetComponent<Rigidbody2D>().drag = gameConstants.defaultDrag;
	}
}
