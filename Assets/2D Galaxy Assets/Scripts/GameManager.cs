using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool gameOver;
	public GameObject player;
	private UIManager _uiManager;

	private SpawnManager _spawnManager;

	void Start()
	{
		gameOver = true;
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		_spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
	}
	// Update is called once per frame
	void Update () 
	{
		if (gameOver == true)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				print("spaceDown");
				Instantiate(player, Vector3.zero, Quaternion.identity);
				gameOver = false;
				_uiManager.HideTitleScreen();
				_spawnManager.StartCoroutine("EnemySpawnRoutine");
				_spawnManager.StartCoroutine("PowerupSpawnRoutine");
			}
		}

	}
}
