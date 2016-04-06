using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {
	private int counter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter == 60) {
			Destroy (this.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Missile") {
			Destroy (this.gameObject);
		}
	}
}
