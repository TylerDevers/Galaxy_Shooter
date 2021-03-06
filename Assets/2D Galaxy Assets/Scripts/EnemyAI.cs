﻿//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {


	[SerializeField] float _enemySpeed = 2f;
	[SerializeField] private GameObject _enemyExplosionPrefab;
	[SerializeField] private AudioClip _explosionClip;	

	private UIManager uIManager;

	// Use this for initialization
	void Start () 
	{
		uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		NewEnemyPosition();
		Movement();

	}

    void NewEnemyPosition()
    {
		float vertPosition = transform.position.y;
		System.Random random = new System.Random();
		float horizPosition = random.Next(-75, 75)/10f;
		
		if (vertPosition < -6.5f)
		{
        	transform.position = new Vector3(horizPosition, 6.5f, 0);
		}
    }

    void Movement()
	{
		transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
		
	}

	public void DestroyEnemy()
	{
		AudioSource.PlayClipAtPoint(_explosionClip, Camera.main.transform.position, 1f);
		Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
		uIManager.UpdateScore();
		DestroyObject(gameObject);
	}

	void OnTriggerEnter2D(Collider2D otherObject)
	{
		Laser laser = otherObject.GetComponent<Laser>();
		Player player = otherObject.GetComponent<Player>();

		if (player != null) 
		{
			DestroyEnemy();
			player.Damage();
		}
		if (laser != null)
		{
			DestroyEnemy();
			laser.DestroyLaser();
		}
	}



}
