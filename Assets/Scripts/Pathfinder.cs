using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Waypoint startingWayPoint, endingWayPoint;

    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    private bool _isRunning = true;

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
	    Pathfind();
	    //ExploreNeighbors();
	}

    private void ExploreNeighbors(Waypoint from)
    {
        if (!_isRunning)
        {
            return;
        }
        foreach (var direction in _directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPosition() + direction;
            try
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            catch
            {
                
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored)
        {
           
        }
        else
        {
            neighbor.SetTopColor(Color.cyan); // TODO move later
            queue.Enqueue(neighbor);
            print("Queueing " + neighbor.name);
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

    private void Pathfind()
    {
        queue.Enqueue(startingWayPoint);
        while (queue.Count > 0 && _isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from: " + searchCenter);
            searchCenter.isExplored = true;
            HaltIfEndFound(searchCenter);
            ExploreNeighbors(searchCenter);
        }

        // TODO work-out path!
        print("Finished pathfinding?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endingWayPoint)
        {
            print("Searching from end node, therefore stopping."); //TODO remove log when working.
            _isRunning = false;
        }
    }
}
