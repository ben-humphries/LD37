using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	public RoomController roomController;

	Text text;

	private int levelNumber;

	private string[] levelTexts = new string[]
	{
		"You are in an empty room with only a chair...",
		"You are in a simulation. You see what seems to be an exit...",
		"This simulation is intricate... the jungle looks so real... You see a key...",
		"You are in a field with two shrines to dead dogs in the corners... Which path leads out?"
	};

	void Start () {
		levelNumber = roomController.levelNumber;

		text = GetComponent<Text> ();

		text.text = levelTexts[levelNumber - 1];
	}
	

	void Update () {
		if (levelNumber != roomController.levelNumber) {
			levelNumber = roomController.levelNumber;
			text.text = levelTexts[levelNumber - 1];
		}
	}
}
