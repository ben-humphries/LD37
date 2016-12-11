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
		"You see two doors with two signs. Who are Brad and John?",
		"There are lifeless versions of you over there... They seem so real...",
		"There are two cages... One with a dog, one a cat. It looks like whichever door you go through will kill its animal...",
		"Maybe the answer was the start all along...",
		"Maybe the answer was the start all along...",
		"A sign on the wall reads, \"Go to the exit to leave the simulation. Congratulations.\"",
		"",
		"",
		"To interact with something, it must meet two requirements... Be blue, and be under you..."
	};

	void Start () {
		levelNumber = roomController.levelNumber;

		text = GetComponent<Text> ();

		text.text = levelTexts[levelNumber - 1];
	}
	

	void Update () {
		if (levelNumber != roomController.levelNumber) {
			levelNumber = roomController.levelNumber;
			if(levelNumber <= 17 || levelNumber >= 20)
				text.text = levelTexts[levelNumber - 1];
		}
	}
}
