using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Builder/BuildingInfo")]
public class BuildingInfo : ScriptableObject
{
    [SerializeField] private GameObject _building;
    public GameObject _Building => _building;

    [SerializeField] private BuildingGOProvider _buildingGOProvider;
    public BuildingGOProvider _BuildingGOProvider => _buildingGOProvider;

    [SerializeField] private BuildingProgrammability _buildingProgrammability;
    public BuildingProgrammability _BuildingProgrammability => _buildingProgrammability;
}
