using UnityEngine;
using System.Collections;

public class Player_State : MonoBehaviour {


	public float playerHealth = 100f;
	//added for health bar
	public float curHealth = 0f;
	public GameObject HealthBar;

	public bool alive = true;


	// Use this for initialization
	void Start () {
		curHealth = playerHealth;
		InvokeRepeating ("looseHealth", 1f, 1f);
	}



	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0) {
			alive = false;
			Destroy (this.gameObject);
		}

	}
	//Decrease player health 
	void looseHealth() 
	{
		float healthLoss = curHealth / playerHealth;
		setHealthBar(healthLoss);
	}
	//Decrease HealthBar
	public void setHealthBar (float myHealth)
	{
		//myHealth value is from 0-1..
		HealthBar.transform.localScale = new Vector3(myHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
	}


}
