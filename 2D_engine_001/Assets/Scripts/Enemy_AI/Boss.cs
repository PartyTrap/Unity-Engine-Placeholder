using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	public float knockback = 500.0f;
	public Sprite sprite1 = null ;
	public Sprite sprite2 = null ;
	public SpriteRenderer boss = null;
	public CircleCollider2D DamageZone = null; 
	public GameObject SmashAttack = null;
	public GameObject Player = null;
	public GameObject crater = null;
	public GameObject minion = null;
	public Player_State BossDamage = null;
	public bool BossAttackDecision = false;
	public bool JustAttacked = false;
	public int BossAttack;
	public float CurrentAttackTimer;
	public float CurrentAttackLimit;
	public int cooldownlimit;
	public Animator anim;
	private float cooldowncounter = 0f;
	void Start () {
		anim = this.GetComponent<Animator>();
		DamageZone = SmashAttack.GetComponent<CircleCollider2D> ();
		BossDamage = Player.GetComponent<Player_State> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!JustAttacked) {
			if (!BossAttackDecision) {
				BossAttack = Random.Range (0, 3);
				//BossAttack = 2;
				BossAttackDecision = true;
				anim.SetBool ("cooldown", false);
				anim.SetBool ("bossAttacking", true);
				//Reset the Timer for when attacks happen
				CurrentAttackTimer = 0;
			}
			if (BossAttackDecision) {
				switch (BossAttack) {
				case 0: //SmashAttack;
					CurrentAttackLimit = 300;
					CurrentAttackTimer++;

					if (CurrentAttackTimer == CurrentAttackLimit) {
						Instantiate (crater, this.transform.position, this.transform.rotation);
						if (DamageZone.IsTouching (Player.GetComponent<BoxCollider2D> ())) {
							BossDamage.playerHealth = BossDamage.playerHealth - 50;
							//Process Knockback

							Vector2 dir;
							if (Player.transform.position.x < this.transform.position.x) {
								Debug.Log ("knockback");
								dir = new Vector2 ((-Player.transform.position.x - this.transform.position.x), (Player.transform.position.y - this.transform.position.y));
							} else {
								Debug.Log ("second kb");
								dir = new Vector2 ((Player.transform.position.x - this.transform.position.x), (Player.transform.position.y - this.transform.position.y));
							}
							dir.Normalize ();

							dir.Scale (new Vector2 (knockback, knockback));
							Debug.Log (dir); 
							Player.GetComponent<Rigidbody2D> ().AddForce (dir);
					
						}
						CurrentAttackTimer = 0;
						BossAttackDecision = false;
						JustAttacked = true;
						anim.SetBool ("cooldown", true);
						anim.SetBool ("bossAttacking", false);
						cooldownlimit = 180;
					}
					break;
				case 1: //Summon Underlings
					CurrentAttackLimit = 60;

					//Create the minions
					if (CurrentAttackTimer == 0) {
						GameObject a = (Instantiate (minion, this.transform.position, this.transform.rotation)) as GameObject;
						GameObject b = (Instantiate (minion, this.transform.position, this.transform.rotation)) as GameObject;
						//Have them spawn on the left and right side of the boss
						a.transform.Translate (new Vector3 (10, 0, 0));
						b.transform.Translate (new Vector3 (-10, 0, 0));
						BunnyAI acon = a.GetComponent<BunnyAI> ();
						BunnyAI bcon = b.GetComponent<BunnyAI> ();
						acon.player = GameObject.Find ("Player");
						bcon.player = GameObject.Find ("Player");
						//Make them detect the player wherever he is in the arena
						acon.viewRange = 100; 
						bcon.viewRange = 100;
					}
					CurrentAttackTimer++;
					if (CurrentAttackTimer == CurrentAttackLimit) {
						CurrentAttackTimer = 0;
						BossAttackDecision = false;
						JustAttacked = true;
						anim.SetBool ("cooldown", true);
						anim.SetBool ("bossAttacking", false);
						cooldownlimit = 360;
					}
					break;
				case 2: //Ring of Thorns
					CurrentAttackLimit = 240;
					CurrentAttackTimer++;
					Rotator r = this.GetComponentInChildren<Rotator> ();
					r.rotate = true;
					Debug.Log ("set rotate");
					if (CurrentAttackTimer == CurrentAttackLimit) {
						r.rotate = false;
						CurrentAttackTimer = 0;
						BossAttackDecision = false;
						JustAttacked = true;
						anim.SetBool ("cooldown", true);
						anim.SetBool ("bossAttacking", false);
						cooldownlimit = 240;
					}
					break;

				}
			}
		} else {
			cooldowncounter++;
			if (cooldowncounter == cooldownlimit) {
				JustAttacked = false;
				cooldowncounter = 0;
			}
		}
	}
}
