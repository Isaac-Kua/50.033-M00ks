using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
	public GameConstants gameConstants;
	public Vector3 target1;

	private float distance;
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0, 0, 0, 0);
	private Rigidbody2D spiderBody;
	private SpriteRenderer spiderSprite;
	// Start is called before the first frame update
	void Start()
    {
		spiderBody = GetComponent<Rigidbody2D>();
		spiderSprite = GetComponent<SpriteRenderer>();
		StartCoroutine(LifeTime());
	}

	void FixedUpdate()
	{
		target1 = new Vector3(Random.Range(-gameConstants.xBound, gameConstants.xBound), Random.Range(-gameConstants.yBound, gameConstants.yBound), 0);
		dir = (target1 - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, dir));
		angle.eulerAngles = eulerAngle;

		distance = Vector2.Distance(transform.position, target1);
		transform.rotation = angle;
		spiderBody.velocity = (dir * gameConstants.SpiderMoveSpeed);

	}

	IEnumerator LifeTime()
	{
		yield return new WaitForSeconds(gameConstants.SpiderLifeTime);
		spiderBody.velocity = Vector2.zero;
		Destroy(gameObject);
	}
}
