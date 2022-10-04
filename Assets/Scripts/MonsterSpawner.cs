using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] monsters;
	int randomSpawnPoint, randomMonster;
	public static bool spawnAllowed;
	int spawnLimit = 4;
	int spawned;

	private GameObject Monster;

	// Use this for initialization
	void Start()
	{
		spawnAllowed = true;
		InvokeRepeating("SpawnAMonster", 0f, 4f);
		Monster = GameObject.FindWithTag("Enemy");
	}

	private void Update()
	{
		monsterLimit();

	}

	void SpawnAMonster()
	{
		if (spawnAllowed)
		{
			randomSpawnPoint = Random.Range(0, spawnPoints.Length);
			randomMonster = Random.Range(0, monsters.Length);
			Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position,
				Quaternion.identity);
		}

	}

    void monsterLimit()
	{
		if (spawned <= spawnLimit)
		{
			spawnAllowed = true;
			spawned++;
			Debug.Log("disable spawn");
		}

		else if (spawned >= spawnLimit)
		{
			spawnAllowed = false;
			Debug.Log("disable spawn");
		}
	}

}
