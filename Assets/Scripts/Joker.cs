﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joker : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			GameController.gameController.GameOver();
		}
	}
}
