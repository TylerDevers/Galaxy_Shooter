using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Sprite[] lives;
	public Image playerLivesImage;
	public int score;

	public Text scoreText;

// Methods // 
	public void UpdateLives(int livesLeft)
	{
		playerLivesImage.sprite = lives[livesLeft];
		
	}

	public void UpdateScore()
	{
		score += 10;
		scoreText.text = score.ToString();
	}
}
