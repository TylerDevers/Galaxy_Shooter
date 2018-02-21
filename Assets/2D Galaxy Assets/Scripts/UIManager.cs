using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


	public Sprite[] lives;
	public Image playerLivesImage;
	public GameObject titleScreen;
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

	public void HideTitleScreen()
	{
		titleScreen.SetActive(false);
	}
	
	public void ShowTitleScreen()
	{
		titleScreen.SetActive(true);	
		scoreText.text = "0";	
		score = 0;
	}
}
