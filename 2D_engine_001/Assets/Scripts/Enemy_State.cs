using UnityEngine;
using System.Collections;

public class Enemy_State : MonoBehaviour {

	//public GameObject enemy;
	//public Transform enemyPos;
	public int enemyHealth = 100;
	public int resistance = 10;
	public float knockBack = 100.0f;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D SWORD)
	{
		enemyHealth -= SWORD.GetComponent<Sword_State>().dmg - resistance;
		//this.GetComponent<BunnyAI> ().enabled = false;
		this.GetComponent<Rigidbody2D> ().AddForce (transform.up * knockBack * -1 );

	}
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
