using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private Transform towerParentTransform;

    // Create an empty queue of towers.
    private readonly Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        var towerCount = towerQueue.Count;
        if (towerCount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
       var newTower =  Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;

        newTower.BaseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower); 
    }

    private void MoveExistingTower(Waypoint newBaseWayPoint)
    {
        var oldTower = towerQueue.Dequeue();

        // set the placeable flags.
        oldTower.BaseWaypoint.isPlaceable = true;
        newBaseWayPoint.isPlaceable = false;

       // set the baseWayPoints
        oldTower.BaseWaypoint = newBaseWayPoint;

        oldTower.transform.position = newBaseWayPoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }

    private void ShowTowerQueueCount()
    {
        print("Tower Queue Count is: " + towerQueue.Count);
    }
}
