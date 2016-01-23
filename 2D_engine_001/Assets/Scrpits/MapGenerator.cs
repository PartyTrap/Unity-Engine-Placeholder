using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public int sizeX = 100;
	public int sizeY = 100;
	public float tileSize = 1.0f;



	// Use this for initialization
	void Start () {



		buildMap ();

	}
	
	void buildMap (){

		int vertSizeX = sizeX + 1;
		int vertSizeY = sizeY + 1;
		int numVerts = vertSizeX * vertSizeY;
		int numTiles = sizeX * sizeY;
		int numTriangles = numTiles * 2;


		//creating the mesh data
		Vector3[] vertices= new Vector3[ numVerts ];
		Vector3[] normals = new Vector3[ numVerts ];
		//Vector2[] uv = new Vector2[ numVerts ];

		int[] triangles = new int[numTriangles * 3];

		//populate the data arrays
		int x, y;

		for (y = 0; y < vertSizeY; y++) {
			for (x = 0; x < vertSizeX; x++) {
				vertices[y * vertSizeX + x] = new Vector3(x * tileSize, y * tileSize, 0);
				normals[y * vertSizeX + x] = new Vector3( 0 , 0 , 1 );
				//uv[y * vertSizeX + x] = new Vector2 ()
				//Gotta figure out how to give these individual tiles their own image
			}
		}

		for (y = 0; y < sizeY; y++) {
			for (x = 0; x < sizeX; x++) {
				int squareIndex = y * sizeX + x;
				int triOffset = squareIndex * 6;
				//make the first triangle
				triangles [triOffset + 0] = y * vertSizeX + x + 0;
				triangles [triOffset + 2] = y * vertSizeX + x + vertSizeX + 1;
				triangles [triOffset + 1] = y * vertSizeX + x + vertSizeX + 0;
				//make the second triangle
				triangles [triOffset + 3] = y * vertSizeX + x + 0;
				triangles [triOffset + 5] = y * vertSizeX + x + 1;
				triangles [triOffset + 4] = y * vertSizeX + x + vertSizeX + 1;
			}
		}

		//Make the actual mesh
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		//mesh.uv = uv;

		MeshFilter mesh_filter = GetComponent<MeshFilter>();
		MeshRenderer mesh_renderer = GetComponent <MeshRenderer>();
		MeshCollider mesh_collider = GetComponent <MeshCollider>();

		mesh_filter.mesh = mesh;

	}
}
