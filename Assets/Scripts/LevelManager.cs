using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
//		Debug.Log("Level load requested for " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
//		 Hide mouse cursor because I don't like it...or not
//		if(name == "Level_01" || name == "Level_02" || name == "Level_03"){
//			Screen.showCursor = false;
//		} else {
//			Screen.showCursor = true;
//		}
	}
	
	public void QuitRequest() {
		Debug.Log("Quit function requested.");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel+1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
	
}
