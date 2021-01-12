using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SnappingModuleBasic", menuName = "Builder/SnappingModules/SnappingModuleBasic")]
public class SnappingModuleBasic : SnappingModule
{
    GameObject _gameObject;
    BoxCollider _boxCollider;

    Vector3 _boxColliderCenter;
    Vector3 _boxColliderSize;
    Vector3 _newPosition;

    private void SnapX()
    {
        _newPosition = new Vector3(_newPosition.x + 0.5f,
                                   _newPosition.y,
                                   _newPosition.z);
    }
    private void SnapY()
    {
        _newPosition = new Vector3(_newPosition.x,
                                   _newPosition.y + 0.5f,
                                   _newPosition.z);
    }

    public override Vector3 GetPosition(BuildingInfo buildingInfo, Vector3 nodePosition, Field field)
    {
        _gameObject = buildingInfo._Building;
        _boxCollider = _gameObject.GetComponent<BoxCollider>();

        _boxColliderCenter = _boxCollider.center;
        _boxColliderSize = _boxCollider.size;

        _newPosition = -_boxColliderCenter + nodePosition;
        _newPosition = new Vector3(Mathf.Round(_newPosition.x), Mathf.Round(_newPosition.y), Mathf.Round(_newPosition.z));

        if (_boxColliderCenter.x == 0 && _boxColliderSize.x % 2 == 0)
        {
            SnapX();
        }

        if (_boxColliderCenter.y == 0 && _boxColliderSize.y % 2 == 0)
        {
            SnapY();
        }

        if (_boxColliderCenter.x != 0 && _boxColliderSize.x % 2 != 0)
        {
            SnapX();
        }

        if (_boxColliderCenter.y != 0 && _boxColliderSize.y % 2 != 0)
        {
            SnapY();
        }

        _newPosition = new Vector3(_newPosition.x,
                                  _newPosition.y,
                                  _boxColliderSize.z / 2 - _boxColliderCenter.z);

        return _newPosition;
    }
}
