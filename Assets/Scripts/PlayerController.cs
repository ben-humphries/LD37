using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Sprite playerRight;
	public Sprite playerLeft;
	public Sprite playerFront;
	public Sprite playerBack;

	private SpriteRenderer renderer;
	

	// Use this for initialization
	void Start () {

		renderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.UpArrow)) {
				renderer.sprite = playerBack;
			
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				renderer.sprite = playerFront;
			
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {

			renderer.sprite = playerRight;
			
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			
			renderer.sprite = playerLeft;

		}



	}
	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag.Equals ("Exit")) {
			Debug.Log ("here");
		} else if (c.gameObject.tag.Equals ("Key")) {
			Debug.Log ("picked up key");
			Destroy (c.gameObject);
		}
	}
}
