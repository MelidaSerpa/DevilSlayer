using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    [SerializeField]
    private GameObject[] spawnPoints;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    public static bool spawnAllowed;


    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnMonsters", 0f, 1f);
    }

    void SpawnMonsters()
    {
        if (spawnAllowed)
        {
            randomSide = Random.Range(0, spawnPoints.Length);
            randomIndex = Random.Range(0, monsterReference.Length);

            //Instantiate (monsterReference [randomIndex], spawnPoints [randomSide].position, 
                //Quaternion.identity);
        }


    }



}
