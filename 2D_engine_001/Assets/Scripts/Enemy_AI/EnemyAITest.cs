using UnityEngine;
using System.Collections;

public class EnemyAITest : MonoBehaviour 
{
	private Transform player;
	public GameObject bulletPrefab;

	public bulletSpawn BS;

	public float viewRange;
	private float playerDistance;
	public int frameCounter;
	public float fireDelay;
	public float bulletSpeed; 
	private float z;

	public int dmg = 35;


	void Start()
	{
		player = GameObject.FindWithTag ("Player").GetComponent<Transform>();
		frameCounter = 0;
	}

	void Update()
	{
		//Increase frameCounter every update unless frameCounter >= firedelay and player is within range, call firebullet()
		if (frameCounter >= fireDelay && playerDistance <= viewRange) 
		{
			frameCounter = 0;
			BS.fireBullet (dmg);
		} 

		else 
		{
			frameCounter++;
		}
			
	}

	void FixedUpdate () 
	{
		//Enemy Rotation which follows the player's position when they're within viewRange
		playerDistance = Vector2.Distance (player.position, transform.position);
		if (playerDistance <= viewRange) 
		{
			z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0.0f, 0.0f, z);

		}
	}



	/*void fireBullet()
	{
		//Instanstiate bulletPF clone, add force, ignore collision between other bullet's and the enemy firing them
		GameObject Clone;

		Clone = (Instantiate (bulletPrefab, transform.position, transform.rotation))as GameObject;
		Physics2D.IgnoreCollision (Clone.GetComponent<Collider2D> (), GetComponent<Collider2D> ());

		Clone.GetComponent<Rigidbody2D>().AddForce (transform.up * bulletSpeed * 100.0f);
	}
	*/
}
