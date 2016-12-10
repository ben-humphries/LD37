using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

	public GameObject[] tiles; 

	private int[] tileMap = new int[]
	{
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,1,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,1
	};
	

	// Use this for initialization
	void Start () {

		BoxCollider2D collider = tiles[0].GetComponent<BoxCollider2D> ();

		for(int i = 0; i < tileMap.Length; i++){

			GameObject tile = (GameObject)Instantiate (tiles[tileMap[i]],
			                                           new Vector2( (i % 10) * collider.size.x, (10-1) * collider.size.y -((i -(i % 10))/10) * collider.size.y),
			                                           Quaternion.identity);
			tile.transform.parent = transform;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
