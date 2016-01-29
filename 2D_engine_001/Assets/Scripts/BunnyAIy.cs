using UnityEngine;
using System.Collections;

public class BunnyAIy : MonoBehaviour
{

	public float speed;
	public float chaseSpeed;
	public float distance;
	private float yStartPosition;
	public float viewRange;

	private float playerDistance;
	public GameObject player;

	void Start () 
	{
		yStartPosition = transform.position.y;
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
			if ((speed < 0 && transform.position.y < yStartPosition) || (speed > 0 && transform.position.y > yStartPosition + distance))
			{
				speed *= -1;
			}
			transform.position = new Vector2(transform.position.x, transform.position.y  + speed * Time.deltaTime);
		}	
	}
}
