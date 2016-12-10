using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {
	
	public int levelNumber;

	public GameObject playerObject;

	private GameObject player;
	private Vector2 currentPosition;

	private GameObject[] tiles;
	private GameObject[] pickups;

	private int[] tileMap;
	private int[] pickupMap;

	private GameObject[] tilePositions;
	private GameObject[] pickupPositions;

	private bool keyPickedUp = false;
	private bool exitReached = false;

	// Use this for initialization
	void Start () {

		loadLevel (levelNumber);

	}
	
	// Update is called once per frame
	void Update () {
		
		float deltaX = 0;
		float deltaY = 0;
		
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if(currentPosition.y + 1 < 10 && !(tilePositions[(int)(currentPosition.x + (90 - (currentPosition.y + 1) * 10))].layer == LayerMask.NameToLayer("Collision"))){
				deltaY += 1 * 0.25f;
				currentPosition.y++;

			}
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if(currentPosition.y - 1 >= 0 && !(tilePositions[(int)(currentPosition.x + (90 - (currentPosition.y - 1) * 10))].layer == LayerMask.NameToLayer("Collision"))){
				deltaY -= 1 * 0.25f;
				currentPosition.y--;

			}
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if(currentPosition.x + 1 < 10 && !(tilePositions[(int)((currentPosition.x + 1) + (90 - currentPosition.y * 10))].layer == LayerMask.NameToLayer("Collision"))){
				deltaX += 1 * 0.25f;
				currentPosition.x++;

			}
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if(currentPosition.x - 1 >= 0 && !(tilePositions[(int)((currentPosition.x - 1) + (90 - currentPosition.y * 10))].layer == LayerMask.NameToLayer("Collision"))){
				deltaX -= 1 * 0.25f;
				currentPosition.x--;

			}
		}
		if (player != null) {
			if (!keyPickedUp && player.GetComponent<PlayerController> ().keyPickedUp) {
				keyPickedUp = true;
			
				for (int i = 0; i < tilePositions.Length; i++) {
					if (tilePositions [i].tag.Equals ("Door")) {
						Vector2 tilePosition = tilePositions [i].transform.position;
					
						Destroy (tilePositions [i]);
						tilePositions [i] = (GameObject)Instantiate (tiles [0], tilePosition, Quaternion.identity);
					}
				}
			}
			if (!exitReached && player.GetComponent<PlayerController> ().exitReached) {
				exitReached = true;
			
				this.loadLevel (2);
			}
		
		
			player.transform.position = new Vector2 (player.transform.position.x + deltaX, player.transform.position.y + deltaY);
		}
	}
	public void loadLevel(int levelNumber){

		Levels levelChooser = GetComponent<Levels> ();
		
		this.tileMap = levelChooser.levels [levelNumber - 1].tileMap;
		this.pickupMap = levelChooser.levels [levelNumber - 1].pickupMap;
		
		this.tiles = levelChooser.levels [levelNumber - 1].tiles;
		this.pickups = levelChooser.levels [levelNumber - 1].pickups;

		this.currentPosition = levelChooser.levels [levelNumber - 1].startingPosition;
		
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
}
