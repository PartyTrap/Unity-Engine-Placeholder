using UnityEngine;
using System.Collections;

public class Rough_Terrain : MonoBehaviour {

    void OnTriggerExit2D(Collider2D col){

        if (col.gameObject.tag == "Player")
        {
            Player_Move PM = col.GetComponentInParent<Player_Move>();
            PM.Speed = PM.maxSpeed;

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player_Move PM = col.GetComponentInParent<Player_Move>();
            PM.Speed = PM.maxSpeed / 10;

        }
    }
}
