using UnityEngine;
using System.Collections;

public class BunnyAIy : MonoBehaviour
{

	public float speed;
	public float chaseSpeed;
	public float distance;
	private float yStartPosition;
	public float viewRange;

	public float shootRange;
	public float fireDelay;
	private float z;
	public int frameCounter;
	public bulletSpawn BS;

	public int dmg = 35;

	private float playerDistance;
	public GameObject player;

	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
		yStartPosition = transform.position.y;
		frameCounter = 0;
	}
	void FixedUpdate ()
	{

		playerDistance = Vector2.Distance (player.transform.position, transform.position);

		if (playerDistance <= viewRange)
		{
			transform.LookAt(player.transform.position);
			transform.position += transform.forward * chaseSpeed * Time.deltaTime;

			z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

			transform.eulerAngles = new Vector3 (0f, 0f, z);

			if (frameCounter >= fireDelay && playerDistance <= shootRange) 
			{
				frameCounter = 0;
				BS.fireBullet (dmg);
			} 

			else 
			{
				frameCounter++;
			}
		}

		else if (playerDistance > viewRange)
		{
			if ((speed < 0 && transform.position.y < yStartPosition) || (speed > 0 && transform.position.y > yStartPosition + distance))
			{
				speed *= -1;
			}
			transform.position = new Vector2(transform.position.x, transform.position.y  + speed * Time.deltaTime);
		}	
	}
}
