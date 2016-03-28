using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D c){
		
		if (c.gameObject.tag == "Player") {
			Debug.Log ("Hit");
			c.gameObject.GetComponent<Player_State> ().playerHealth = 0;
		}
	}
}
