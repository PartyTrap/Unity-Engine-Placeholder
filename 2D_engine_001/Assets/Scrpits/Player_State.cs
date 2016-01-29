using UnityEngine;
using System.Collections;

public class Player_State : MonoBehaviour {


	public float playerHealth = 100;
	public bool alive = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0) {
			alive = false;
			Destroy (this.gameObject);
		}
	}
}
