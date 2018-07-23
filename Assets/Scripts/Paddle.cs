using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	[SerializeField]
	float speed;

	public string input;
	
	private float height;

	void Start() {
		height = GetComponent<Collider2D>().bounds.size.y;
	}

	// Constructor
	public void Init(string player) {

		// Set paddle to player
		input = player;

		// Change paddle name to player name
		transform.name = player;
	}
	
	// Update is called once per frame
	void Update () {

		// Get velocity based on input
		float velocity = Input.GetAxis(input) * Time.deltaTime * speed;

		// Clamp movement to screen space
		if ((transform.position.y < GameManager.instance.bottomLeft.y + height / 2 && velocity < 0) ||
			(transform.position.y > GameManager.instance.topRight.y - height / 2 && velocity > 0)) {
			velocity = 0;
		}

		// Move paddle
		transform.Translate(velocity * Vector2.up);
	}
}
