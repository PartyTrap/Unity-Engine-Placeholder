using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	public int bossHealth;
	public Enemy_State status;
	public Sprite sprite1 = null ;
	public Sprite sprite2 = null ;
	public SpriteRenderer boss = null; 
	public GameObject SmashAttack = null;
	public GameObject crater = null;
	public GameObject minion = null;
	public Vinepull vine;
	public bool BossAttackDecision = false;
	public bool JustAttacked = false;
	public bool dying = false;
	public int BossAttack;
	public float CurrentAttackTimer;
	public float CurrentAttackLimit;
	public int cooldownlimit;
	public Animator anim;
	private float cooldowncounter = 0f;
	public int deathcounter;
	void Start () {
		anim = this.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		bossHealth = status.enemyHealth;
		if (bossHealth <= 0) {
			dying = true;
			anim.SetBool ("dying", true);
		}
		if (dying) {
			deathcounter++;
			if (deathcounter == 60) {
				Destroy (this.gameObject);
			}
		}
		if (!dying) {
			if (!JustAttacked) {
				if (!BossAttackDecision) {
					BossAttack = Random.Range (0, 3);
					//BossAttack = 0;
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
						if (CurrentAttackTimer < 240) {
							vine.enabled = true;
						}
						if (CurrentAttackTimer == 280) {
							vine.enabled = false;
						}
						if (CurrentAttackTimer == CurrentAttackLimit) {
							SmashAttack.SetActive (true);
							Instantiate (crater, this.transform.position, this.transform.rotation);
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
							//acon.player = GameObject.FindWithTag ("Player");
							//bcon.player = GameObject.FindWithTag ("Player");
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
				if (cooldowncounter == 2) {
					SmashAttack.SetActive (false);
				}
				if (cooldowncounter == cooldownlimit) {
					JustAttacked = false;
					cooldowncounter = 0;
				}
			}
		}
	}
}
