using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField] private GameObject _enemyShipPrefab;
	[SerializeField] private GameObject[] _powerups;

	// Use this for initialization
	void Start () {
		StartCoroutine(EnemySpawn());
	}

	IEnumerator EnemySpawn()
	{
		System.Random random = new System.Random();

		while (true)
		{
			Instantiate(_enemyShipPrefab, new Vector3(random.Next(-75, 75)/10f, 6.5f, 0f), Quaternion.identity);
			yield return new WaitForSeconds(5);
		}
	}
	

}
