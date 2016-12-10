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

	private GameObject[] tempTilePositions;

	private bool keyPickedUp = false;


	// Use this for initialization
	void Start () {

		player = (GameObject)Instantiate (playerObject, currentPosition * 0.25f, Quaternion.identity);

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
					
						tilePositions [i] = (GameObject)Instantiate (tiles [0], tilePosition, Quaternion.identity);
					}
				}
			}
			if (player.GetComponent<PlayerController> ().exitReached) {
				levelNumber++;

				this.loadLevel (levelNumber);
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

		if(player != null)
			player.transform.position = currentPosition * 0.25f;

		if (tilePositions != null) {
			foreach (GameObject g in tilePositions) {
				if (g != null)
					Destroy (g);
			}
		}
		if (pickupPositions != null) {
			foreach (GameObject g in pickupPositions) {
				if (g != null)
					Destroy (g);
			}
		}
		
		tilePositions = new GameObject[tileMap.Length];
		pickupPositions = new GameObject[pickupMap.Length];

		tempTilePositions = new GameObject[tileMap.Length];

		BoxCollider2D collider = tiles[0].GetComponent<BoxCollider2D> ();


		for(int i = 0; i < tileMap.Length; i++){

			tilePositions[i] = (GameObject)Instantiate (tiles[tileMap[i]],
			                                            new Vector2( (i % 10) * collider.size.x, (10-1) * collider.size.y -((i -(i % 10))/10) * collider.size.y),
			                                            Quaternion.identity);

			tempTilePositions[i] = (GameObject)Instantiate (levelChooser.levels[0].tiles[0],
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
		StartCoroutine ("Fade");
		

	}
	IEnumerator Fade(){
		for (float f = 0f; f <= 1f; f += 0.01f) {
			for(int i = 0; i < tilePositions.Length; i++){
				if(tilePositions[i] != null)
					tilePositions[i].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, f);
			}
			for(int i = 0; i < pickupPositions.Length; i++){
				if(pickupPositions[i] != null)
					pickupPositions[i].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, f);
			}

			player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, f);
			yield return null;
		}
		DestroyTempTiles ();
	}
	private void DestroyTempTiles(){
		if(tempTilePositions != null){
			foreach (GameObject t in tempTilePositions) {
				Destroy (t);
			}
		}
	}
}
