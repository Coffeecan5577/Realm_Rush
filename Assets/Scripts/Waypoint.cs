using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;

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

    public void SetTopColor(Color color)
    {
        var topQuadMeshRenderer = transform.Find("Top Quad").GetComponent<MeshRenderer>();
        topQuadMeshRenderer.material.color = color;
    }
}
