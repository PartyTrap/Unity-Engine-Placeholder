using UnityEngine;
using System.Collections;

public class Sword_State : MonoBehaviour {

	public int dmg = 0;
	public Player_State PS;

	// Use this for initialization
	void Start () {
		dmg = PS.dmg;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
