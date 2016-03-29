using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Death_Manager : MonoBehaviour {


	public Player_State PS;
	public string level;


	// Use this for initialization
	void Start () {

		}
	
	// Update is called once per frame
	 void Update ()
	{
		if (PS.curHealth <= 0) {
			SceneManager.LoadScene(level);

		
	}
			
}
}

