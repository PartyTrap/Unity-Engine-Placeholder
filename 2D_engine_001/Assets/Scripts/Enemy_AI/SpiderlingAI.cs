using UnityEngine;
using System.Collections;

public class SpiderlingAI : MonoBehaviour {

	public float speed;
	public float viewRange;
	public float moveTime;
	public float waitTime;

	private float z;

	public int damage = 25;

	private float playerDistance;
	private GameObject Player;
	private Player_State PS;

	public float frameCounter;


	void Start () 
	{
		frameCounter = 0;
		Player = GameObject.FindWithTag ("Player");
		PS = Player.GetComponent<Player_State> ();
	}

	void Update ()
	{
		playerDistance = Vector2.Distance (Player.transform.position, this.transform.position);

		if (playerDistance < viewRange) 
		{
			this.transform.LookAt (Player.transform.position);
			frameCounter++;
		}

		if (frameCounter < moveTime) 
		{
			this.GetComponent<Rigidbody2D>().AddForce (transform.forward * speed * 10.0f);
		} 

		else if (frameCounter > moveTime && frameCounter <= moveTime + waitTime)
		{

		} 

		else if (frameCounter > moveTime + waitTime) 
		{
			frameCounter = 0;
		}

		z = Mathf.Atan2 ((Player.transform.position.y - transform.position.y), (Player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3 (0.0f, 0.0f, z);
	}

	void OnCollisionEnter2D(Collision2D OnHit)
	{
		if (OnHit.gameObject.tag == "Player") 
		{
			PS.playerHealth -= damage - PS.resistance;
			frameCounter = moveTime;

			Vector2 kb = new Vector2 ((this.transform.position.x - (Player.gameObject.transform.position.x + 1.0f)), (this.transform.position.y - (Player.gameObject.transform.position.y + 1.0f)));
			kb.Normalize ();
			kb.Scale (new Vector2 (500.0f, 500.0f));

			this.GetComponent<Rigidbody2D>().AddForce (kb * -1.0f);
			Debug.Log (kb);
		}
	}
}
