using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	[SerializeField]
	float speed;

	string input;

	// Use this for initialization
	void Start () {
		
	}

	public void Init(string player) {
		input = player;
		transform.name = player;
	}
	
	// Update is called once per frame
	void Update () {
		float velocity = Input.GetAxis(input) * Time.deltaTime * speed;
		transform.Translate(velocity * Vector2.up);
	}
}
