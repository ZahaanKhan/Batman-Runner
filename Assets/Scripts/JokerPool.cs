using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerPool : MonoBehaviour {

	public int jokerPoolSize = 5;
	public GameObject jokerPrefab;
	private GameObject[] jokers;
	private int currentJoker = 0;

	// position offscreen for generating random joker pool
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);

	// Spawning the new frames
	private float timeLastSpawn;
	private float spawnRate = 2f;
	private float spawnYPosition = -3.1f;

	// Use this for initialization
	void Start () {
		jokers = new GameObject[jokerPoolSize];
		for(int i = 0; i< jokerPoolSize; i++) {
			jokers[i] = (GameObject) Instantiate(jokerPrefab, objectPoolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeLastSpawn += Time.deltaTime;
		
		if (GameController.gameController.gameOver == false && timeLastSpawn >= spawnRate) {
			timeLastSpawn = 0;
			float spawnXPosition = Random.Range (1f, 10f);
			
			jokers[currentJoker].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			currentJoker++;

			if (currentJoker >= jokerPoolSize) {
				currentJoker = 0;
			}
	
		}
	}
}
