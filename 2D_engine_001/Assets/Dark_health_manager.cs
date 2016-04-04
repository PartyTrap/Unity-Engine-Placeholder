using UnityEngine;
using System.Collections;

public class Dark_health_manager : MonoBehaviour {
    public DarkVestige DV;
   
    public GameObject E;




    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        this.transform.eulerAngles = new Vector3 (0, 180, 0);
        this.transform.position = E.transform.position;
        this.transform.position += new Vector3(0,1.0f,0);
        if (DV.VestigeHealth <= 0 )
        {

            Delete_UI ();
            Destroy (this.gameObject.GetComponentInParent<GameObject>());
        }
    }
    public void Delete_UI(){
        Destroy (this.gameObject);
    }
}
