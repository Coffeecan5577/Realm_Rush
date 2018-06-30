using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	    Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
	    var path = pathfinder.GetPath();
	    StartCoroutine(FollowPath(path));
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
            yield return new WaitForSeconds(2f);
        }
        print("Ending patrol");
    }
}
