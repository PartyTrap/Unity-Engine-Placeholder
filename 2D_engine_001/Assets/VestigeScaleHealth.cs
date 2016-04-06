using UnityEngine;
using System.Collections;

public class VestigeScaleHealth : MonoBehaviour {

	private RectTransform RT;
	public Enemy_State ES;
	private float max;
	private float ratio;



	// Use this for initialization
	void Start () {
		RT = this.GetComponent<RectTransform> ();
		max = 2000.0f;

	}

	// Update is called once per frame
	void Update () {

		ratio = ES.enemyHealth / max;
		RT.localScale = new Vector3(ratio,1 ,1);


	}
}
