using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Bumblebee : MonoBehaviour
{	
	public GameObject selectedTarget;
	private Dictionary<GameObject,float> target_distance = new Dictionary<GameObject,float>();
	private Dictionary<GameObject,Vector2> target_dir = new Dictionary<GameObject,Vector2>();
	public float detectionRange;
	private GameObject[] targets; 
	
	// Start is called before the first frame update
	void Start()
	{
		detectionRange = 20;
		targets = GameObject.FindGameObjectsWithTag("Player");
		// targets.AddRange(GameObject.FindGameObjectsWithTag("Altar"));
		// // Targets Altar on spawn
		// selectedTarget = targets[0];
		
		foreach (GameObject m00k in targets) {
			float distance = Vector2.Distance(transform.position, m00k.transform.position);
			target_distance.Add(m00k,distance);
			Vector2 dir = (m00k.transform.position - this.transform.position).normalized;
			target_dir.Add(m00k,dir);
		}

		// foreach(KeyValuePair<GameObject, float> entry in target_distance)
		// {
			// Debug.Log(entry.Key.name);
			// Debug.Log(entry.Value);
		// }
		
	}
	
	// Update is called once per frame
	void Update()
	{		
		// Updates all distance
		foreach (GameObject m00k in targets) {
			float distance = Vector2.Distance(transform.position, m00k.transform.position);
			target_distance[m00k] = distance;
			Vector2 dir = (m00k.transform.position - this.transform.position).normalized;
			target_dir[m00k] = dir;
		}
				
		List<GameObject> viable = targets.ToList();
		foreach (GameObject m00k in targets) {
			// Filter by death
			if (m00k.CompareTag("Player")){
				// Debug.Log(m00k.name);
				if (m00k.GetComponent<M00ksDeathHandler>().Dead){
					// Debug.Log(m00k.name + " is Dead");
					viable.Remove(m00k);
					// Debug.Log(m00k.name + " is Removed");
				}
			}
			
			// Filter by debris
			//Length of the ray
			int layerMask = LayerMask.GetMask("Debris");
			//Get the first object hit by the ray
			RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.right, target_dir[m00k] , target_distance[m00k], layerMask);

			//If the collider of the object hit is not NUll
			if (hit.collider!= null && hit.collider.tag == "Debris")
			{
				//Hit something, print the tag of the object
				// Debug.Log(m00k.name + " is blocked");
				viable.Remove(m00k);
				// Debug.Log(m00k.name + " is Removed");
			}
			
			Debug.DrawRay(transform.position, target_dir[m00k] * target_distance[m00k], Color.red);
		}
		
		selectedTarget = FindClosestEnemy(viable);
		// Debug.Log(selectedTarget.name + " is selected");
	}
	
	public GameObject FindClosestEnemy(List<GameObject>  viable)
	{
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
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
