using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlacementModule : ScriptableObject
{
    [SerializeField] protected SnappingModule snappingModule;
    public SnappingModule _SnappingModule => snappingModule;
  
    public abstract void Place(BuildingInfo buildingInfo, GameObject gameobject, RaycastHit raycastHit, Field field);
}
