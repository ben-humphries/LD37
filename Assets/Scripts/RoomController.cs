using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

	public GameObject[] tiles;
	public GameObject[] pickups;

	public GameObject playerObject;

	private GameObject player;
	private Vector2 currentPosition = new Vector2(0,0);

	private int[] tileMap = new int[]
	{
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,1,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,1,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,1,0,0,
		0,1,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,1
	};
	private int[] pickupMap = new int[]
	{
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,0,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
		-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
	};

	private GameObject[] tilePositions;
	private GameObject[] pickupPositions;

	// Use this for initialization
	void Start () {

		tilePositions = new GameObject[tileMap.Length];
		pickupPositions = new GameObject[pickupMap.Length];

		BoxCollider2D collider = tiles[0].GetComponent<BoxCollider2D> ();

		for(int i = 0; i < tileMap.Length; i++){

			tilePositions[i] = (GameObject)Instantiate (tiles[tileMap[i]],
			                                           new Vector2( (i % 10) * collider.size.x, (10-1) * collider.size.y -((i -(i % 10))/10) * collider.size.y),
			                                           Quaternion.identity);
			tilePositions[i].transform.parent = transform;

		}
		for (int i = 0; i < pickupMap.Length; i++) {
			if(pickupMap[i] != -1){
				pickupPositions[i] = (GameObject)Instantiate (pickups[pickupMap[i]],
				                                           new Vector2( (i % 10) * collider.size.x, (10-1) * collider.size.y -((i -(i % 10))/10) * collider.size.y),
				                                           Quaternion.identity);
				pickupPositions[i].transform.parent = transform;
			}
		}


		player = (GameObject)Instantiate (playerObject, currentPosition * 0.25f, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
		
		float deltaX = 0;
		float deltaY = 0;
		
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if(currentPosition.y + 1 < 10 && !tilePositions[(int)(currentPosition.x + (90 - (currentPosition.y + 1) * 10))].tag.Equals ("Wall")){
				deltaY += 1 * 0.25f;
				currentPosition.y++;

			}
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if(currentPosition.y - 1 >= 0 && !tilePositions[(int)(currentPosition.x + (90 - (currentPosition.y - 1) * 10))].tag.Equals ("Wall")){
				deltaY -= 1 * 0.25f;
				currentPosition.y--;

			}
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if(currentPosition.x + 1 < 10 && !tilePositions[(int)((currentPosition.x + 1) + (90 - currentPosition.y * 10))].tag.Equals ("Wall")){
				deltaX += 1 * 0.25f;
				currentPosition.x++;

			}
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if(currentPosition.x - 1 >= 0 && !tilePositions[(int)((currentPosition.x - 1) + (90 - currentPosition.y * 10))].tag.Equals ("Wall")){
				deltaX -= 1 * 0.25f;
				currentPosition.x--;

			}
		}
		
		player.transform.position = new Vector2 (player.transform.position.x + deltaX, player.transform.position.y + deltaY);

	}
}
