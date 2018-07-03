using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float movementPeriod = .5f;
    [SerializeField] private ParticleSystem goalParticle;
    private EnemyDamage selfDestructSequence;
    

    // Use this for initialization
    void Start ()
	{
	    Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
	    var path = pathfinder.GetPath();
	    StartCoroutine(FollowPath(path));
	    selfDestructSequence = GetComponent<EnemyDamage>();
	}
    // Update is called once per frame
	void Update ()
	{
		
	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting Patrol: ");
        foreach (var waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        print("Ending patrol");
        if (selfDestructSequence)
        {
            SelfDestruct();
        }
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, 1f);
        Destroy(gameObject);
    }
}
