using UnityEngine;
using System.Collections;

public class mapGenerationBossArena3 : MonoBehaviour {
	[SerializeField]
	public int mapHeight = 50;
	public int mapWidth = 50;
	public GameObject wallTile;
	public GameObject floorTile;
	public GameObject spikeTile;
	private int[,] map;


	// Use this for initialization
	void Start () {

		map = BossArena2.map;

		//Put things in the map
		for (int y = 0; y < mapWidth; y++) {
			for (int x = 0; x < mapHeight; x++) {
				//Make everything grass

				if (map[y,x] == 0) {
					GameObject gTile = Instantiate (floorTile) as GameObject;
					gTile.transform.parent = gameObject.transform;
					gTile.transform.localPosition = new Vector3 (x, -y, 0);
				}
				//Make trees at the borders
				if (map[y,x] == 1) {
					GameObject tTile = Instantiate (wallTile) as GameObject;
					tTile.transform.parent = gameObject.transform;
					tTile.transform.localPosition = new Vector3 (x, -y, 0);
				}
				if (map [y, x] == 2) {
					GameObject sTile = Instantiate (spikeTile) as GameObject;
					sTile.transform.parent = gameObject.transform;
					sTile.transform.localPosition = new Vector3 (x, -y, 0);
				}

			}
		}



	}
	public void setMap(int[,] newMap){
		map = newMap;
	}
	public void redrawMap(){
		foreach (Transform child in this.gameObject.transform) {
			GameObject.Destroy (child.gameObject);
		}
		for (int y = 0; y < mapWidth; y++) {
			for (int x = 0; x < mapHeight; x++) {
				//Make everything grass

				if (map[y,x] == 0) {
					GameObject gTile = Instantiate (floorTile) as GameObject;
					gTile.transform.parent = gameObject.transform;
					gTile.transform.localPosition = new Vector3 (x, -y, 0);
				}
				//Make trees at the borders
				if (map[y,x] == 1) {
					GameObject tTile = Instantiate (wallTile) as GameObject;
					tTile.transform.parent = gameObject.transform;
					tTile.transform.localPosition = new Vector3 (x, -y, 0);
				}
				if (map [y, x] == 2) {
					GameObject sTile = Instantiate (spikeTile) as GameObject;
					sTile.transform.parent = gameObject.transform;
					sTile.transform.localPosition = new Vector3 (x, -y, 0);
				}

			}
		}
	}
}
