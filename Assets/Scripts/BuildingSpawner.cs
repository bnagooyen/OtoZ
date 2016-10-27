using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour {

    public GameObject[] buildings;
    Vector3 buildingStartPosition;
    int randomBuildingIndex;
    public float buildingStartingRotation = 90;

    void Awake()
    {
        
        InstantiateBuilding();

            

    }
	
    void InstantiateBuilding()
    {

        randomBuildingIndex = Random.Range(0, buildings.Length);
        GameObject newBuilding =  Instantiate(buildings[randomBuildingIndex]);
        newBuilding.transform.position = GetPosition();
        newBuilding.transform.rotation = Quaternion.Euler(0, buildingStartingRotation, 0);
        newBuilding.transform.parent = transform;

    }
	
	Vector3 GetPosition()
    {

        buildingStartPosition = transform.position;

        return buildingStartPosition;

    }

}
