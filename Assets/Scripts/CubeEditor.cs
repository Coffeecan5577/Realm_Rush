using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    [Tooltip("Value to snap blocks to in grid.")]
    
    private Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(waypoint.GetGridPosition().x, 0f, waypoint.GetGridPosition().y);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPosition().x / gridSize + "," + waypoint.GetGridPosition().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
