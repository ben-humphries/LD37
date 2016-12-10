using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	public RoomController roomController;

	Text text;

	private int levelNumber;

	private string[] levelTexts = new string[]
	{
		"Where am I? Why is there a chair over there?",
		"What is this? I must be trapped in a simulation! Is that an exit over there?",
		"Whoa... Is this jungle really just a simulation? Looks like the door's locked..."
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
