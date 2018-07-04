using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)] [SerializeField] private float secondsBetweenSpawns = 2f;
    [SerializeField] private int playerScore = 0;
    [SerializeField] private int scoreAmount = 10;
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private Transform enemyParentTransform;
    [SerializeField] private Text scoreCounter;
    [SerializeField] private AudioClip spawnedEnemySFX;

	// Use this for initialization
	void Start ()
	{
        StartCoroutine(RepeatedlySpawnEnemies());
	    scoreCounter.text = playerScore.ToString();
	}
	
            
    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            yield return new WaitForSeconds(secondsBetweenSpawns);

            if (enemyPrefab == null)
            {
                throw new NullReferenceException("Enemy does not exist.");
            }
        }
    }

    private void AddScore()
    {
        playerScore += scoreAmount;
        scoreCounter.text = playerScore.ToString();
    }
}
