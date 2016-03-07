using UnityEngine;
using System.Collections;

public class GUImanager : MonoBehaviour {

	[SerializeField]Player_State ps;
	private float dmg;
	private float currHealth;
	private float move;

	// Use this for initialization
	void Start () {
		currHealth = ps.playerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		dmg = currHealth - ps.playerHealth;
		GetComponent<RectTransform> ().Translate (new Vector3 (-dmg, 0, 0));
	}
}
