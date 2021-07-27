using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellDefensePassive : MonoBehaviour
{
	public GameConstants gameConstants;
	private GameObject myShell;
    private Vector2 shellPosition;
	private Vector2	shellDirection;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
    // Start is called before the first frame update
    void Start()
    {
        shellDirection = GetComponent<M00ks1Controller>().faceDirection;
        shellPosition = new Vector2(transform.position.x, transform.position.y) - shellDirection*gameConstants.shellDistance;
        myShell = Instantiate(gameConstants.shell,shellPosition,transform.rotation);
		myShell.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
		if (GetComponent<UpgradeManager>().shellDefense){
		myShell.SetActive(true);
		shellDirection = GetComponent<M00ks1Controller>().faceDirection;
        myShell.transform.position = new Vector2(transform.position.x, transform.position.y) - shellDirection*gameConstants.shellDistance;
		
		Vector2 dir = (shellDirection).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		myShell.transform.rotation = angle;} else {
			myShell.SetActive(false);
		}
    } 
}
