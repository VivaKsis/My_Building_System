using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingProgrammability", menuName = "Builder/BuildingProgrammability")]
public class BuildingProgrammability : ScriptableObject
{
    [SerializeField] private PlacementModule _placementModule;
    public PlacementModule _PlacementModule => _placementModule;

    [SerializeField] private BuildCondition _buildCondition;
    public BuildCondition _BuildCondition => _buildCondition;

    public void Execute(BuildingInfo buildingInfo, GameObject gameobject, RaycastHit raycastHit, Field field)
    {
        _placementModule.Place(buildingInfo, gameobject, raycastHit, field);
    }

    public bool BuildPermitted(GameObject gameObject, RaycastHit raycastHit, Field field)
    {
        if (_buildCondition.IsSatisfied(gameObject, raycastHit, field))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Exit(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
