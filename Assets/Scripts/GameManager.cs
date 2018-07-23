using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	Paddle paddle;

	[SerializeField]
	Ball ballInstance;

	public static GameManager instance = null;
	public string gameState;
	public Vector2 bottomLeft;
	public Vector2 topRight;
	public Ball ball;

	private Vector2 player1StartPosition;
	private Vector2 player2StartPosition;
	private float xOffset = 0.1f;

	void Start() {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);    
		}

		DontDestroyOnLoad(gameObject);

		gameState = "waitingForServe";

		bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
		topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

		// Get start positions for player 1 and 2 paddles
		player1StartPosition = new Vector2(bottomLeft.x + xOffset, 0);
		player2StartPosition = new Vector2(topRight.x - xOffset, 0);

		// Create paddles for player 1 and 2
		Paddle player1 = Instantiate(paddle, player1StartPosition, Quaternion.identity) as Paddle;
		Paddle player2 = Instantiate(paddle, player2StartPosition, Quaternion.identity ) as Paddle;

		// Set paddle as player
		player1.Init("player1");
		player2.Init("player2");
	}

	void Update() {
		if( Input.GetKeyDown("return") && gameState == "waitingForServe") {
			serve();
		}
	}

	void serve() {
		// Create ball
		ball = Instantiate(ballInstance, new Vector2(0,0), Quaternion.identity);

		// Update game state
		gameState = "gameInPlay";

	}

	public void endRound(string winner) {
		// Update game state
		gameState = "waitingForServe";
		
		// Update score
		if (winner == "player1") {
			ScoreManager.player1Score++;
		} else if (winner == "player2") {
			ScoreManager.player2Score++;
		}

		// Check if any players are winners
		if (ScoreManager.player1Score == 12 || ScoreManager.player2Score == 12) {
			gameOver();
		}
	}

	public void gameOver() {
		ScoreManager.player1Score = ScoreManager.player1Score = 0;
	}
}
