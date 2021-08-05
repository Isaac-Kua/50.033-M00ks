using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstoppableDefensePassive : MonoBehaviour
{
	private  GameConstants gameConstants;
	private float slowRatio;
	private GameObject unbreakableHorns;
	private Vector2 hornPosition;
	private Vector2	hornDirection;
	private Quaternion angle = new Quaternion(0,0,0,0);
	// Start is called before the first frame update
	void Start()
	{
		gameConstants = GetComponent<UpgradeManager>().gameConstants;
		slowRatio = gameConstants.slowRatio;
		hornDirection = GetComponent<M00ks1Controller>().faceDirection;
        hornPosition = new Vector2(transform.position.x, transform.position.y) - hornDirection*gameConstants.hornDistance;
        unbreakableHorns = Instantiate(gameConstants.unbreakable,hornPosition,transform.rotation);
        unbreakableHorns.transform.parent = transform;
	}

	// Update is called once per frame
	void Update()
	{
		unbreakableHorns.GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX;
		if (unbreakableHorns.GetComponent<SpriteRenderer>().flipX)
		{
			unbreakableHorns.transform.position = transform.position + new Vector3(-0.42f, gameConstants.hornDistance, 0);
		}
		else {
			unbreakableHorns.transform.position = transform.position + new Vector3(0.42f, gameConstants.hornDistance, 0);
		}
		if (GetComponent<UpgradeManager>().unstoppableDefense){
			unbreakableHorns.SetActive(true);
		
			if (GetComponent<M00ksDeathHandler>().Brittle){
				GetComponent<M00ksDeathHandler>().allEnable();
				GetComponent<Rigidbody2D>().drag = 1000*slowRatio;
				} else {
					GetComponent<Rigidbody2D>().drag = gameConstants.defaultDrag;
				}
		}
		else {
			unbreakableHorns.SetActive(false);
			}
}
	} 
		
