using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	
	// Use this for initialization
	void Start () {
		// Generics <> example
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			// Lock ball to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//Wait for mouse press to launch
			if(Input.GetMouseButtonDown(0)){
				hasStarted = true;
				rigidbody2D.velocity = new Vector2(2f, 10f);		
			}
		}	
	}
	
	// Play boing on collision
	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 bounceTweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		if(hasStarted){
			audio.Play();
			this.rigidbody2D.velocity += bounceTweak;
		}
	}
}
