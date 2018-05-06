using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batman : MonoBehaviour {

	private Rigidbody2D batman;
//	private Animator animator;

	private bool isBatmanJumping = false;

	// Use this for initialization
	void Start () {
		batman = GetComponent<Rigidbody2D> ();
//		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			BatmanJump ();
		}

//		Debug.Log (batman.velocity.y);
	}

	void BatmanJump() {
		// Can't double Jump
		if (!isBatmanJumping) {
			isBatmanJumping = true;
			batman.velocity = Vector2.zero;
			batman.AddForce(new Vector2(0, 670f));
			//		animator.SetTrigger ("BatmanJump");
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "gc1Ground") {
			isBatmanJumping = false;
		}
	}
}
