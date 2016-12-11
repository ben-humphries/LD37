using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CinematicText : MonoBehaviour {

	public GameObject sheep;
	public GameObject eagle;

	bool showSheep;

	private Text text;

	private string[] dialogue = new string[]
	{
		"Scientist: Congratulations. You have passed our test.",
		"You: Why am I here? What just happened?",
		"Scientist: We have been watching you through the window the entire time. It's interesting how much you missed.",
		"Scientist: You are part of a psychiatric experiment funded by the government.",
		"Scientist: We tested you in a number of ways, perhaps without you even knowing.",
		"You: This is outrageous? I was an experiment?",
		"Scientist: Yes. Would you like to know the results?",
		"You: No, you can't categorize me! I'm a human being!",
		"Scientist: You say we can't, but we can...",
		"Scientist: It's interesting that you didn't find the blue secret...",
		"Scientist: You have very conformist tendencies. You are, in effect, a sheep in a herd."
	};

	int index = 0;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();

		text.text = dialogue [0] + "\n[Space]";

		int conformityPoints = PlayerPrefs.GetInt ("conformityPoints");

		if (PlayerPrefs.GetInt ("Blue") == 1) {
			dialogue[9] = "Scientist: It's interesting that you interacted with all of the blue objects, despite it having no effect on your outcome whatsoever.";
		}

		if (conformityPoints <= 0) {
			dialogue [10] = "Scientist: You have very independent tendencies. You do whatever you want, not following rules, and not answering to anyone.";
			showSheep = false;
		} else {
			dialogue [10] = "Scientist: You have very conformist tendencies. You are, in effect, a sheep in a herd.";
			showSheep = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)){
			index++;
			if(index < dialogue.Length){
				text.text = dialogue[index] + "\n[Space]";
			}else if(index == dialogue.Length){
				if(showSheep){
					Instantiate(sheep, Vector2.zero, Quaternion.identity);
				}else{
					Instantiate(eagle, Vector2.zero, Quaternion.identity);
				}
			}else{
				Application.LoadLevel ("MainMenu");
			}
		}
	}
}
