using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  enum EnemyType{
	bara =  0,
	Davion =  1,
    Lina = 2,
    Rylai = 3,
    Traxex = 4,
}

[System.Serializable]
public  class EnemyPoolItem
{
    //Each Enemy Metadata
	public  int amount;
	public  GameObject prefab;
	public  bool expandPool;
	public  EnemyType type;
}

public  class ExistingPoolItem
{
	public  GameObject gameObject;
	public  EnemyType type;

	// constructor
	public  ExistingPoolItem(GameObject gameObject, EnemyType type){
		// reference input
		this.gameObject  =  gameObject;
		this.type  =  type;
	}
}

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool SharedInstance;
    public GameObject gameManager;
    public List<EnemyPoolItem> itemsToPool; // types of different object to pool 
    public List<ExistingPoolItem> pooledObjects; // a list of all objects in the pool, of all types
    public List<GameObject> Spawners;

    private Collider2D polyCollider;
    private Collider2D npcCollider;
    void Awake()
    {
        SharedInstance = this;
        pooledObjects = new List<ExistingPoolItem>();
        Debug.Log("ObjectPooler Awake");

        foreach (EnemyPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amount; i++)
            {
                // this 'pickup' a local variable, but Unity will not remove it since it exists in the scene
                GameObject pickup = (GameObject)Instantiate(item.prefab);
                pickup.SetActive(false);
                pickup.transform.parent = this.transform;
                ExistingPoolItem e = new ExistingPoolItem(pickup, item.type);
                pooledObjects.Add(e);
            }
        }
    }

    void Start()
    {
        
    }
    void enableWithCheck(bool isEnabled){
        if(!isEnabled){
           isEnabled = true; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform){
            if (child.gameObject.activeInHierarchy){
                if(child.gameObject.GetComponent<KnightController>()!=null){
                    var controller1 = child.gameObject.GetComponent<KnightController>();
                    enableWithCheck(controller1.enabled); // = true;
                }
                if(child.gameObject.GetComponent<IceWizardController>() != null){
                    var controller2 = child.gameObject.GetComponent<IceWizardController>();
                    enableWithCheck(controller2.enabled); //= true;
                }
                if(child.gameObject.GetComponent<FireWizardController>() != null){
                    var controller3 = child.gameObject.GetComponent<FireWizardController>();
                    enableWithCheck(controller3.enabled);
                }
                if(child.gameObject.GetComponent<RangerController>()!=null){
                    var controller4 = child.gameObject.GetComponent<RangerController>();
                    enableWithCheck(controller4.enabled);// = true;

                }
                if(child.gameObject.GetComponent<BarbarianController>()!=null){
                    var controller5 = child.gameObject.GetComponent<BarbarianController>();
                    enableWithCheck(controller5.enabled);//= true;
                }
                npcCollider = child.gameObject.GetComponent<Collider2D>();
                enableWithCheck(npcCollider.enabled);// = true;
                if(child.gameObject.GetComponent<PolygonCollider2D>()){
                    polyCollider =  child.gameObject.GetComponent<PolygonCollider2D>();
                    enableWithCheck(polyCollider.enabled);// = true;
                }else{
                    polyCollider =  npcCollider;
                    enableWithCheck(polyCollider.enabled);// = true;
		        }
            }
        }

    }

    // this method can be called by other scripts to get pooled object by its type defined as enum earlier, or simly as tag as you like
    // there's no "return" object to pool method. Simply set it as unavailable
    public GameObject GetPooledObject(EnemyType type)
    {
        // return inactive pooled object if it matches the type 
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy && pooledObjects[i].type == type)
            {
                return pooledObjects[i].gameObject;
            }
        }
        // this will be called no more active object is present, item to expand pool if required 
        foreach (EnemyPoolItem item in itemsToPool)
        {
            if (item.type == type)
            {
                if (item.expandPool)
                {
                    GameObject pickup = (GameObject)Instantiate(item.prefab);
                    pickup.SetActive(false);
                    pickup.transform.parent = this.transform;
                    pooledObjects.Add(new ExistingPoolItem(pickup, item.type));
                    return pickup;
                }
            }
        }

        // we will return null IF and only IF the type doesn't match with what is defined in the itemsToPool. 
        return null;
    }
    
    public void spawnEnemy(EnemyType enemyType){
        Debug.Log("Spawing enemy");
        Debug.Log(enemyType);
        GameObject enemy =  GetPooledObject(enemyType);
        if (enemy  !=  null){
		    //randomly choose a spawner
            int rand = Random.Range(0,4);
            enemy.transform.position  =  Spawners[rand].transform.position;
            enemy.SetActive(true);
            enemy.GetComponent<DeathHandler>().gameManager = gameManager;
        }
        else{
            Debug.Log("not enough items in the pool.");
        }
    }

}




