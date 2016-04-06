using UnityEngine;
using System.Collections;

public class Boss2Roll : MonoBehaviour {
	public bool stop = false;
	public bool battleMode = false;
	public bool delay = false;
	public int delaycounter;
	public int spawncount;
	public int stops;
	public int battleModeTimer = 0;
	public int battleModeLimit = 100;
	public BossAttacks attackscript = null;
	public Collider2D bossCollider;
	public GameObject player;
	public GameObject spawner;
	public GameObject minion;
	public GameObject bossSprite;
	public Roll roll;
	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody2D> ().AddForce (this.transform.up * -50);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (!delay) {
			if (!battleMode) {
					switch (stops) {
					case 0:
						this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 0);
						break;
					case 1:
						this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 90);
						break;
					case 2:
						this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 180);
						break;
					case 3:
						this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 270);
						break;
					}
					this.gameObject.GetComponent<Rigidbody2D> ().AddForce (this.transform.up * -1900);
					spawncount++;
					if (spawncount == 60) {
						spawncount = 0;
						Instantiate (minion, spawner.transform.position, spawner.transform.rotation);
					}
			}
			if (this.gameObject.GetComponent<Rigidbody2D> ().isKinematic) {
				battleMode = true;
				roll.enabled = false;
				switch (stops) {
				case 0:
					this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 0);
					break;
				case 1:
					this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 90);
					break;
				case 2:
					this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 180);
					break;
				case 3:
					this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 270);
					break;
				}
			}
			if (battleMode) {
				battleModeTimer++;
				attackscript.enabled = true;
				if (battleModeTimer == battleModeLimit) {
					battleModeTimer = 0;
					battleMode = false;
					attackscript.enabled = false;
					player.GetComponent<Rigidbody2D> ().isKinematic = true;
					bossSprite.GetComponent<CircleCollider2D> ().enabled = false;
					switch (stops) {
					case 0:
						player.GetComponent<Rigidbody2D> ().isKinematic = false;
						player.GetComponent<Rigidbody2D> ().AddForce (Vector3.down * 20000);
						player.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * 30000);
						delay = true;
						break;
					case 1:
						player.GetComponent<Rigidbody2D> ().isKinematic = false;
						player.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * 20000);
						player.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 30000);
						delay = true;
						break;
					case 2:
						player.GetComponent<Rigidbody2D> ().isKinematic = false;
						player.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 20000);
						player.GetComponent<Rigidbody2D> ().AddForce (Vector3.left * 30000);
						delay = true;
						break;
					case 3:
						player.GetComponent<Rigidbody2D> ().isKinematic = false;
						player.GetComponent<Rigidbody2D> ().AddForce (Vector3.left * 20000);
						player.GetComponent<Rigidbody2D> ().AddForce (Vector3.down * 30000);
						delay = true;
						break;
					}

				}
			}
		} else {
			delaycounter++;
			//Rappel up
			if (delaycounter > 1 && delaycounter < 60) {
				switch (stops) {
				case 0:
					bossSprite.transform.Translate (new Vector3 (0.0f, 1.0f, 0.0f));
					break;
				case 1:
					bossSprite.transform.Translate (new Vector3 (1.0f, 0.0f, 0.0f));
					break;
				case 2:
					bossSprite.transform.Translate (new Vector3 (0.0f, -1.0f, 0.0f));
					break;
				case 3:
					bossSprite.transform.Translate (new Vector3 (-1.0f, 0.0f, 0.0f));
					break;
				}
			}
			//Change the Boss's position
			if (delaycounter == 60) {
				switch(stops){
				case 0:
					this.transform.position = new Vector3 (1.74f, -41.86f, 0.0f);
					break;
				case 1:
					this.transform.position = new Vector3 (40.12f, -41.26f, 0.0f);
					break;
				case 2:
					this.transform.position = new Vector3 (39.22f, -2.05f, 0.0f);
					break;
				case 3:
					this.transform.position = new Vector3 (-0.51f, 2.23f, 0.0f);
					break;
				}
			}
			//Rappel down
			if (delaycounter < 120 && delaycounter > 60) {
				switch (stops) {
				case 0:
					bossSprite.transform.Translate (new Vector3 (0.0f, -1.0f, 0.0f));
					break;
				case 1:
					bossSprite.transform.Translate (new Vector3 (-1.0f, 0.0f, 0.0f));
					break;
				case 2:
					bossSprite.transform.Translate (new Vector3 (0.0f, 1.0f, 0.0f));
					break;
				case 3:
					bossSprite.transform.Translate (new Vector3 (1.0f, 0.0f, 0.0f));
					break;
				}
			}
			//End of Rappel
			if (delaycounter == 120) {
				delaycounter = 0;
				delay = false;
				roll.enabled = true;
				switch (stops) {
				case 0:
					
					this.transform.eulerAngles = new Vector3 (0, 0, 90);
					this.transform.position = new Vector3 (1.74f, -41.86f, 0.0f);
					this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
					break;
				case 1:
					
					this.transform.eulerAngles = new Vector3 (0, 0, 180);
					this.transform.position = new Vector3 (40.12f, -41.26f, 0.0f);
					this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
					break;
				case 2:
					
					this.transform.eulerAngles = new Vector3 (0, 0, 270);
					this.transform.position = new Vector3 (39.22f, -2.05f, 0.0f);
					this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
					break;
				case 3:
					
					this.transform.eulerAngles = new Vector3 (0, 0, 0);
					this.transform.position = new Vector3 (0.51f, -2.23f, 0.0f);
					this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
					break;
				}
				bossSprite.GetComponent<CircleCollider2D> ().enabled = true;
				stops++;
				if (stops == 4) {
					stops = 0;
				}
			}

		}
	}

}
