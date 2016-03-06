using UnityEngine;
using System.Collections;

public class ThornHit : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<Player_State> ().playerHealth -= 10;
		}
		Destroy (this.gameObject);
	}
}
