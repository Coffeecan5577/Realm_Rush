using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _path;


	// Use this for initialization
	void Start ()
	{
	    //StartCoroutine(FollowPath());
	}
    // Update is called once per frame
	void Update ()
	{
		
	}

    //IEnumerator FollowPath()
    //{
    //    print("Starting Patrol: ");
    //    foreach (var waypoint in _path)
    //    {
    //        transform.position = waypoint.transform.position;
    //        print("Visiting Block: " + waypoint.name );
    //        yield return new WaitForSeconds(1f);
    //    }
    //    print("Ending patrol");
    //}
}
