using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Tooltip("Value to snap blocks to in grid.")][Range(1f, 20f)] [SerializeField] private float gridSize = 10f;
    

    private TextMesh textMesh;

    void Update()
    {
        SnapCubePosition();
    }

    private void SnapCubePosition()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;

        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPosition.x, 0, snapPosition.z);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPosition.x + "," + snapPosition.z / gridSize;
    }

}
