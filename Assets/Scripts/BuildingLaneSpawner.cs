using UnityEngine;
using System.Collections;

public class BuildingLaneSpawner : MonoBehaviour {

    [SerializeField]
    private Transform spawnerTransform;
    public GameObject[] lanes;
    public float spawnHorizon = 500f;
    private float offsetNextLane;
    public Transform spawnParent;
    public float laneLength = 40.0f;


    void Awake()
    {
        

    }


    void Update()
    {

        float positionForward = transform.position.z;

        if (positionForward + spawnHorizon > offsetNextLane)
        {

            
            GameObject lane = lanes[0];
            Vector3 nextLanePosition = offsetNextLane * Vector3.forward;
            nextLanePosition.x = transform.position.x;
            nextLanePosition.y = transform.position.y;
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0); ;
            GameObject newLane = Instantiate(lane, nextLanePosition, spawnRotation) as GameObject;
            newLane.transform.parent = spawnParent;
            offsetNextLane += laneLength;



        }

    }
}
