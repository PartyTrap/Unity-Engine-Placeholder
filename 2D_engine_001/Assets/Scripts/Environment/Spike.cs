using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Rigidbody2D rb = col.GetComponentInParent<Rigidbody2D>();
            Vector2 kb = new Vector2((this.transform.position.x - rb.gameObject.transform.position.x), (this.transform.position.y - rb.gameObject.transform.position.y));
            kb.Normalize();
            kb.Scale(new Vector2(3000.0f, 3000.0f));
            rb.AddForce(kb * -1);
            col.GetComponent<Player_State>().playerHealth -= 10;
        }
    }
}
