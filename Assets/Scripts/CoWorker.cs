using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoWorker : MonoBehaviour
{
    // Start is called before the first frame update
    public void Work(IEnumerator _coroutine)
    {
        StartCoroutine(WorkCoroutine(_coroutine));
    }
 
    private IEnumerator WorkCoroutine(IEnumerator _coroutine)
    {
        yield return StartCoroutine(_coroutine);
        Destroy(this.gameObject);
    }
}
