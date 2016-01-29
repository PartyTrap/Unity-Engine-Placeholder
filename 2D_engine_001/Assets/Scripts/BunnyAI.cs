using UnityEngine;
using System.Collections;

public class BunnyAI : MonoBehaviour 
{
 	
	public float speed;
	public float chaseSpeed;
	public float distance;
	private float xStartPosition;
	public float viewRange;

	private float playerDistance;
	public GameObject player;

	void Start () 
	{
		xStartPosition = transform.position.x;
	}
	void FixedUpdate ()
	{

		playerDistance = Vector2.Distance (player.transform.position, transform.position);
		//Rigidbody2D.constraints.FreezePosition;

		if (playerDistance <= viewRange)
		{
			transform.LookAt(player.transform.position);
			transform.position += transform.forward * chaseSpeed * Time.deltaTime;

			transform.eulerAngles = new Vector3 (0f, 0f, transform.eulerAngles.z);
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
