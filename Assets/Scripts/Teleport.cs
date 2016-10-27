using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(LaserPointer))]

public class Teleport : MonoBehaviour {

    public LaserPointer laserPointer;
    public ControllerEvents controllerEvents;
    private Transform target;
    private RaycastHit hitInfo;
    public Transform cameraRig; 

    private void OnEnable()
    {

        laserPointer.PointerOn += TeleportPosition;
        controllerEvents.TriggerReleased += HandleTriggerRelease;

    }

    private void HandleTriggerRelease(object sender, ControllerEvents.ControllerInteractionEventArgs e)
    {

        if (target.GetComponent<Terrain>() || target.gameObject.tag == "Road")
        {
            if (hitInfo.distance < 100f)
            {
                //var terrainHeight = Terrain.activeTerrain.SampleHeight(hitInfo.point);
                //float y = (terrainHeight > hitInfo.point.y) ? hitInfo.point.y : terrainHeight;
                float y =  hitInfo.point.y;
                cameraRig.transform.position = new Vector3(hitInfo.point.x, y, hitInfo.point.z);
            }
        }
        
    }

    private void TeleportPosition(object sender, LaserPointer.PointerEventArgs e)
    {

        target = e.target;
        hitInfo = e.hitInfo;

        
    }
}
