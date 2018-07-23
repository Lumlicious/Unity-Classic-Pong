using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Ball ball;
	public Paddle paddle;
	public float xOffset = 0.1f;
	public int player1Score = 0;
	public int player2Score = 0;
	public static Vector2 bottomLeft;
	public static Vector2 topRight;

	private Vector2 player1StartPosition;
	private Vector2 player2StartPosition;
	
	// Use this for initialization
	void Start () {

		bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
		topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

		// Get start positions for player 1 and 2 paddles
		player1StartPosition = new Vector2(bottomLeft.x + xOffset, 0);
		player2StartPosition = new Vector2(topRight.x - xOffset, 0);

		// Create ball
		Instantiate(ball);
		
		// Create paddles for player 1 and 2
		Paddle player1 = Instantiate(paddle, player1StartPosition, Quaternion.identity) as Paddle;
		Paddle player2 = Instantiate(paddle, player2StartPosition, Quaternion.identity ) as Paddle;

		// Set paddle as player
		player1.Init("player1");
		player2.Init("player2");

	}

}
