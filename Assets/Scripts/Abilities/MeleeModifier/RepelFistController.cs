using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelFistController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Arrow") || other.gameObject.CompareTag("PlayerArrow")){
			if (other.gameObject.name!= "M00ks1(Clone)"){
                Destroy(other.gameObject);
            }
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Arrow") || other.gameObject.CompareTag("PlayerArrow"))
        {
            if (other.gameObject.name!= "M00ks1(Clone)" || other.gameObject.name!= "Kaiten(Clone)"){
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Arrow") || other.gameObject.CompareTag("PlayerArrow"))
        {
            if (other.gameObject.name!= "M00ks1(Clone)" || other.gameObject.name!= "Kaiten(Clone)"){
                Destroy(other.gameObject);
            }
        }
    }
}
