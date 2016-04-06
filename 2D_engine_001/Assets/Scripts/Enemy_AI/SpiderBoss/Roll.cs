using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour {

    [SerializeField] private Boss2Roll BTR;

	void OnCollisionEnter2D(Collision2D c){
		
        if (c.gameObject.tag == "Player" && BTR.battleMode == false) {
			c.gameObject.GetComponent<Player_State> ().playerHealth = 0;
		}
	}
}
