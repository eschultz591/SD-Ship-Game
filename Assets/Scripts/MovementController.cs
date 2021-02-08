using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // stores movement values such as speed and max speed
    // The idea here is that we can separate player functionality over smaller functoins
    // as well as separate values which need to be called from by other scripts




    // does nothing as of now, will use this when we have animations
    private Animator animator;

    private Rigidbody rb;

    // by speed its really acceleration
    private float mainThrustSpeed = 20.0f;
    // again, more like acceleration
    // these this is for the force application at specific places
    // for turning and going backwards
    private float auxThrustSpeed = 8.0f;

    // rotation speed 
    // different since it is applying torque, not force
    private float rotSpeed = 1.0f;
    
    // the maximum speed that the ship can go
    // might want to set a maxForewardSpeed and maxSideSpeed
    private float maxSpeed = 100.0f;
    

    // might not need this
    // here in case we want to have something for toggling mouse movement
    private bool mouseControl = true;


    int up, forward, right;



    // the mouse position which the ship needs to face
    // private Vector3 heading;


    private void Awake() 
    {
        // initalization stuff
        rb = gameObject.GetComponent<Rigidbody>();
        //heading = new Vector3();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Updates when frame is finished 
    private void Update() 
    {
        
    }

    // Updates once a physics frame finishes
    private void FixedUpdate() 
    {
        #region Keyboard based movement inputs
        
        // this set handles one input directions
        if(Input.GetAxis("Forward") > 0)
        {
            rb.AddForce(transform.up * mainThrustSpeed);
        }
        if(Input.GetAxis("Forward") < 0)
        {
            rb.AddForce(-transform.up * auxThrustSpeed);
        }

        if(Input.GetAxis("Right") > 0)
        {
            rb.AddForce(transform.right * auxThrustSpeed);
        }
        if(Input.GetAxis("Right") < 0)
        {
            rb.AddForce(-transform.right * auxThrustSpeed);
        }

        if(Input.GetAxis("Up") > 0)
        {
            rb.AddForce(transform.forward * auxThrustSpeed);
        }
        if(Input.GetAxis("Up") < 0)
        {
            rb.AddForce(-transform.forward * auxThrustSpeed);
        }

        if(Input.GetAxis("Roll") > 0)
        {
            rb.AddTorque(transform.up * rotSpeed);
        }
        if(Input.GetAxis("Roll") < 0)
        {
            rb.AddTorque(-transform.up * rotSpeed);
        }

        
        #endregion


        #region Mouse based movement inputs
        //Debug.Log("screen mouse pos" + Camera.main.ScreenToViewportPoint( Input.mousePosition));


        Debug.Log(Input.GetAxis("Mouse X"));


        if(Input.GetAxis("Mouse X") != 0)
        {
            rb.AddTorque(-transform.forward * rotSpeed * Input.GetAxis("Mouse X"));
        }

        if(Input.GetAxis("Mouse Y") != 0)
        {
            rb.AddTorque(-transform.right * rotSpeed * Input.GetAxis("Mouse Y"));
        }

        // test script for stopping rotation and velocity
        if(Input.GetButtonDown("Stop"))
        {
            rb.velocity.Set(0f,0f,0f);
            rb.angularVelocity.Set(0f,0f,0f);
        }



        #endregion


    // max speed limiter
    if (rb.velocity.magnitude > maxSpeed)
        rb.velocity = rb.velocity.normalized * maxSpeed;

    }



    private void Rotate(int direction, int axis)
    {
        
    }

}
