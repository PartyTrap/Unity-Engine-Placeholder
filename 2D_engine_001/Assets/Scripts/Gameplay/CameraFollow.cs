using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{

	public GameObject playerToFollow;

	void Update()
	{
		gameObject.transform.position = new Vector3 (playerToFollow.transform.position.x, playerToFollow.transform.position.y, gameObject.transform.position.z);
	}
}
