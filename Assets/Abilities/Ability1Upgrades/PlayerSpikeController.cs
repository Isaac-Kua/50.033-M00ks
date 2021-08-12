using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpikeController : MonoBehaviour { 
    public float lifeTime = 1f;
    public float meltTime = 2f;

	public bool RangeMod = false;
    public bool BypassMod = false;
    public bool SpeedMod = false;
    public bool HeavyMod = false;
    public bool blocked = false;
    public GameObject owner;

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
        gameObject.tag = "Debris";
        StartCoroutine(Debris());
    }

	void onCollision(Collider col)
	{
        if(HeavyMod)
        {
            if (col.gameObject.tag == "Debris")
            {
                Destroy(col.gameObject);
		    }
        }else
        {
            if(col.gameObject.tag == "Debris")
            {
                blocked = true;
            }
        }
	}

    IEnumerator Debris()
    {
        yield return new WaitForSeconds(meltTime);
        OnBecameInvisible();
    }

    void OnBecameInvisible()
    {
        if(gameObject!=null){
            Destroy(gameObject);
        }
    }
    
}
