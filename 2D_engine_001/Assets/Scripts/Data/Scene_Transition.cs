﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_Transition : MonoBehaviour {

	public string level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		Debug.Log ("Level Load");
		if (col.tag == "Player")
			LoadLevel ();
	}

	public void LoadLevel(){

        PlayerData.Instance.Level = level;
		SceneManager.LoadScene (level);

	}

	public void setLevel(string lvl){

		level = lvl;

	}
}
