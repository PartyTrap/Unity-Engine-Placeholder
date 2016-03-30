using UnityEngine;
using System.Collections;

public class Enemy_Scale_Health : MonoBehaviour {

	private RectTransform RT;
	public Enemy_State ES;
	private float max;
	private float ratio;



	// Use this for initialization
	void Start () {
		RT = this.GetComponent<RectTransform> ();
		max = ES.enemyHealth;
	
	}
	
	// Update is called once per frame
	void Update () {

		ratio = ES.enemyHealth / ES.max;
		Debug.Log (ratio);
		RT.localScale = new Vector3(ratio,1 ,1);

	
	}
}
