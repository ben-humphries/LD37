using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public void LoadScene(string sceneName){
		print ("here");
		Application.LoadLevel (sceneName);
	}
	public void LoadScene(int index){
		print ("here");
		Application.LoadLevel (index);
	}
	public void Quit(){
		Application.Quit ();
	}
	public void PauseGame(){
		Time.timeScale = 0;
	}
	public void UnPauseGame(){
		Time.timeScale = 1;
	}
}
