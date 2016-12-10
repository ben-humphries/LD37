using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public RoomController controller;

	private Vector2 currentPosition;

	// Use this for initialization
	void Start () {
		currentPosition = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		float deltaX = 0;
		float deltaY = 0;

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if(currentPosition.y + 1 < 10){
				deltaY += 1 * 0.25f;
				currentPosition.y++;
			}
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if(currentPosition.y - 1 >= 0){
				deltaY -= 1 * 0.25f;
				currentPosition.y--;
			}
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if(currentPosition.x + 1 < 10){
				deltaX += 1 * 0.25f;
				currentPosition.x++;
			}
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if(currentPosition.x - 1 >= 0){
				deltaX -= 1 * 0.25f;
				currentPosition.x--;
			}
		}

		transform.position = new Vector2 (transform.position.x + deltaX, transform.position.y + deltaY);

	}
	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag.Equals ("Exit")) {
			Debug.Log ("here");
		}
	}
}
