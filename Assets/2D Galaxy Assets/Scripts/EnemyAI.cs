using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	[SerializeField] float _enemySpeed = 2f;

	// enemy moves down screen, then reappears in new location at top of screen.
	// enemy bounds -7.5 and 7.5 on the x axis, -6.5 and 6.5 on y axis

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(7.5f, 6.5f, 0);
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

}
