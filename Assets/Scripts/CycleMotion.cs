using UnityEngine;
using System.Collections;
using System;

public class CycleMotion : MonoBehaviour {


    public Transform cameraRig;
    public ControllerEvents controllerEvents;

    private Vector3 cycleVector = Vector3.zero; 

    public float maxSpeed = 60.0f;
    public float minSpeed = 0.0f;
    public float horizontalSpeed = 4.0f;
    float acceleration;

    bool accelerating = false;


   
    void OnEnable()
    {
        controllerEvents.TriggerPressed += HandleTriggerPress;
        controllerEvents.TriggerReleased += HandleTriggerRelease;
        controllerEvents.TouchpadAxisChanged += HandleTouchpadAxisChange;

    }

   

    void OnDisable()
    {
        controllerEvents.TriggerPressed -= HandleTriggerPress;
        controllerEvents.TriggerReleased -= HandleTriggerRelease;
        controllerEvents.TouchpadAxisChanged -= HandleTouchpadAxisChange;
    }

    private void HandleTriggerPress(object sender, ControllerEvents.ControllerInteractionEventArgs e)
    {

        accelerating = true;


    }

    private void HandleTriggerRelease(object sender, ControllerEvents.ControllerInteractionEventArgs e)
    {
        accelerating = false;
    }

    private void HandleTouchpadAxisChange(object sender, ControllerEvents.ControllerInteractionEventArgs e)
    {

        cycleVector.x = e.touchpadAxis.x;
        cycleVector.z = e.touchpadAxis.y;
    }
    // Update is called once per frame
    void Update () {

        if (accelerating)
        {
            transform.Translate(0, 0, acceleration * Time.deltaTime);
            if (acceleration < maxSpeed)
            {
                acceleration += 0.03f;
            }
        }

        if (accelerating == false)
        {
            transform.Translate(0, 0, acceleration * Time.deltaTime);

            if (acceleration > minSpeed)
            {
                acceleration -= 0.05f;
            }
        }

        if(controllerEvents.touchpadTouched)
        {


            if (acceleration > 0)
            {
                Vector3 strafe = cameraRig.right * cycleVector.x * horizontalSpeed * Time.deltaTime;
                float playerY = cameraRig.position.y;
                cameraRig.position += strafe;
                cameraRig.position = new Vector3(cameraRig.position.x, playerY, cameraRig.position.z);
            } 

        }
    }



}
