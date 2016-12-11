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
		"You are in a field with two shrines to dead dogs in the corners... Which path leads out?",
		"You are in a courtyard, solely containing a small puddle...",
		"A desert... There are three cacti ahead, and three paths to choose from...",
		"You see 3 doors, all with a sign next to them...",
		"More desert... There's only one way out.",
		"You see a street sign with the number 3 on it... It seems familiar...",
		"This place is weird... It's very vibrant...",
		"...",
		"You see two doors with two signs. Who are Brad and John?"
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
