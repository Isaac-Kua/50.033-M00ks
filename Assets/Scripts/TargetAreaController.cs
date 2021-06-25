using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAreaController : MonoBehaviour
{
	
	public float explosionScale = 3;
	
    // Start is called before the first frame update
    void Start()
    {
		transform.localScale = new Vector3(explosionScale,explosionScale,0);   
		transform.position = new Vector3(transform.position.x, transform.position.y,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
