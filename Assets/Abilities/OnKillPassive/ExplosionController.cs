using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
	public GameConstants gameConstants;
	private float katsuGrowthRate;
	private float katsuCastTime;
	private float katsuMaxRadius;
	// Start is called before the first frame update
	void Start()
	{
		katsuGrowthRate = gameConstants.katsuGrowthRate;
		katsuCastTime = gameConstants.katsuCastTime;
		katsuMaxRadius = gameConstants.katsuMaxRadius;
		StartCoroutine(GrowCoroutine());
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.localScale.x < katsuMaxRadius)
		{
			transform.localScale *= katsuGrowthRate;
		}
	}

	private IEnumerator GrowCoroutine()
	{
		yield return new WaitForSeconds(katsuCastTime);
		Destroy(gameObject);
	}
}
