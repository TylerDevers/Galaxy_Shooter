using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 5f;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		ShipMovement();
	}

	void ShipMovement()
	{
		float horizontalMove = Input.GetAxis("Horizontal");
		float verticalMove = Input.GetAxis("Vertical");

		transform.Translate(Vector3.right * speed * horizontalMove * Time.deltaTime);
		transform.Translate(Vector3.up * speed * verticalMove * Time.deltaTime);
	}
}
