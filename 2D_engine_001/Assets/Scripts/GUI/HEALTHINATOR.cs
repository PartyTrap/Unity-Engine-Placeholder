using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HEALTHINATOR : MonoBehaviour {

	public Player_State PS;
	private Text Health;

	// Use this for initialization
	void Start () {
		Health = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		Health.text = "Health : " + PS.playerHealth;
	}
}
