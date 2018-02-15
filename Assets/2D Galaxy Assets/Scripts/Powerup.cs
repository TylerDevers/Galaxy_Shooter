﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    [SerializeField] private float _speed = 3.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * _speed * Time.deltaTime);

	}

	void OnTriggerEnter2D(Collider2D otherObject) 
	{
		if (otherObject.tag == "Player")
		{
			Player player = otherObject.GetComponent<Player>();

			if (player != null) 
			{
				player.TripleShotTurnedOn();
				
				DestroyObject(gameObject);
			}
		}
	}
}