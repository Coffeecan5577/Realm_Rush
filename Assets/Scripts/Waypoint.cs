﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    // This is ok since this is a data class.
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    private const int gridSize = 10;

    private Vector2Int gridPosition;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize), Mathf.RoundToInt(transform.position.z / gridSize));
    }


    private void OnMouseOver()
    { 
    
        bool mouseClicked = Input.GetMouseButtonDown(0); // left mouse button.
        if (mouseClicked && isPlaceable)
        {

            FindObjectOfType <TowerFactory>().AddTower(this);
        }
        

    }

}
