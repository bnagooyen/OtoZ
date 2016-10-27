using UnityEngine;
using System.Collections;

public class LaneSpawner : MonoBehaviour {

    public GameObject[] lanes;
    public float spawnHorizon = 500f;
    private float offsetNextLane;
    public GameObject player;
    public Transform spawnParent;
    public float laneLength = 40.0f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float positionForward = player.transform.position.z;

        if(positionForward + spawnHorizon > offsetNextLane)
        {

            GameObject lane = lanes[0];
            Vector3 nextLanePosition = offsetNextLane * Vector3.forward;
            Quaternion spawnRotation = Quaternion.Euler(0, 90, 0); ;
            GameObject newLane = Instantiate(lane, nextLanePosition, spawnRotation) as GameObject;
            newLane.transform.parent = spawnParent;
            offsetNextLane += laneLength;
          


        }


	}
}
