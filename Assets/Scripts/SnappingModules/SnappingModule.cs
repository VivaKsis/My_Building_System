using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SnappingModule : ScriptableObject
{
    public abstract Vector3 GetPosition(BuildingInfo buildingInfo, Vector3 initialPosition, Field field);
}
