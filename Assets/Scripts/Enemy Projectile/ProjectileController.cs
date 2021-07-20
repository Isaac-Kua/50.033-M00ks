using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
	public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter2D(Collision2D other)
	{
        if (!gameObject.CompareTag("Player")){
            if (!gameObject.CompareTag("Debris") && !(gameObject.name == "ZangiefFist(Clone)") && !(gameObject.name == "KnockbackProjectile")) {
                Destroy(gameObject);
            } }
	}
}
