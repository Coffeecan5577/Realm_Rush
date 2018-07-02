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

    private  List<Waypoint> path = new List<Waypoint>(); 

    private readonly Vector2Int[] _directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;

    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        SetAsPath(endingWayPoint);

        Waypoint previous = endingWayPoint.exploredFrom;

        while (previous != startingWayPoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }
        SetAsPath(startingWayPoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint wayPoint)
    {
        path.Add(wayPoint);
        wayPoint.isPlaceable = false;
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
            if (grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbors(neighborCoordinates);
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

    

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (var waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPosition();
            if (grid.ContainsKey(gridPos))
            {
                
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startingWayPoint);
        while (queue.Count > 0 && _isRunning)
        {
            _searchCenter = queue.Dequeue();
            _searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();
        }
    }

    private void HaltIfEndFound()
    {
        if (_searchCenter == endingWayPoint)
        {
            _isRunning = false;
        }
    }
}
