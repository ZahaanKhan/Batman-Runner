using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb2;

	// Use this for initialization
	void Start () {
		rb2 = GetComponent<Rigidbody2D> ();
		rb2.velocity = new Vector2 (-6f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.gameController.gameOver) {
			rb2.velocity = Vector2.zero;
		}
	}
}
