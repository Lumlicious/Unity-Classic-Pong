using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int player1Score = 0;
	public static int player2Score = 0;

	private Text player1Scorebox;
	private Text player2Scorebox;

	// Use this for initialization
	void Start () {
		player1Scorebox = transform.Find("Player1Score").GetComponent<Text>();
		player2Scorebox = transform.Find("Player2Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		player1Scorebox.text = player1Score.ToString();
		player2Scorebox.text = player2Score.ToString();
	}
}
