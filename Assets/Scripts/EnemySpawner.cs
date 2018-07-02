using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)] [SerializeField] private float secondsBetweenSpawns = 2f;
    [SerializeField] private EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start ()
	{
        StartCoroutine(RepeatedlySpawnEnemies());
    }
	
	// Update is called once per frame
	void Update ()
	{
	    
	}

    // co-routine
    // forever
        //Spawn enemy:
            
    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            print("Spawning new enemyPrefab...");
            yield return new WaitForSeconds(secondsBetweenSpawns);

            if (enemyPrefab == null)
            {
                throw new NullReferenceException("Enemy does not exist.");
            }
        }
    }
}
