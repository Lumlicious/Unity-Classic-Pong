using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Ball ball;
	public Paddle paddle;
	public int xOffset = 20;
	public int player1Score = 0;
	public int player2Score = 0;

	private Vector2 player1StartPosition;
	private Vector2 player2StartPosition;

	// Use this for initialization
	void Start () {
		
		// Get start positions for player 1 and 2 paddles
		player1StartPosition = Camera.main.ScreenToWorldPoint(new Vector2(0 + xOffset, Screen.height / 2));
		player2StartPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - xOffset, Screen.height / 2));

		// Create ball
		Instantiate(ball);
		
		// Create paddles for player 1 and 2
		Paddle player1 = Instantiate(paddle, player1StartPosition, Quaternion.identity) as Paddle;
		Paddle player2 = Instantiate(paddle, player2StartPosition, Quaternion.identity ) as Paddle;
		player1.Init("player1");
		player2.Init("player2");

	}

}
