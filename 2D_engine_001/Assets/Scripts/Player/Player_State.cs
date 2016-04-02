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
    [SerializeField] private AudioManager audio;

	public bool alive = true;


	// Use this for initialization
	void Start () {

		Debug.Log ("Start:");
        audio = GameObject.Find("PlayerAudioManager").GetComponent<AudioManager>();
		save = GameObject.FindGameObjectWithTag ("Save").GetComponent<Save> ();
		playerHealth = save.health;
		curHealth = playerHealth;

		anim = this.GetComponent<Animator> ();
		
	}




	// Update is called once per frame
	void Update () {
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
            curHealth = maxHealth;
        }
		if (playerHealth < curHealth )
		{
			//lost health
			looseHealth();
			curHealth = playerHealth;
		}
        if (playerHealth > curHealth )
        {
            //gained
            gainHealth();
            curHealth = playerHealth;
        }
		if (playerHealth <= 0) {
			alive = false;
            Destroy(this.gameObject);
		}
	}



		

	//Decrease player health 
	void looseHealth() 
	{
		anim.SetTrigger ("Hit");
        audio.PlayPlayerDmgClip();

	}

    void gainHealth()
    {
        //play health anim
        //play sound

    }
	


}
