using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class MagnetAlternateAbility : Ability
{	
	private List<GameObject> targets; 
	public float pullStrength;
	
	public override void Activate(GameObject parent)
	{
		targets = GameObject.FindGameObjectsWithTag("Player").ToList();
		targets.AddRange(GameObject.FindGameObjectsWithTag("Ranger"));
		targets.AddRange(GameObject.FindGameObjectsWithTag("Barbarian").ToList());
		targets.AddRange(GameObject.FindGameObjectsWithTag("IceWizard").ToList());
		targets.AddRange(GameObject.FindGameObjectsWithTag("FireWizard").ToList());
		targets.AddRange(GameObject.FindGameObjectsWithTag("Knight").ToList());
		
		StartCoroutine(CastCoroutine(parent, targets));
	}
	
	IEnumerator CastCoroutine(GameObject parent, List<GameObject> targets){
		var endOfFrame = new WaitForEndOfFrame();
		for (float timer = 0; timer < activeTime; timer += Time.deltaTime)
		{
			foreach (GameObject m00k in targets) {
				// disable movement
				if (m00k.CompareTag("Player")){
					m00k.GetComponent<M00ksDeathHandler>().allDisable();
				} else {
					m00k.GetComponent<DeathHandler>().allDisable();
				}
				Vector2 dir = (parent.transform.position  - m00k.transform.position).normalized;
				m00k.GetComponent<Rigidbody2D>().AddForce(dir*pullStrength, ForceMode2D.Impulse);
			}
			yield return endOfFrame;
		}
		
		foreach (GameObject m00k in targets) {
				Vector2 dir = (parent.transform.position  - m00k.transform.position).normalized;
				m00k.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				if (m00k.CompareTag("Player")){
					m00k.GetComponent<M00ksDeathHandler>().allEnable();
				} else {
					m00k.GetComponent<DeathHandler>().allEnable();
				}
			}
			
	}
}
