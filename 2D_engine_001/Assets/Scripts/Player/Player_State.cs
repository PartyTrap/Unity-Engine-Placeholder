using UnityEngine;
using System.Collections;

public class Player_State : MonoBehaviour {


	public float playerHealth = 100f;
	//added for health bar
	public float curHealth = 0f;
	public GameObject HealthBar;
	public int dmg = 35;
	public int resistance = 10;
	public Animator anim;
	public Save save;

	public bool alive = true;

	void Awake(){

		playerHealth = save.health; 

	}
	// Use this for initialization
	void Start () {
		
		curHealth = playerHealth;

		anim = this.GetComponent<Animator> ();
		//InvokeRepeating ("looseHealth", 1f, 1f);
	}




	// Update is called once per frame
	void Update () {
		if (playerHealth < curHealth )
		{
			
			looseHealth();
			curHealth = playerHealth;
		}
		if (playerHealth <= 0) {
			alive = false;
			Destroy (this.gameObject);
		}
	}
		

	//Decrease player health 
	void looseHealth() 
	{
		anim.SetTrigger ("Hit");
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
