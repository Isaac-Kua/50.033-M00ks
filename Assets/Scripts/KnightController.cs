using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
	public float speed = 5;
	public GameObject target1;
	public GameObject shield;
	
	public float swordLength = 1f;
	public float shieldWidth = 1f;
	public float windUpTime = 3f;
	
	
	private Rigidbody2D knightBody;
	private SpriteRenderer knightSprite;
	private GameObject myShield;
	
    // Start is called before the first frame update
    void Start()
    {
        knightBody = GetComponent<Rigidbody2D>();
		knightSprite = GetComponent<SpriteRenderer>();
		myShield = Instantiate(shield, transform.position, transform.rotation);
		myShield.GetComponent<ShieldController>().swordLength = swordLength;
		myShield.GetComponent<ShieldController>().shieldWidth = shieldWidth;
    }

    // Update is called once per frame
    void Update()
    {
		if (!myShield.GetComponent<ShieldController>().engaged && !target1.GetComponent<M00ks1Controller>().Dead) {
			transform.position = Vector2.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
		
			Vector3 dir = (target1.transform.position - this.transform.position).normalized;
			Quaternion angle = new Quaternion(0,0,0,0);
			Vector3 eulerAngle = new Vector3(0,0,90+Vector2.SignedAngle(Vector2.right,dir));
			angle.eulerAngles = eulerAngle;
		
			myShield.GetComponent<ShieldController>().target1 = target1;
			myShield.transform.position = transform.position + 2f*dir;
			myShield.transform.rotation = angle;
		}
    }
}
