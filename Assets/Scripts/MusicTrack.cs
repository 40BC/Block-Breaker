using UnityEngine;
using System.Collections;

public class MusicTrack : MonoBehaviour {

	static MusicTrack instance = null;
	
	void Awake () {
		if(instance != null){
			Destroy(gameObject);
		} else {
			instance = this;		
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
