using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.4f);
		if(isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			genSmoke();
			Destroy(gameObject);			
		} else {
			LoadSprites();
		}
	}
	
	void genSmoke(){
		GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Missing Sprite!");
		}
	}

}
