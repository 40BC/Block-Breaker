using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		} else {
			AutomatePlay();
		}
	}
	
	void MoveWithMouse(){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
	
	void AutomatePlay(){
		Vector3 ballPos = ball.transform.position;
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
}
