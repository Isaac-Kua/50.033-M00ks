using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitenController : MonoBehaviour
{
	public GameConstants gameConstants;
	private float kaitenGrowthRate;
	private float kaitenCastTime;
	private float kaitenMaxRadius;
	private Collider2D Collider;

	public bool RangeMod = false;
    public bool BypassMod = false;
    public bool SpeedMod = false;
    public bool HeavyMod = false;

	// Start is called before the first frame update
	void Start()
	{
		Collider = gameObject.GetComponent<BoxCollider2D>();
		Debug.Log(RangeMod);
		if(SpeedMod){
			kaitenGrowthRate = gameConstants.kaitenGrowthRate*2f;
			kaitenCastTime = gameConstants.kaitenCastTime*0.5f;
		}else{
			kaitenGrowthRate = gameConstants.kaitenGrowthRate;
			kaitenCastTime = gameConstants.kaitenCastTime;
		}
		
		if(RangeMod){
			kaitenMaxRadius = gameConstants.kaitenMaxRadius*1.5f;
		}else{
			kaitenMaxRadius = gameConstants.kaitenMaxRadius;
		}
		StartCoroutine(GrowCoroutine());
	
	}

	void onTrigger(Collider col)
	{
		if (HeavyMod)
		{
			if (col.gameObject.tag == "Arrow"||col.gameObject.tag == "Firebolt"||col.gameObject.tag == "Icebolt")
			{
				//If the GameObject has the same tag as specified, output this message in the console
				Destroy(col.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.localScale.x < kaitenMaxRadius){
			transform.localScale *= kaitenGrowthRate;
		}
	}

	
	
	private IEnumerator GrowCoroutine ()
	{
		yield return new WaitForSeconds(kaitenCastTime);
		Destroy(gameObject);
	}
}
