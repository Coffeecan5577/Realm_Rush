using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Collider collisionMesh;
    [SerializeField] private int hitPoints = 10;

	// Use this for initialization
	void Start ()
	{
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoints -= 1;
        print("Current hit points are: " + hitPoints);
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
	
	
}
