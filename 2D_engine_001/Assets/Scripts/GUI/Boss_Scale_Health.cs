using UnityEngine;
using System.Collections;

public class Boss_Scale_Health : MonoBehaviour {


    private RectTransform RT;
    public BossState BS;
    private float max;
    private float ratio;



    // Use this for initialization
    void Start () {
        RT = this.GetComponent<RectTransform> ();
		max = BS.bossHealth;

    }

    // Update is called once per frame
    void Update () {

		ratio = BS.bossHealth / max;
        Debug.Log (ratio);
        RT.localScale = new Vector3(ratio,1 ,1);


    }
}
