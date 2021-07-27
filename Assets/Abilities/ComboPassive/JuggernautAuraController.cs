using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautAuraController : MonoBehaviour
{
	public GameConstants gameConstants;
	private float timeRate;

	// Start is called before the first frame update
	void Start()
	{
		transform.localScale = transform.localScale * gameConstants.JuggernautRadius;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Debris"))
        {
			Destroy(other.gameObject);
        }
	}

}
