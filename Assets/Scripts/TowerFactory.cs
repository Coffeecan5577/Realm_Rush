using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;

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
        baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(newTower); 
    }

    private void MoveExistingTower(Waypoint baseWayPoint)
    {
        var oldTower = towerQueue.Dequeue();

        // set the placeable flags.
       

       // set the baseWayPoints
        

       // put the old tower back on top of the queue.
        towerQueue.Enqueue(oldTower);
    }

    private void ShowTowerQueueCount()
    {
        print("Tower Queue Count is: " + towerQueue.Count);
    }
}
