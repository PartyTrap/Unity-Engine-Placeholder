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
	public float kb;


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
			if(OnHit.transform.position.x < this.transform.position.x )
			{
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (kb, 0f);
			}

			if(OnHit.transform.position.x > this.transform.position.x )
			{
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-kb, 0f);
			}

			if(OnHit.transform.position.y < this.transform.position.y )
			{
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, -kb);
			}

			if(OnHit.transform.position.y < this.transform.position.y )
			{
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, kb);
			}

			PS.playerHealth -= damage - PS.resistance;
			frameCounter = moveTime;
		}
	}
}
