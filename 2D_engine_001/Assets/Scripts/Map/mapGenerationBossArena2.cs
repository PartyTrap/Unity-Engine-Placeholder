using UnityEngine;
using System.Collections;

public class mapGenerationBossArena2 : MonoBehaviour {

	[SerializeField]
	public int mapHeight = 50;
	public int mapWidth = 50;
	public GameObject treeTile;
	public GameObject grassTile;
	public GameObject stopTile;
	private int[,] map;


	// Use this for initialization
	void Start () {

		map = BossArena2.map;

		//Put things in the map
		for (int y = 0; y < mapWidth; y++) {
			for (int x = 0; x < mapHeight; x++) {
				//Make everything grass

				if (map[y,x] == 0) {
					GameObject gTile = Instantiate (grassTile) as GameObject;
					gTile.transform.parent = gameObject.transform;
					gTile.transform.localPosition = new Vector3 (x, -y, 0);
				}
				//Make trees at the borders
				if (map[y,x] == 1) {
					GameObject tTile = Instantiate (treeTile) as GameObject;
					tTile.transform.parent = gameObject.transform;
					tTile.transform.localPosition = new Vector3 (x, -y, 0);
				}
				if (map [y, x] == 2) {
					GameObject sTile = Instantiate (stopTile) as GameObject;
					sTile.transform.parent = gameObject.transform;
					sTile.transform.localPosition = new Vector3 (x, -y, 0);
				}

			}
		}



	}
}

