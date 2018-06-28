using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Block> _path;


	// Use this for initialization
	void Start ()
	{
	    PrintAllWaypoints();
        // Execution goes back to here.
	}
    // Update is called once per frame
	void Update ()
	{
		
	}

    private void PrintAllWaypoints()
    {
        foreach (var waypoint in _path)
        {
            print(waypoint.name);
        }
    }
}
