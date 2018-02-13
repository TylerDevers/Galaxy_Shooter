using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] private float playerSpeed = 5f;

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

		transform.Translate(Vector3.right * playerSpeed * horizontalMove * Time.deltaTime);
		transform.Translate(Vector3.up * playerSpeed * verticalMove * Time.deltaTime);

		RestrainShip();
	}

	void RestrainShip()
	{
		float verticalLocation = transform.position.y;
		float horizontalLocation = transform.position.x;

		if ( verticalLocation > 4 )
		{
			transform.position = new Vector3( transform.position.x, 4, 0 );
		} 
		else if ( verticalLocation < -4 )
		{
			transform.position = new Vector3( transform.position.x, -4, 0 );
		}

		if ( horizontalLocation > 9.5f )
		{
			transform.position = new Vector3( -9.5f, transform.position.y, 0 );
		}
		else if ( horizontalLocation < -9.5f )
		{
			transform.position = new Vector3( 9.5f, transform.position.y, 0 );
		}
	}
}
