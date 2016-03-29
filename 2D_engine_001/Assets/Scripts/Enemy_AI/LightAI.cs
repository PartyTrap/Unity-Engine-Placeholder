using UnityEngine;
using System.Collections;

public class LightAI : MonoBehaviour {

	public float speed;
	public float viewRange;
	public float shootRange;
	public float fireDelay;
	private float z;

	private float frameCounter;
	private float playerDistance;
	public GameObject player;
	public GameObject shadow;

	public int dmg = 35;

	public bulletSpawn BS;

	private float m;
	private float b;
	private float point;
	private float pointx;
	private float pointy;
	private Vector3 target;

	private Rigidbody2D rb;

	void Start () {
		frameCounter = 0;

		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		playerDistance = Vector2.Distance (player.transform.position, transform.position);

		if (playerDistance <= viewRange && shadow != null) {
			transform.LookAt (player.transform.position);

			m = (shadow.transform.position.y - player.transform.position.y) / (shadow.transform.position.x - player.transform.position.x);
			b = shadow.transform.position.y - (m * shadow.transform.position.x);
			point = Random.value+1;

			if (player.transform.position.x - shadow.transform.position.x > 0) {
				target = new Vector2 ((player.transform.position.x + point), (m * (player.transform.position.x + point) + b));
			}
			else if (player.transform.position.x - shadow.transform.position.x <= 0) {
				target = new Vector2 ((player.transform.position.x - point), (m * (player.transform.position.x - point) + b));
			}


			if (Mathf.Abs(player.transform.position.y - target.y) > 3) {
				target.y = player.transform.position.y + (m*0.01f);
			}

			Vector2 velocity = new Vector2 ((target.x - transform.position.x) * speed, (target.y - transform.position.y) * speed);
			rb.AddForce (velocity, ForceMode2D.Force);

			z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0f, 0f, z);

			if (frameCounter >= fireDelay && playerDistance <= shootRange) {
				frameCounter = 0;
				BS.fireBullet (dmg);
			} else {
				frameCounter++;
			}

		} else if (shadow != null) {
		
			pointx = Random.value * Random.Range (-2.0f, 2.0f);
			pointy = Random.value * Random.Range (-2.0f, 2.0f);
			Vector2 velocity = new Vector2 ((transform.position.x - (shadow.transform.position.x + pointx)) * speed, (transform.position.y - shadow.transform.position.y + pointy) * speed);
			rb.AddForce (-velocity, ForceMode2D.Force);
		} 

		else {

			transform.LookAt (player.transform.position);

			Vector2 velocity = new Vector2 ((player.transform.position.x - transform.position.x) * speed, (player.transform.position.y - transform.position.y) * speed);
			rb.AddForce (-velocity, ForceMode2D.Force);

			z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0f, 0f, z);

			if (frameCounter >= fireDelay && playerDistance <= shootRange) {
				frameCounter = 0;
				BS.fireBullet (dmg);
			} else {
				frameCounter++;
			}

		}
	
	}
}
