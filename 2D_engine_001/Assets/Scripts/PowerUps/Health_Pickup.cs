using UnityEngine;
using System.Collections;

public class Health_Pickup : MonoBehaviour {

    [SerializeField] private Player_State PS;
    public int health_up;


    void Awake(){

        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        PS = temp.GetComponent<Player_State>();


    }

    void OnTriggerEnter2D( Collider2D other){

        Debug.Log("Health Up");
        if (other.gameObject.tag == "Player")
        {
            PS.playerHealth += health_up;
            DestroyMe();
        }
    }

    private void DestroyMe(){

        Destroy(this.gameObject);
        /*PLAY SOUND HERE!!!!
        ***********************
        ***********************
        ***********************/

    }


}
