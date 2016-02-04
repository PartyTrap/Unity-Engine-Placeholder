using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Death_Manager : MonoBehaviour {

	public GameObject deathPanel;
	public float playerHealth;
	public bool isDead;
	// Use this for initialization
	void Start () {
		isDead = false;
		}
	
	// Update is called once per frame
	void Update () {
		if (isDead){
			Death(true);
		} else {
			Death(false);
		}
		if  (playerHealth <= 0f){
			switchDeath();
		}
	}

	void Death (bool state){
		if(state){
			Time.timeScale = 0.0f; ///////DEAD////////
		} else { 
			Time.timeScale = 1.0f; /////ALIVE//////
		}
		deathPanel.SetActive (state);
}

	/////Death switch
	public void switchDeath(){
		if(isDead){
			isDead = false;
		}
		else{
			isDead = true;
		}
	}
}