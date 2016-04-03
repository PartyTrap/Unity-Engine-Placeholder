using UnityEngine;
using System.Collections;

public class deathWebDestroy : MonoBehaviour {

    private Player_Move PM;

	void Start () 
	{
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Move>();
		StartCoroutine(DestroyWeb());
	}

	IEnumerator DestroyWeb()
	{
		yield return new WaitForSeconds(5.0f);
       
        PM.Speed = PM.maxSpeed;
		Destroy(this.gameObject);
		//Debug.Log ("deathWeb should go away");
	}
}
