using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	[SerializeField] private Field _field;
	public Field _Field => this._field;

	private BuildingInfo _activeBuildingInfo;
	private GameObject _activeGameObject;
	private RaycastHit _raycastHit;

	public void EnterBuildingProcess(BuildingInfo buildingInfo)
	{
		if (this._activeBuildingInfo != null)
		{
			this.ExitBuildingProcess(null);
		}

		this._activeBuildingInfo = buildingInfo;

		this._activeGameObject = this._activeBuildingInfo._BuildingGOProvider.Provide(this._activeBuildingInfo._Building);
	}

	public void ExitBuildingProcess(BuildingInfo buildingInfo)
	{
		this._activeBuildingInfo._BuildingProgrammability.Exit(this._activeGameObject);

		this._activeBuildingInfo = null;
		this._activeGameObject = null;
	}

	private void OccupyNodes(List<GameObject> nodes)
	{
		for (int a = 0; a < nodes.Count; a++)
		{
			nodes[a].transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
		}
	}

	public void Build() 
	{
		if (this._activeBuildingInfo._BuildingProgrammability.BuildPermitted(this._activeGameObject, this._raycastHit, this._field))
		{
			this.OccupyNodes(this._field.GetNodesForBuilding(this._activeGameObject, this._raycastHit));

			this._activeBuildingInfo = null;
			this._activeGameObject = null;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		if (Application.isPlaying && this._activeGameObject != null)
		{
			Vector3 gameObjectPosition = new Vector3(this._raycastHit.point.x, this._raycastHit.point.y, Mathf.Round(this._raycastHit.point.z));

			Gizmos.DrawWireCube(gameObjectPosition, this._activeGameObject.transform.localScale * 0.2f);
		}
	}

	[SerializeField] private RaycastEmitter _raycastEmitter;
	public RaycastEmitter _RaycastEmitter => this._raycastEmitter;

	private void Update()
	{
		if (this._activeBuildingInfo != null)
		{
			Ray ray = Camera.main.ScreenPointToRay(pos: Input.mousePosition);

			if (this._raycastEmitter.Raycast(ray: ray, raycastHit: out this._raycastHit))
			{
				this._activeBuildingInfo._BuildingProgrammability.Execute(_activeBuildingInfo, this._activeGameObject, this._raycastHit, this._field);

				if (Input.GetMouseButtonDown(0))
				{
					this.Build();
				}
			}
		}
	}
}
