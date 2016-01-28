using UnityEngine;
using System.Collections;

public class Enemy_State : MonoBehaviour {

	public int enemyHealth = 100;
	public int dmg = 25;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D SWORD)
	{
		enemyHealth -= dmg;

	}
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
