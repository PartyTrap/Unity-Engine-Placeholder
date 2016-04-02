using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour {
	[SerializeField] private GameObject player;
	// Update is called once per frame
	void Update(){
		transform.rotation = Quaternion.LookRotation (Vector3.forward, (player.transform.position - this.gameObject.transform.position)* -1);
	}
	public void Move () {
		this.gameObject.transform.RotateAround (player.transform.position, Vector3.forward, 0.1f);
	}
}
