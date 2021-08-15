using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameConstants gameConstants;
    public GameObject target1;
    private Vector2 targetVector;
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0, 0, 0, 0);
	void Start()
	{
        targetVector = target1.transform.position - transform.position;
        GetComponent<Rigidbody2D>().AddRelativeForce(targetVector*gameConstants.rangerArrowSpeed, ForceMode2D.Impulse);
        dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, dir));
		angle.eulerAngles = eulerAngle;
		transform.rotation = angle;
    }
	
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = targetVector * gameConstants.rangerArrowSpeed;
    }

}
