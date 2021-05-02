using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public int right, up, forward, roll;
    public int mouseX, mouseY;

    private Rigidbody rb;

    // by speed its really acceleration
    private float mainThrustSpeed = 40.0f;
    // again, more like acceleration
    // these this is for the force application at specific places
    // for turning and going backwards
    private float auxThrustSpeed = 8.0f;

    // rotation speed 
    // different since it is applying torque, not force
    private float rotSpeed = 0.5f;
    
    // the maximum speed that the ship can go
    // might want to set a maxForewardSpeed and maxSideSpeed
    private float maxSpeed = 1000.0f;


    private void Awake() 
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }


    private void FixedUpdate() 
    {
        #region Keyboard Controls
        // force application based on the keyboard inputs from PlayerController
        if(right == 1)
        {
            rb.AddForce(transform.right * auxThrustSpeed);
        }
        if(right == -1)
        {
            rb.AddForce(-transform.right * auxThrustSpeed);
        }
        if(forward == 1)
        {
            rb.AddForce(transform.up * mainThrustSpeed);
        }
        if(forward == -1)
        {
            rb.AddForce(-transform.up * mainThrustSpeed);
        }

        if(up == 1)
        {
            rb.AddForce(transform.forward * auxThrustSpeed);
        }
        if(up == -1)
        {
            rb.AddForce(-transform.forward * auxThrustSpeed);
        }

        if(roll == 1)
        {
            rb.AddTorque(transform.up * rotSpeed);
        }
        if(roll == -1)
        {
            rb.AddTorque(-transform.up * rotSpeed);
        }
        #endregion


        #region Mouse Controls
        // mouse controls from input in PlayerControllers
        if(mouseX == 1)
        {
            rb.AddTorque(-transform.forward * auxThrustSpeed * Input.GetAxis("Mouse X"));
        }
        if(mouseY == 1)
        {
            rb.AddTorque(-transform.right * auxThrustSpeed * Input.GetAxis("Mouse Y"));
        }
        #endregion


        // max speed limiter
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;

    }
}
