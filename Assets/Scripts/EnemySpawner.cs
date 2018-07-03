using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)] [SerializeField] private float secondsBetweenSpawns = 2f;
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private Transform enemyParentTransform;

	// Use this for initialization
	void Start ()
	{
        StartCoroutine(RepeatedlySpawnEnemies());
    }
	
            
    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);

            if (enemyPrefab == null)
            {
                throw new NullReferenceException("Enemy does not exist.");
            }
        }
    }
}
