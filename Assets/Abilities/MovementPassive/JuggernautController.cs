using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautController : MonoBehaviour
{
    public GameConstants gameConstants;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.gameObject.transform.position;
    }
}
