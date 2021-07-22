using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidowmakerArrowController : MonoBehaviour
{
	public GameConstants gameConstants;
	void Start()
	{
		transform.position = transform.position + new Vector3(0, 0, 1);
		StartCoroutine(Pew());

	}

	IEnumerator Pew()
	{
		yield return new WaitForSeconds(gameConstants.WidowmakerDuration);
		Destroy(gameObject);
	}
}
