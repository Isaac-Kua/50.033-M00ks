using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFistController : MonoBehaviour
{
	public GameObject player;
	public float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if ((transform.position-player.transform.position).magnitude > range){
			Destroy(gameObject);
		}
    }
}
