using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//If left mouse button is pressed
		if (Input.GetMouseButtonDown (0)) {

			/*MOVEMENT*/

			//Get mouse position and convert it to world coordinates.
			Vector2 mouseClick = Input.mousePosition;
			mouseClick = Camera.main.ScreenToWorldPoint(mouseClick);

			//If coordinates are negative, subtract one as when casted to an int, a negative number will round towards zero.
			if(mouseClick.x < 0)
				mouseClick.x --;
			if(mouseClick.y < 0)
				mouseClick.y --;

			//Round to nearest tile value and update player position.
			Vector2 mousePosition = new Vector2 ((int)mouseClick.x + 0.5f, (int)mouseClick.y + 0.5f);
			transform.position = mousePosition;

		}
	}

}
