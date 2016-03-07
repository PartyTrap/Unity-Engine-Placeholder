using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {

	public Player_State PS;
	public float health;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		PS = GameObject.Find ("Player").GetComponent<Player_State>();
	}
	
	// Update is called once per frame
	void Update () {
		health=PS.playerHealth;
	}
}
