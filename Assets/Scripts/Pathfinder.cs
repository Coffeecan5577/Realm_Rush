using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Waypoint startingWayPoint, endingWayPoint;

    private readonly Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    readonly Queue<Waypoint> queue = new Queue<Waypoint>();
    private bool _isRunning = true;
    private Waypoint _searchCenter;

    private readonly Vector2Int[] _directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

	private void Start ()
	{
	    LoadBlocks();
	    ColorStartAndEnd();
	    Pathfind();
	    ExploreNeighbors();
	}


    private void ExploreNeighbors()
    {
        if (!_isRunning)
        {
            return;
        }
        foreach (var direction in _directions)
        {
            Vector2Int neighborCoordinates = _searchCenter.GetGridPosition() + direction;
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
        if (neighbor.isExplored || queue.Contains(neighbor))
        {
           
        }
        else
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = _searchCenter;
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
            _searchCenter = queue.Dequeue();
            _searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();
        }

        
        print("Finished pathfinding?");
    }

    private void HaltIfEndFound()
    {
        if (_searchCenter == endingWayPoint)
        {
            _isRunning = false;
        }
    }
}
