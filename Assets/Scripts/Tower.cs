using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;
    [SerializeField] private float attackRange = 30f;
    [SerializeField] private ParticleSystem towerBullets;

    private GameObject enemy;
  

    void Start()
    {

    }

	// Update is called once per frame
	void Update ()
	{
	    if (targetEnemy)
	    {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
	    else
	    {
	        Shoot(false);
	    }
	   
	}

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, transform.position);
        towerBullets = GetComponentInChildren<ParticleSystem>();
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = towerBullets.emission;
        emissionModule.enabled = isActive;
    }
}
