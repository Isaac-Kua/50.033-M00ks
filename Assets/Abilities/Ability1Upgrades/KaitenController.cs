using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitenController : MonoBehaviour
{
	public GameConstants gameConstants;
	private float kaitenGrowthRate;
	private float kaitenCastTime;
	private float kaitenMaxRadius;

	public bool RangeMod = false;
    public bool BypassMod = false;
    public bool SpeedMod = false;
    public bool HeavyMod = false;

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log(RangeMod);
		kaitenGrowthRate = gameConstants.kaitenGrowthRate;
		kaitenCastTime = gameConstants.kaitenCastTime;
		// if(RangeMod){
		// 	kaitenMaxRadius = gameConstants.kaitenMaxRadius*1.5f;
		// }else{
		kaitenMaxRadius = gameConstants.kaitenMaxRadius;
		// }
		StartCoroutine(GrowCoroutine());
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
