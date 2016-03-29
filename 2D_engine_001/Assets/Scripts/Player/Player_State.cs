using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_State : MonoBehaviour {


	public float playerHealth;
	//added for health bar
	public float curHealth = 0f;
	public float maxHealth = 300;
	public GameObject HealthBar;
	public int dmg = 35;
	public int resistance = 10;
	public Animator anim;
	public Save save;
	public string level;

	public bool alive = true;


	// Use this for initialization
	void Start () {

		Debug.Log ("Start:");
		save = GameObject.FindGameObjectWithTag ("Save").GetComponent<Save> ();
		playerHealth = save.health;
		curHealth = playerHealth;

		anim = this.GetComponent<Animator> ();
		//InvokeRepeating ("looseHealth", 1f, 1f);
	}




	// Update is called once per frame
	void Update () {
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }
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
