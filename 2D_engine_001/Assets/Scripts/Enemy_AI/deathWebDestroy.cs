using UnityEngine;
using System.Collections;

public class deathWebDestroy : MonoBehaviour {


	void Start () 
	{
		StartCoroutine(DestroyWeb());
	}

	IEnumerator DestroyWeb()
	{
		yield return new WaitForSeconds(5.0f);
		Destroy(this.gameObject);
		//Debug.Log ("deathWeb should go away");
	}
}
