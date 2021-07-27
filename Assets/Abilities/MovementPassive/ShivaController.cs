using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShivaController : MonoBehaviour
{
	public GameConstants gameConstants;
	private float stickiness;

	// Start is called before the first frame update
	void Start()
	{
		transform.localScale = transform.localScale * gameConstants.shivaRadius;
		stickiness = gameConstants.shivaRatio;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject != transform.parent.gameObject) {
			other.GetComponent<Rigidbody2D>().drag = 1000 * stickiness; 
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		other.GetComponent<Rigidbody2D>().drag = gameConstants.defaultDrag;
	}
}