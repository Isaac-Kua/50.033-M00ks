using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameConstants gameConstants;
    public GameObject target1;
    private Vector2 targetVector;
	void Start()
	{
        targetVector = target1.transform.position - transform.position;
        GetComponent<Rigidbody2D>().AddRelativeForce(targetVector*gameConstants.rangerArrowSpeed, ForceMode2D.Impulse);
    }
	
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = targetVector * gameConstants.rangerArrowSpeed;
    }

}
