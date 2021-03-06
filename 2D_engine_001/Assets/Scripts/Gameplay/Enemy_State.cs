﻿using UnityEngine;
using System.Collections;

public class Enemy_State : MonoBehaviour {

	//public GameObject enemy;
	//public Transform enemyPos;
	public int recentdamagedealt;
	public int enemyHealth;
	public GameObject boss;
    public GameObject health;
    public int DropChance = 1;
	private int resistance = 10;
	public float knockBack = 100.0f;
    public float max;
    [SerializeField]private EnviroAudioManager audio;


	//Spiderling jr PF spawn & mommaspider death anim pf
	public GameObject spiderlingJR;
	public GameObject spiderDeathPF;

	// Use this for initialization
	void Start () {
        audio = GameObject.Find("EnviroAudioManager").GetComponent<EnviroAudioManager>();
		if (this.gameObject.tag == "Boss") {
			
		} else {
			enemyHealth = 100;
            max = enemyHealth;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("damage");
		if (col.gameObject.tag == "PlayerAttacks") {
			enemyHealth -= col.GetComponent<Sword_State> ().dmg - resistance;
			this.GetComponent<Animator> ().SetTrigger ("Hit");
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

				}
			}
		} else if (col.gameObject.tag == "Bullet") {
			enemyHealth -= col.GetComponent<BulletHit> ().dmg - resistance;
			this.GetComponent<Animator> ().SetTrigger ("Hit");
		}
	}


	// Update is called once per frame
	void Update () {
		if (enemyHealth > 0) {
			this.gameObject.SetActive (true);
		}
		//Destroy Enemy upon its HP reaching 0 or below
		if (enemyHealth <= 0) {
			//this is for the tree
			if (this.gameObject.tag == "Boss" || this.gameObject.tag == "Vestige") {
				//set the health to 0, boss's scripts will handle its death
				enemyHealth = 0;
			} else {

				//If obj is mommaSpider, spawn spider JRs on death
				if (this.gameObject.tag == "MommaSpider") {
					GameObject spider;
					GameObject spider2;

					spider = (Instantiate (spiderlingJR, this.transform.position, this.transform.rotation))as GameObject;
					float spiPosY = spider.transform.position.y;
					spiPosY += 0.5f;

					spider2 = (Instantiate (spiderlingJR, this.transform.position, this.transform.rotation))as GameObject;
					float spi2PosY = spider2.transform.position.y;
					spi2PosY -= 0.5f;

					GameObject explosionObject = Instantiate (this.spiderDeathPF) as GameObject;
					explosionObject.transform.position = this.transform.position;
				}
				DestroyMe ();
			}
		}

		//Change resistance of Boss enemy depending on HP level
		if (this.gameObject.tag == "Boss") {
			

			//At Half HP
			if (enemyHealth < 1001) {
				resistance = 5;
			}
			//At Quarter HP
			if (enemyHealth < 501) {
				//resistance = 10;
			}
			//At Critical Condition 
			if (enemyHealth < 200) {
				//resistance = 15;
			}
		}
	}

    private void DestroyMe(){

        audio.PlayEnemyDeathClip();
        Destroy(this.gameObject);
        int rand = Random.Range(1, DropChance);
        if (rand == 1)
        {
            GameObject clone;
            clone = (Instantiate(health, this.transform.position, this.transform.rotation)) as GameObject;
            clone.transform.eulerAngles = new Vector3(0,0,90);
        }
            


    }
	public void setResist(int newRes){
		resistance = newRes;
	}
	public int getResist(){
		return resistance;
	}
}
