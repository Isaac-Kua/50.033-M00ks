using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class M00ks1Controller : MonoBehaviour
{
	public GameConstants gameConstants;
	public float speed;
	public Vector3 previousLocation;
	public Vector2 moveDirection;
	public Vector2 faceDirection;

	// ability use case
	private Rigidbody2D m00ksBody;
	private Collider2D m00ksCollider;
	private Vector2 dir;
	private float reverseDuration;
	private Quaternion angle = new Quaternion(0,0,0,0);


    // Start is called before the first frame update
    void Start()
    {
		m00ksBody = GetComponent<Rigidbody2D>();
		m00ksCollider = GetComponent<Collider2D>();
		previousLocation = transform.position;
		reverseDuration = gameConstants.reverseDuration;
		speed = gameConstants.M00ksMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

	}
	
	void FixedUpdate()
	{
		Move();
		StartCoroutine(WhatWasI());
	}
	
	public void OnMove(InputValue value)
	{
		moveDirection = value.Get<Vector2>().normalized;
		if (moveDirection.magnitude!=0)
		{
			faceDirection = moveDirection;
		}
	}

    void Move()
    {
		dir = (moveDirection).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		transform.rotation = angle;
        m00ksBody.velocity = new Vector2(moveDirection.x*speed, moveDirection.y*speed);
    }

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, faceDirection*5);
	}
				
	// Only used for reverseDash
	IEnumerator WhatWasI(){
		Vector3 trackedLocation = transform.position;
		yield return new WaitForSeconds(reverseDuration);
		previousLocation = trackedLocation;
	}
}
