using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

[CreateAssetMenu]
public class SpiderDashAbility : Ability
{
    public float dashSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
	private GameObject[] targets;
	private GameObject selectedTarget;
    
    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody2D>();
        parent.GetComponent<M00ks1Controller>().Immunity = true;
        Debug.Log("Dash: Spider");
		
		targets = GameObject.FindGameObjectsWithTag("Debris");		
		// targets.Add(GameObject.FindGameObjectsWithTag("Wall"));
		
		List<GameObject> viable = targets.ToList();
		selectedTarget = FindClosestObstacle(viable, parent);	
		moveDirection = selectedTarget.transform.position - parent.transform.position;		
        StartCoroutine(DashCoroutine(parent));

    }

    private IEnumerator DashCoroutine(GameObject parent)
    {
        var endOfFrame = new WaitForEndOfFrame();
        Debug.Log("dashing");
        for(float timer = 0; timer < moveDirection.magnitude/dashSpeed; timer += Time.deltaTime)
        {
            rb.MovePosition(rb.position + (moveDirection.normalized * (dashSpeed * Time.deltaTime)));
            yield return endOfFrame;
        }
        parent.GetComponent<M00ks1Controller>().Immunity = false;
    }
	
	private GameObject FindClosestObstacle(List<GameObject>  viable, GameObject parent)
	{
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = parent.transform.position;
		foreach (GameObject go in viable)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
}
