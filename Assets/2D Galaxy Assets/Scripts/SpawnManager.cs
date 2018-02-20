using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField] private GameObject _enemyShipPrefab;
	[SerializeField] private GameObject[] _powerups;
	[SerializeField] private GameObject _playerPrefab;

	// Use this for initialization
	void Start () {
		StartCoroutine(PlayerSpawn());
		StartCoroutine(EnemySpawnRoutine());
		StartCoroutine(PowerupSpawnRoutine());
	}

	IEnumerator PlayerSpawn()
	{
		Instantiate(_playerPrefab, new Vector3(0,0,0), Quaternion.identity);
		yield return new WaitForSeconds(5);
	}

	IEnumerator EnemySpawnRoutine()
	{
		while (true)
		{
			Instantiate(_enemyShipPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 6.5f, 0f), Quaternion.identity);
			yield return new WaitForSeconds(5);
		}
	}
	
	IEnumerator PowerupSpawnRoutine()
	{
		while(true)
		{
			Instantiate(_powerups[Random.Range(0,3)], new Vector3(Random.Range(-7.5f, 7.5f), 6.5f, 0), Quaternion.identity);
			yield return new WaitForSeconds(5);
		}
	}

}
