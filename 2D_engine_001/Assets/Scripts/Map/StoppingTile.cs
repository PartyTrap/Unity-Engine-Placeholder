using UnityEngine;
using System.Collections;

public class StoppingTile : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D c){
		if (c.gameObject.tag == "Boss") {
			c.gameObject.GetComponentInParent<Rigidbody2D> ().isKinematic = true;
		}
	}
}
