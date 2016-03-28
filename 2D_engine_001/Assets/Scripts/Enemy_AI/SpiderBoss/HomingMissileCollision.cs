using UnityEngine;
using System.Collections;

public class HomingMissileCollision : MonoBehaviour {
	public GameObject missile;
	void OnCollisionEnter2D(Collision2D c){
		Destroy (missile);
	}
}
