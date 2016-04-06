using UnityEngine;
using System.Collections;

public class Final_Boss_Scale_Health : MonoBehaviour {

    private RectTransform RT;
    public BossCore BC;
    private float max;
    private float ratio;



    // Use this for initialization
    void Start () {
        RT = this.GetComponent<RectTransform> ();
        max = BC.VestigeHealth;

    }

    // Update is called once per frame
    void Update () {

        ratio = BC.VestigeHealth / max;
        Debug.Log (ratio);
        RT.localScale = new Vector3(ratio,1 ,1);


    }
	
}
