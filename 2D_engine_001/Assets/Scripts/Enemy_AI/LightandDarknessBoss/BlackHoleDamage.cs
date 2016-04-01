using UnityEngine;
using System.Collections;

public class BlackHoleDamage : MonoBehaviour {
	public bool blackHole = false;
	public int lifecounter;
	public GameObject player;
	public GameObject missile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
		void OnTriggerStay2D(Collider2D c){
			if(c.gameObject.tag == "Player"){
				c.gameObject.GetComponent<Player_State> ().playerHealth -= 1;
			}
		}
		void Update(){
			if (blackHole) {
				lifecounter++;
				player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<Rigidbody2D> ().AddForce ((missile.transform.position - player.transform.position).normalized * 9000 * Time.smoothDeltaTime);
				if (lifecounter == 420) {
					Destroy (missile);
				}
			}
		}
}
