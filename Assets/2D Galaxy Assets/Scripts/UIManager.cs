using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


	public Sprite[] lives;
	public Image playerLivesImage;
	public GameObject titleOverlay;
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

	public void TitleScreen(bool gameRunning)
	{
		if (gameRunning)
		{
			// clear score
			scoreText.text = "0";
			// reset lives
			// spawn player into scene.
			// remove title screen
			print("TitleScreen called, game running");
		}
		else
		{
			titleOverlay.SetActive(true);
			//show title screen
			//imageComponents[1].gameObject.SetActive(true);
			//stop enemies 
			print("TitleScreen called, game stopped");
			//print(title);
		}
	}
}
