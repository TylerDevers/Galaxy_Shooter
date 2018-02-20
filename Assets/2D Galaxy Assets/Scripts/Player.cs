using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public bool tripleShotPossible = false; //default will be false when power up created.
	//public bool speedBoostPossible = false;
	public bool shieldActive = false;
	[SerializeField] private GameObject _laserPrefab;
	[SerializeField] private GameObject _tripleShotPrefab;
	[SerializeField] private GameObject _playerExplosion;
	[SerializeField] private GameObject _playerShields;
	[SerializeField] private float _rateOfFire = 0.25f;
	[SerializeField] private float _nextFire = 0.0f;

	[SerializeField] private float _playerSpeed = 5f;

	[SerializeField] private int _playerLives = 3;

	private UIManager uIManager;


	

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0f, 0f, 0f);

		//gain access to the UImanager Script on the canvas
		uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		uIManager.UpdateLives(_playerLives);
	}
	
	// Update is called once per frame
	void Update () {
		ShipMovement();
		LaserSpawn();
	}

	void ShipMovement()
	{
		float horizontalMove = Input.GetAxis("Horizontal");
		float verticalMove = Input.GetAxis("Vertical");

		transform.Translate(Vector3.right * _playerSpeed * horizontalMove * Time.deltaTime);
		transform.Translate(Vector3.up * _playerSpeed * verticalMove * Time.deltaTime);

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

	void LaserSpawn()
	{
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > _nextFire)
		{
			if (tripleShotPossible)
			{
				TripleShot();
			}
			else
			{
				SingleShot();
			}
		}
	}

    void TripleShot()
    {
		Instantiate(_tripleShotPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
		_nextFire = Time.time + _rateOfFire; 
    }

    void SingleShot()
	{
		Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);
		_nextFire = Time.time + _rateOfFire;
	}

	public void Shield()
	{
		if (!shieldActive)
		{
			shieldActive = true;
			_playerShields.SetActive(true);
		}
	}

	public void TripleShotTurnedOn() //called from Powerup.cs
	{
		tripleShotPossible = true;
		StartCoroutine(TripleShotPowerDown());
	}

	IEnumerator TripleShotPowerDown()
	{
		yield return new WaitForSeconds(5);
		tripleShotPossible = false;
	}

	public void SpeedBoostTurnedOn()
	{
		//speedBoostPossible = true;
		_playerSpeed *= 1.5f;
		StartCoroutine(SpeedBoostPowerDown());
	}

	IEnumerator SpeedBoostPowerDown()
	{
		yield return new WaitForSeconds(10);
		_playerSpeed /= 1.5f;
		//speedBoostPossible = false;

	}

	public void Damage() //called from EnemyAI.cs
	{

		if (shieldActive)
		{
			shieldActive = false;
			_playerShields.SetActive(false);
		}
		else
		{
			_playerLives -= 1;
			uIManager.UpdateLives(_playerLives);
			if (_playerLives <= 0)
			{
				PlayerDeath();
			}
		}
	}

	void PlayerDeath()
	{
		Instantiate(_playerExplosion, transform.position, Quaternion.identity);
		DestroyObject(gameObject);
	}
}
