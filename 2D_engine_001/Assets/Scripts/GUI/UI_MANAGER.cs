using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_MANAGER : MonoBehaviour {

	public GameObject pausePanel;

	public bool isPaused;

	// Use this for initialization
	void Start () {
		isPaused = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			PauseGame (true);
		} else {
			PauseGame (false);
		}

		if (Input.GetButtonDown ("Cancel")) {		///GETS KEY PRESS
			SwitchPause ();
		}

	}

	void PauseGame (bool state){
		if (state) {
			Time.timeScale = 0.0f;   ///GAME PAUSED   ///////
		} else {
			Time.timeScale = 1.0f;   ///// GAME RESUME //////
		}
		pausePanel.SetActive (state);
	}
		//PAUSE SWITCH
	public void  SwitchPause () {
		if(isPaused) {
			isPaused = false; 
		}
		else{
			isPaused = true;
		}
}
}
