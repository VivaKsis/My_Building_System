using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Field : MonoBehaviour
{
    // Contains Vector3 positions of nodes on the field.

    public abstract GameObject GetNode(int x, int y);
    public abstract List<GameObject> GetNodesForBuilding(GameObject building, RaycastHit _raycastHit);
    public abstract Vector3 GetNodePosition(Vector3 approxPosition);
    public abstract void SetUp();
}
