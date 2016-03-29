using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour {

	// Use this for initialization
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<Player_State> ().playerHealth -= 1;
		}
	}

}
