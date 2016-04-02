using UnityEngine;
using System.Collections;


public class mapGeneration : MonoBehaviour {

	[SerializeField]
	public int mapHeight = 50;
	public int mapWidth = 50;
	public GameObject wallTile;
	public GameObject floorTile;
    public GameObject conveyorRightTile;
    public GameObject conveyorLeftTile;
    public GameObject conveyorUpTile;
    public GameObject conveyorDownTile;
    public GameObject Spike;
    public GameObject Web;
	private int[,] map;

    public int level;

	// Use this for initialization
	void Start () {

        switch (level)
        {
            case 0:
                this.map = Level0.map;
                break;
            case 1:
                this.map = Level1.map;
                break;
            case 2:
                this.map = Level2.map;
                break;
			case 3:
				this.map = Level3.map;
                break;
			case 4:
				this.map = Level4.map;
				break;
			case 5:
				this.map = Level5.map;
				break;
			case 6:
				this.map = Level6.map;
				break;
			case 7:
				this.map = Level7.map;
				break;
			case 8:
				this.map = Level8.map;
				break;
			case 9:
				this.map = Level9.map;
				break;
			case 10:
				this.map = Level10.map;
				break;
        }
                

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
                if (map[y,x] == 4) {
                    GameObject tTile = Instantiate (Spike) as GameObject;
                    tTile.transform.parent = gameObject.transform;
                    tTile.transform.localPosition = new Vector3 (x, -y, 0);
                } 
                if (map[y, x] == 5)
                {
                    GameObject gTile = Instantiate (floorTile) as GameObject;
                    gTile.transform.parent = gameObject.transform;
                    gTile.transform.localPosition = new Vector3 (x, -y, 0);

                    GameObject tTile = Instantiate (Web) as GameObject;
                    tTile.transform.parent = gameObject.transform;
                    tTile.transform.localPosition = new Vector3 (x, -y, 0);
                }
                if (map[y,x] == 10)
                {
                    GameObject tTile = Instantiate (conveyorRightTile) as GameObject;
                    tTile.transform.parent = gameObject.transform;
                    tTile.transform.localPosition = new Vector3 (x, -y, 0);
                }
                if (map[y,x] == 11)
                {
                    GameObject tTile = Instantiate (conveyorDownTile) as GameObject;
                    tTile.transform.parent = gameObject.transform;
                    tTile.transform.localPosition = new Vector3 (x, -y, 0);
                }
                if (map[y,x] == 12)
                {
                    GameObject tTile = Instantiate (conveyorLeftTile) as GameObject;
                    tTile.transform.parent = gameObject.transform;
                    tTile.transform.localPosition = new Vector3 (x, -y, 0);
                }
                if (map[y,x] == 13)
                {
                    GameObject tTile = Instantiate (conveyorUpTile) as GameObject;
                    tTile.transform.parent = gameObject.transform;
                    tTile.transform.localPosition = new Vector3 (x, -y, 0);
                }
			}
		}



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
