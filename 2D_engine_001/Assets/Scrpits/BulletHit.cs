using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{ 

	void Start ()
	{
		
	}
	//on collision destroy the bullet Clone
	void OnCollisionEnter2D(Collision2D OnHit)
	{
		Destroy(gameObject);
	}
}

