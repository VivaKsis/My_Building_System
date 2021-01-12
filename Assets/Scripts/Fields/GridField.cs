using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridField : Field
{
    [SerializeField] private GameObject _node;
    public GameObject _Node => _node;

    private static int height = 10, width = 10;
    private GameObject [,]grid;

    public override GameObject GetNode(int x, int y)
    {
        return grid[x, y];
    }
    public override Vector3 GetNodePosition(Vector3 approxPosition)
    {
        return new Vector3(Mathf.Round(approxPosition.x), Mathf.Round(approxPosition.y), Mathf.Round(approxPosition.z));
    }
    public override List<GameObject> GetNodesForBuilding(GameObject building, RaycastHit _raycastHit) // for now only works with BoxCollider
    {
        BoxCollider boxCollider = building.GetComponent<BoxCollider>();

        int width = (int)boxCollider.size.x, height = (int)boxCollider.size.y;

        List<GameObject> nodes = new List<GameObject>();

        Vector3 firstNodePosition = GetNodePosition(_raycastHit.point);

        for (int a = 0; a < width; a++)
        {
            for (int b = 0; b < height; b++)
            {
                try
                {
                    nodes.Add(grid[(int)firstNodePosition.x + a,
                                   (int)firstNodePosition.y + b]);
                }
                catch
                {
                    nodes.Add(null);
                }
            }
        }
        return nodes;
    }

    public override void SetUp()
    {
        for (int a = 0; a < width; a++)
        {
            for (int b = 0; b < height; b++)
            {
                grid[a,b] = Instantiate(
                    original: _node,
                    position: new Vector2(a, b),
                    rotation: Quaternion.identity,
                    parent: transform
                    );

                grid[a, b].name = "( " + a + ", " + b + " )";
            }
        }
    }

    private void Start()
    {
        grid = new GameObject[width, height];
        SetUp();
    }
}
