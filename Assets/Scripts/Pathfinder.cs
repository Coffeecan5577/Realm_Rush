using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Waypoint startingWayPoint, endingWayPoint;

    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    private Vector2Int[] _directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

	void Start ()
	{
	    LoadBlocks();
	    ColorStartAndEnd();
	    ExploreNeighbors();
        print("Starting Position is: " + startingWayPoint);
	}

    private void ExploreNeighbors()
    {
        foreach (var direction in _directions)
        {
            Vector2Int explorationCoordinates = startingWayPoint.GetGridPosition() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.cyan);
            }
            catch (Exception e)
            {
                
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startingWayPoint.SetTopColor(Color.red);
        endingWayPoint.SetTopColor(Color.green);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (var waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPosition();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block: " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
