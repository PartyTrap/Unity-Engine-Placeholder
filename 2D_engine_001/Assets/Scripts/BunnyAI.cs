using UnityEngine;
using System.Collections;

public class BunnyAI : MonoBehaviour 
{
 	
	public float speed;
	public float chaseSpeed;
	public float distance;
	private float xStartPosition;
	public float viewRange;
	public float shootRange;
	public float fireDelay;
	private float z;

	private float frameCounter;
	private float playerDistance;
	public GameObject player;

	public bulletSpawn BS;

	void Start () 
	{
		xStartPosition = transform.position.x;
		frameCounter = 0;
	}
	void FixedUpdate ()
	{

		playerDistance = Vector2.Distance (player.transform.position, transform.position);
		//Rigidbody2D.constraints.FreezePosition;

		if (playerDistance <= viewRange)
		{
			transform.LookAt(player.transform.position);
			transform.position += transform.forward * chaseSpeed * Time.deltaTime;


			z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0f, 0f, z);

			if (frameCounter >= fireDelay && playerDistance <= shootRange) 
			{
				frameCounter = 0;
				BS.fireBullet ();
			} 

			else 
			{
				frameCounter++;
			}
		}
			
		else if (playerDistance > viewRange)
		{
			if ((speed < 0 && transform.position.x < xStartPosition) || (speed > 0 && transform.position.x > xStartPosition + distance))
			{
				speed *= -1;
			}
			transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
		}	
	}
}
