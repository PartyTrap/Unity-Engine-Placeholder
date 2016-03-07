using UnityEngine;
using System.Collections;

public class Enemy_State : MonoBehaviour {

	//public GameObject enemy;
	//public Transform enemyPos;
	public int recentdamagedealt;
	public int enemyHealth;
	public GameObject boss;
	public int resistance = 10;
	public float knockBack = 100.0f;

	// Use this for initialization
	void Start () {
		if (this.gameObject.tag == "Boss") {
			enemyHealth = 2000;
			resistance = 5;
		} else {
			enemyHealth = 100;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("damage");
		if (col.gameObject.tag == "PlayerAttacks") {
			enemyHealth -= col.GetComponent<Sword_State> ().dmg - resistance;
			//this.GetComponent<BunnyAI> ().enabled = false;
			//Tim's Edits
			//LImiting the amount of damage the player can do to the boss within a certain number of time
			//Boss is unaffected by knockback
			if (!(this.gameObject.tag == "Boss")) {
				this.GetComponent<Rigidbody2D> ().AddForce (transform.up * knockBack * -1);
			} else {  
				recentdamagedealt = recentdamagedealt + col.GetComponent<Sword_State> ().dmg - resistance;
				if (recentdamagedealt > 200) {
					recentdamagedealt = 0;
					Rigidbody2D rb = col.GetComponentInParent<Rigidbody2D> ();
					Vector2 kb = new Vector2 ((this.transform.position.x - rb.gameObject.transform.position.x), (this.transform.position.y - rb.gameObject.transform.position.y));
					kb.Normalize ();
					kb.Scale (new Vector2 (5000.0f, 5000.0f));
					rb.AddForce (kb * -1);
					Debug.Log (kb);

				}
			}
		} else if (col.gameObject.tag == "Bullet") {
			Debug.Log ("damage");
			enemyHealth -= col.GetComponent<BulletHit> ().dmg - resistance;
			this.GetComponent<Animator> ().SetTrigger ("Hit");
		}
	}


	// Update is called once per frame
	void Update () {
		//Destroy Enemy upon its HP reaching 0 or below
		if (enemyHealth <= 0) {
			if (this.gameObject.tag == "Boss") {
				Destroy (boss);
			}
			Destroy (this.gameObject);
		}
		//Change resistance of Boss enemy depending on HP level
		if (this.gameObject.tag == "Boss") {
			

			//At Half HP
			if (enemyHealth < 1001) {
				resistance = 5;
			}
			//At Quarter HP
			if (enemyHealth < 501) {
				resistance = 10;
			}
			//At Critical Condition 
			if (enemyHealth < 200) {
				resistance = 15;
			}
		}
	}
}
