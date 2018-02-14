using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	[SerializeField] float _laserSpeed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LaserFired();
		DestroyLaser();
	}

	void LaserFired()
	{
		transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
	}
	void DestroyLaser()
	{
		float laserLocation = gameObject.transform.position.y;
		if (laserLocation > 6)
		{
			DestroyObject(gameObject);
		}
	}
}
