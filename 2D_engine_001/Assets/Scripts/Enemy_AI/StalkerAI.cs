using UnityEngine;
using System.Collections;

public class StalkerAI : MonoBehaviour {

	public float speed;
	public float rotateSpeed;
	public float distanceMax;
	public float distanceMin;
	public float viewRange;

	public float shootRange;
	public float fireDelay;
	private float z;
	public int frameCounter;
	private BulletSpawnEnemy BS;
    [SerializeField] private EnemyAudioManager audio;

	public int dmg = 35;

	private float playerDistance;
	private GameObject player;

	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
        audio = GameObject.Find("EnemyAudioManager").GetComponent<EnemyAudioManager>();
		BS = this.GetComponent<BulletSpawnEnemy> ();
		frameCounter = 0;
		shootRange = distanceMax + 1;
	}
	
	// Update is called once per frame
	void Update () {
		playerDistance = Vector2.Distance (player.transform.position, transform.position);

		if (playerDistance <= viewRange) {

			transform.LookAt (player.transform.position); // face player.

			transform.position += transform.forward * speed * Time.deltaTime; // move forewards

			z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

			transform.eulerAngles = new Vector3 (0f, 0f, z);

			if (playerDistance < distanceMin && speed>0) {
				speed *= -1; // reverse direction if too close
			}
			else if (playerDistance > distanceMax) {
				speed = Mathf.Abs (speed); // move towards player if too far
			}

			if (frameCounter >= fireDelay && playerDistance <= shootRange) 
			{
				frameCounter = 0;
				BS.fireEnemyBullet (dmg);
                audio.PlayStalkerClip();
			} 
			else 
			{
				frameCounter++;
			}

			Vector3 zCorrect = new Vector3 (transform.position.x, transform.position.y, 0f);
			transform.position = zCorrect; 
			//fixxes the thing where this and only this enemy learned how to fly away and escape fights.
		}	
	}
}
