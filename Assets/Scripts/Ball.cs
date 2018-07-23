﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField]
	float speed;

	Vector2 direction;

	// Use this for initialization
	void Start () {
		direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		direction = direction.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * speed * Time.deltaTime);

		if (transform.position.y < GameManager.bottomLeft.y && direction.y < 0) {
			direction.y = -direction.y;
		}
		if (transform.position.y > GameManager.topRight.y && direction.y > 0 ) {
			direction.y = -direction.y;
		}

		if (transform.position.x < GameManager.bottomLeft.x) {
			Object.Destroy(this.gameObject);
			GameManager.endRound();
		}
		if ( transform.position.x > GameManager.topRight.x ) {
			Object.Destroy(this.gameObject);
			GameManager.endRound();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.tag == "paddle") {
			string player = other.GetComponent<Paddle>().input;
			if (player == "player1" && direction.x < 0) {
				direction.x = -direction.x;
			}
			if (player == "player2" && direction.x > 0) {
				direction.x = -direction.x;
			}
		}
	}
}
