using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName =  "MagnetAlternateAbility", menuName =  "Ability 2/Magnet")]
public class MagnetAlternateAbility : Ability
{	
	public override void Activate(GameObject parent)
	{
		List<GameObject> targets = new List<GameObject>();
		targets.AddRange(GameObject.FindGameObjectsWithTag("Player")); 
		targets.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
		StartCoroutine(CastCoroutine(parent, targets));
	}

	IEnumerator CastCoroutine(GameObject parent, List<GameObject> targets){
		var endOfFrame = new WaitForEndOfFrame();
        for (float timer = 0; timer < activeTime; timer += Time.deltaTime)
        {
            foreach (GameObject m00k in targets)
            {
                if (m00k.CompareTag("Player"))
                {
                    m00k.GetComponent<M00ksDeathHandler>().allDisable();
                }
                else
                {
                    m00k.GetComponent<DeathHandler>().allDisable();
                }
                Vector2 dir = (parent.transform.position - m00k.transform.position).normalized;
                m00k.transform.position = Vector3.MoveTowards(m00k.transform.position, parent.transform.position, gameConstants.magnetPull);
            }
            yield return endOfFrame;
        }

        foreach (GameObject m00k in targets)
        {
            Vector2 dir = (parent.transform.position - m00k.transform.position).normalized;
            m00k.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (m00k.CompareTag("Player"))
            {
                m00k.GetComponent<M00ksDeathHandler>().allEnable();
            }
            else
            {
                m00k.GetComponent<DeathHandler>().allEnable();
            }
        }
    }
}
