using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlacementModuleBasic", menuName = "Builder/PlacementModules/PlacementModuleBasic")]
public class PlacementModuleBasic : PlacementModule
{
    public override void Place(BuildingInfo buildingInfo, GameObject gameobject, RaycastHit raycastHit, Field field)
    {
        Vector3 nodePosition = field.GetNodePosition(raycastHit.point);
        Vector3 gameObjectPosition = snappingModule.GetPosition(buildingInfo, nodePosition, field);
        gameobject.transform.position = gameObjectPosition;
    }
}
