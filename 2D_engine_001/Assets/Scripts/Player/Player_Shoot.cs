using UnityEngine;
using System.Collections;

public class Player_Shoot : MonoBehaviour {

	public bulletSpawn BS;
	public Player_State PS;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Z)) {

			BS.fireBullet (PS.dmg);
		}
	}
}
