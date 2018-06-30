using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;

    private GameObject enemy;

	// Update is called once per frame
	void Update ()
	{
	   objectToPan.LookAt(targetEnemy);
	}
}
