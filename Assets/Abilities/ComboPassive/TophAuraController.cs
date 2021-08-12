using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TophAuraController : MonoBehaviour
{
	public GameConstants gameConstants;
	private float timeRate;

	// Start is called before the first frame update
	void Start()
	{
		transform.localScale = transform.localScale * gameConstants.TophRadius;
		timeRate = gameConstants.TophRatio;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject != transform.parent.gameObject) {
			other.GetComponent<Rigidbody2D>().drag = 1000*timeRate;
		}
	}

    void OnTriggerExit2D(Collider2D other)
    {
		other.GetComponent<Rigidbody2D>().drag = gameConstants.defaultDrag;
	}
}