using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffects : MonoBehaviour {

	// Clean up empty explosion game objects
	void Start () {
		DestroyObject(gameObject, 4);
	}
	
}
