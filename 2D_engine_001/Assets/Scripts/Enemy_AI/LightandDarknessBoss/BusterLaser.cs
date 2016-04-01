using UnityEngine;
using System.Collections;

public class BusterLaser : MonoBehaviour {
	public bool active = false;
	// Use this for initialization
	void OnEnable(){
		active = true;
	}
	void OnDisable(){
		active = false;
	}
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D c) {
		if (active) {
			if (c.gameObject.tag == "Player") {
				c.gameObject.GetComponent<Player_State> ().playerHealth -= 1;
			}
		}
	}
}