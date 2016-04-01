using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Death_Manager : MonoBehaviour {

	[SerializeField] private Save save;
	public Player_State PS;
	public string level;


	// Use this for initialization
	void Start () {
		save = GameObject.FindGameObjectWithTag ("Save").GetComponent<Save> ();
		PS = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_State>();
		}
	
	// Update is called once per frame
	 void Update ()
	{
		if (PS.playerHealth <= 0) {
			save.health = PS.maxHealth;
			SceneManager.LoadScene(level);

		
	}
			
}
}

