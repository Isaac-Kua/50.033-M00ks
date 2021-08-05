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
	private Animator spiderAnimator;
	private bool dead;

	// Start is called before the first frame update
	void Start()
    {
		spiderBody = GetComponent<Rigidbody2D>();
		spiderSprite = GetComponent<SpriteRenderer>();
		spiderAnimator = GetComponent<Animator>();
		StartCoroutine(LifeTime());
	}

	void FixedUpdate()
	{
		if (!dead)
		{
			target1 = new Vector3(Random.Range(-gameConstants.xBound, gameConstants.xBound), Random.Range(-gameConstants.yBound, gameConstants.yBound), 0);
			dir = (target1 - this.transform.position).normalized;
			Vector3 eulerAngle = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, dir));
			angle.eulerAngles = eulerAngle;

			distance = Vector2.Distance(transform.position, target1);
			//transform.rotation = angle;
			spiderBody.velocity = (dir * gameConstants.SpiderMoveSpeed);
			spiderSprite.flipX = (dir.x < 0);
		}
	}

	IEnumerator LifeTime()
	{
		yield return new WaitForSeconds(gameConstants.SpiderLifeTime);
		dead = true;
		spiderBody.velocity = Vector2.zero;
		GetComponent<Collider2D>().enabled = false;
		spiderAnimator.SetTrigger("Death");
		yield return new WaitForSeconds(gameConstants.deathFadeTime);
		Destroy(gameObject);
	}
}
