using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildConditionOverlap", menuName = "Builder/BuildConditions/BuildConditionOverlap")]
public class BuildConditionOverlap : BuildCondition
{
    [SerializeField] private LayerMask _layerMaskOccupiedNode;
    public LayerMask _LayerMaskOccupiedNode => _layerMaskOccupiedNode;

    private bool DoesNodeExist(GameObject node)
    {
        return node == null ? false : true;
    }

    private bool IsNodeAlreadyOccupied(GameObject node)
    {
        Vector3 overlapBoxPosition = new Vector3(node.transform.position.x, node.transform.position.y, Mathf.Round(node.transform.position.z));
        Collider[] hitColliders = Physics.OverlapBox(overlapBoxPosition, node.transform.localScale * 0.1f, Quaternion.identity, _layerMaskOccupiedNode);

        return hitColliders.Length == 0 ? false : true;
    }

    public override bool IsSatisfied(GameObject gameObject, RaycastHit raycastHit, Field field)
    {
        List<GameObject> nodes = field.GetNodesForBuilding(gameObject, raycastHit);

        for (int a = 0; a < nodes.Count; a++)
        {
            if(!DoesNodeExist(nodes[a]) || IsNodeAlreadyOccupied(nodes[a])){
                return false;
            }
        }

        return true;
    }
}
