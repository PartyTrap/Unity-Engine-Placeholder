using UnityEngine;
using System.Collections;

public class FireBlackHole : MonoBehaviour {
	[SerializeField] private GameObject blackHoleMissile;
	// Use this for initialization
	void OnEnable(){
		GameObject proj = (Instantiate (blackHoleMissile, this.gameObject.transform.position, this.gameObject.transform.rotation)) as GameObject;
		proj.GetComponent<Rigidbody2D> ().AddForce (this.blackHoleMissile.transform.up * 1000);
	}
}
