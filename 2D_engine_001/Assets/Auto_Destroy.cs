using UnityEngine;
using System.Collections;

public class Auto_Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(wait());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator wait(){
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
         
    }

}
