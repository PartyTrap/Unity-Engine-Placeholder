using UnityEngine;
using System.Collections;

public class Scale_Stamina : MonoBehaviour {

    private RectTransform RT;
    public Player_Dash PD;
    private float max;
    private float ratio;

    // Use this for initialization
    void Start () {
        RT = this.GetComponent<RectTransform> ();
        max = PD.cooldown;
    }

    // Update is called once per frame
    void Update () {
        ratio = PD.stamina / max;
        Debug.Log (ratio);
        RT.localScale = new Vector3(ratio,1 ,1);
    }
}
