using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharSelectionMenu : MonoBehaviour {


	public bool playerRange;
	public bool playerMelee;
	public bool playerInput;
	public int choice;
	public GameObject StartButton;
	public GameObject RangeButton;
	public GameObject MeleeButton;
	public string meleeLevel;
	public string rangeLevel;

	// Use this for initialization
	void Start () {
		if (playerInput = RangeButton) {

			choice = 1;
		} else if (playerInput = MeleeButton) {

			choice = 2;

		}
			




	}
	
	// Update is called once per frame
	void Update () {

		if (playerInput = StartButton) {
			SceneManager.LoadScene (rangeLevel);

		} else if (playerInput = StartButton && choice == 2) {
			SceneManager.LoadScene (meleeLevel);
		}
	
	}
}
