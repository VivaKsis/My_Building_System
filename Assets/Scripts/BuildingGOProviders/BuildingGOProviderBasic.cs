using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingGOProviderBasic", menuName = "Builder/BuildingGOProviders/BuildingGOProviderBasic")]
public class BuildingGOProviderBasic : BuildingGOProvider
{
    public override GameObject Provide(GameObject gameObject)
    {
        return Instantiate(gameObject);
    }
}
