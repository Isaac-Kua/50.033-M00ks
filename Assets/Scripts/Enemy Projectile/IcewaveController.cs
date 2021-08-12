using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcewaveController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject gameManager;
	public bool core;
	
	private GameObject spawn;
	
	private bool together = true;
	private bool exploded = false;
	private List<GameObject> wall = new List<GameObject>();
	private List<Vector3> wallPosition = new List<Vector3>();
	
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
		
		Vector2 perpendicular = Vector2.Perpendicular(itemBody.velocity);
		Vector3 spawnPosition = 2*perpendicular.normalized;
		if (core){
			for (int i = 1; i <= gameManager.GetComponent<GameManager>().currentLevel.wallLength; i++){
				spawn = Instantiate(gameConstants.debris, transform.position + i*spawnPosition,transform.rotation);
				spawn.GetComponent<IcewaveController>().core = false;
				spawn.GetComponent<Rigidbody2D>().velocity = itemBody.velocity;
				
				wall.Add(spawn);
				wallPosition.Add(i*spawnPosition);
				
				spawn = Instantiate(gameConstants.debris, transform.position - i*spawnPosition,transform.rotation);
				spawn.GetComponent<IcewaveController>().core = false;
				spawn.GetComponent<Rigidbody2D>().velocity = itemBody.velocity;
				
				wall.Add(spawn);
				wallPosition.Add(-i*spawnPosition);
			}
		}
		StartCoroutine(Lifetime());	
		
	}
	
    // Update is called once per frame
    void Update()
    {
		if (together){
			for (int i = 0; i < wall.Count; i++){
				if (wall[i] != null)
				{
					wall[i].transform.position = transform.position + wallPosition[i];
				}
			}
		}

		if (itemBody.velocity == Vector2.zero) {
			if (!exploded) Explode();
		}
    }
	
	void  OnBecameInvisible()
	{
		Destroy(gameObject);	
	}
	
	void Explode()
	{
		exploded = true;
		itemBody.velocity = Vector2.zero;
		itemBody.constraints = RigidbodyConstraints2D.FreezeAll;
		itemSprite.material.color = new Color(0,0,1); //C#
		together = false;
		gameObject.tag = "Debris";
		itemBody.mass = 1;
		StartCoroutine(Debris());
	}
	
	IEnumerator Debris()
	{
		yield return new WaitForSeconds(gameConstants.icewaveMeltTime);
		// Debug.Log("Ice wave melted");
		OnBecameInvisible();
	}
	
	IEnumerator Lifetime()
	{
		yield return new WaitForSeconds(gameConstants.icewaveLifeTime);
		// Debug.Log("Ice wave stopped");
		if (!exploded) Explode();
	}
}
