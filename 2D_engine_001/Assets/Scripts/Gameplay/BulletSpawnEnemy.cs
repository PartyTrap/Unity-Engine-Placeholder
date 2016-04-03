using UnityEngine;
using System.Collections;

public class BulletSpawnEnemy : MonoBehaviour {

	public float bulletDuration;
	public GameObject bulletPrefab;
	public float bulletSpeed;
	public int direction = 1;



	public void fireEnemyBullet(int dmg)
	{

		//Instanstiate bulletPF clone, add force, ignore collision between other bullet's and the enemy firing them
		GameObject Clone;

		Clone = (Instantiate (bulletPrefab, transform.position, transform.rotation))as GameObject;
		Physics2D.IgnoreCollision (Clone.GetComponent<Collider2D> (), GetComponentInParent<Collider2D> ());

		Destroy (Clone, bulletDuration);
		Clone.GetComponent<EnemyBulletHit>().dmg = dmg;
		Clone.GetComponent<Rigidbody2D>().AddForce (transform.up * bulletSpeed * 100.0f * direction);
	}
}
