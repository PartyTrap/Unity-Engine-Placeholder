using UnityEngine;
using System.Collections;

public class HomingLaserPointCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<Player_State> ().playerHealth -= 30;
		}
	}
	void OnTriggerStay2D(Collider2D c){
		if (c.gameObject.tag == "Player"){
			c.gameObject.GetComponent<Player_State> ().playerHealth -= 1;
		}
	}
}
