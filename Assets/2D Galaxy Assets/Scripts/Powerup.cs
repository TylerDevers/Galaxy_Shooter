using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    [SerializeField] private float _speed = 3.0f;
	[SerializeField] int powerupID; // 0 tripleshot, 1 speed boost, 2 shield

	[SerializeField] private AudioClip _powerupAudio;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * _speed * Time.deltaTime);

		if (gameObject.transform.position.y < -7)
		{
			DestroyObject(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherObject) 
	{
		if (otherObject.tag == "Player")
		{
			Player player = otherObject.GetComponent<Player>();

			if (player != null) 
			{
				if (powerupID == 0)
				{
					player.TripleShotTurnedOn();
				}
				else if (powerupID == 1) 
				{
					player.SpeedBoostTurnedOn();
				}
				else if (powerupID == 2)
				{
					player.Shield();
				}
				else
				{
					Debug.Log("powerupID of powerup not defined");
				}
				AudioSource.PlayClipAtPoint(_powerupAudio, Camera.main.transform.position, 1f);
				DestroyObject(gameObject);
			}
		}
	}
}
