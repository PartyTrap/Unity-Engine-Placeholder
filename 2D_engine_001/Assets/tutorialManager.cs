using UnityEngine;
using System.Collections;

public class tutorialManager : Enemy_State {
    public GameObject Bunny;
    public GameObject tutorial2;


    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Bunny == null) {
            Destroy (this.gameObject);
            tutorial2.SetActive (true);
        }
    }

}