using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpikeController : MonoBehaviour { 
    public float lifeTime = 1f;
    public float meltTime = 2f;


    private Rigidbody2D itemBody;
    private SpriteRenderer itemSprite;

    // Start is called before the first frame update
    void Start()
    {

        itemBody = GetComponent<Rigidbody2D>();
        itemSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(Lifetime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifeTime);
        Explode();
    }

    void Explode()
    {
        itemBody.constraints = RigidbodyConstraints2D.FreezeAll;
        itemSprite.material.color = new Color(0, 0, 1); //C#
        StartCoroutine(Debris());
    }

    IEnumerator Debris()
    {
        yield return new WaitForSeconds(meltTime);
        gameObject.tag = "Debris";
        OnBecameInvisible();
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
