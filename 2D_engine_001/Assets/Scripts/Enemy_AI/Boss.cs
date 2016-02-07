using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public Sprite sprite1 = null ;
	public Sprite sprite2 = null ;
	public SpriteRenderer boss = null;
	public CircleCollider2D DamageZone = null;
	public SpriteRenderer s = null; 
	public GameObject SmashAttack = null;
	public GameObject Player = null;
	public Player_State BossDamage = null;
	public bool BossAttackDecision = false;
	public int BossAttack;
	public float SmashAttackTimer;
	public float AttackStartTime;
	// Use this for initialization

	private float counter = 0f;
	void Start () {
		counter = 0;
		DamageZone = SmashAttack.GetComponent<CircleCollider2D> ();
		BossDamage = Player.GetComponent<Player_State> ();

	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter == 25) {
			boss.sprite = sprite1;
		} 
		if(counter == 50) {
			boss.sprite = sprite2;
			counter = 0;
		}
		if (!BossAttackDecision) {
			BossAttack = 0;
			BossAttackDecision = true;
			AttackStartTime = Time.time;
		}
		if(BossAttackDecision){
			switch (BossAttack) {
			case 0:
				
				s = SmashAttack.GetComponent<SpriteRenderer> ();
				s.enabled = true;
				s.color = Color.blue;
				SmashAttackTimer = 300;
				SmashAttackTimer -= (Time.time - AttackStartTime) * 100;
				if (SmashAttackTimer < 201) {
					s.color = Color.yellow;
				} 
				if (SmashAttackTimer < 51) {
					s.color = Color.red;
				}
				if (SmashAttackTimer <= 0) {
					if (DamageZone.IsTouching (Player.GetComponent<BoxCollider2D> ())) {
						BossDamage.playerHealth = BossDamage.playerHealth - 100;
					}
					s.enabled = false;
					AttackStartTime = 0;
					BossAttackDecision = false;
				}
				break;
			}
		}
	}
}
