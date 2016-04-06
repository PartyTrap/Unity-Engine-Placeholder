using UnityEngine;
using System.Collections;

public class BossAttacks : MonoBehaviour {
	public int counter;
	public int attack;
	public bool onCoolDown = false;
	public bool attacking = false;
	public int coolDownTimer;
	public int coolDownLimit = 30;
	public int attackTimer;
	public int attackLimit;
	public FireMissiles missileScript;
	public FireGuns gunScipt;
	public GameObject flameScript;
	// Use this for initialization
	void Start () {
	
	}
	void OnDisable(){
		missileScript.enabled = false;
		gunScipt.enabled = false;
		flameScript.SetActive (false);
	}

	
	// Update is called once per frame
	void Update () {
		if (!onCoolDown) {
			if (!attacking) {
				attack = Random.Range (0, 3);
				switch (attack) {
				case 0: //Fire Missiles
					attackLimit = 90;
					attackTimer = 0;
					missileScript.enabled = true;
					attacking = true;
					break;
				case 1: //Fire guns
					attackLimit = 60;
					attackTimer = 0;
					gunScipt.enabled = true;
					attacking = true;
					break;
				case 2: //Ignite Flamethrower
					attackLimit = 150;
					attackTimer = 0;
					flameScript.SetActive (true);
					attacking = true;
					break;
				}
			} else {
				attackTimer++;
				if (attackTimer == attackLimit) {
					switch (attack) {
					case 0:
						missileScript.enabled = false;
						attacking = false;
						onCoolDown = true;
						break;
					case 1:
						gunScipt.enabled = false;
						attacking = false;
						onCoolDown = true;
						break;
					case 2:
						flameScript.SetActive (false);
						attacking = false;
						onCoolDown = true;
						break;
					}
				}
			}
		} else {
			counter++;
			if (counter == 120) {
				counter = 0;
				onCoolDown = false;
			}
		}
	}
}
