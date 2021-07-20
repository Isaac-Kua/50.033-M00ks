using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeController : MonoBehaviour
{
	public GameConstants gameConstants;
	private float kamikazeGrowthRate;
	private float kamikazeCastTime;
	private float kamikazeMaxRadius;
	// Start is called before the first frame update
	void Start()
	{
		kamikazeGrowthRate = gameConstants.kamikazeGrowthRate;
		kamikazeCastTime = gameConstants.kamikazeCastTime;
		kamikazeMaxRadius = gameConstants.kamikazeMaxRadius;
		StartCoroutine(GrowCoroutine());
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.localScale.x < kamikazeMaxRadius){
			transform.localScale *= kamikazeGrowthRate;
			}
	}
	
	private IEnumerator GrowCoroutine ()
	{
		yield return new WaitForSeconds(kamikazeCastTime);
		Destroy(gameObject);
	}
}
