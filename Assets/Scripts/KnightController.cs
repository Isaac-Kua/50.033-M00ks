using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
	public float maxSpeed = 5;
	public float speed;
	private Rigidbody2D knightBody;
	private SpriteRenderer knightSprite;
	private bool Immunity = false;
	public GameObject target1;
    // Start is called before the first frame update
    void Start()
    {
        knightBody = GetComponent<Rigidbody2D>();
		knightSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
    }
}
