using UnityEngine;
using System.Collections;

public class Scale_Health : MonoBehaviour {

	private RectTransform RT;
	public Player_State PS;
	private float max;
	private float ratio;

	// Use this for initialization
	void Start () {
		RT = this.GetComponent<RectTransform> ();
		max = PS.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		ratio = PS.playerHealth / max;
		Debug.Log (ratio);
		RT.localScale = new Vector3(ratio,1 ,1);
	}
}
