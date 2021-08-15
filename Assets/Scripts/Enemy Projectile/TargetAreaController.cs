using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAreaController : MonoBehaviour
{
	public GameConstants gameConstants;
	private float explosionScale;
	
    // Start is called before the first frame update
    void Start()
    {
		explosionScale = gameConstants.fireboltExplosionScale;	
		transform.localScale*= gameConstants.fireboltExplosionScale;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
