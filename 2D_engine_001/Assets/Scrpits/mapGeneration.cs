using UnityEngine;
using System.Collections;


public class mapGeneration : MonoBehaviour {

	[SerializeField]
	public int mapHeight = 50;
	public int mapWidth = 50;
	public GameObject treeTile;
	public GameObject grassTile;



	// Use this for initialization
	void Start () {

		//Put things in the map
		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {
				//Make everything grass
				GameObject gTile = Instantiate (grassTile) as GameObject;
				gTile.transform.parent = gameObject.transform;
				gTile.transform.localPosition = new Vector3 (x, y, 0);
				//Make trees at the borders
				if (x == 0 || x == mapWidth - 1 || y == 0 || y == mapHeight - 1) {
					GameObject tTile = Instantiate (treeTile) as GameObject;
					tTile.transform.parent = gameObject.transform;
					tTile.transform.localPosition = new Vector3 (x, y, 0);
				}

			}
		}



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
