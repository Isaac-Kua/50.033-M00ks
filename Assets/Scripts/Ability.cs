using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public float activeTime;
    public int charges;
    public float rechargeTime;

    public virtual void Activate(GameObject parent){}

    protected void StartCoroutine(IEnumerator _task)
    {
        if (!Application.isPlaying)
        {
            Debug.LogError("Can not run coroutine outside of play mode.");
            return;
        }
 
        CoWorker coworker = new GameObject("CoWorker_" + _task.ToString()).AddComponent<CoWorker>();
        coworker.Work(_task);
    }
}
