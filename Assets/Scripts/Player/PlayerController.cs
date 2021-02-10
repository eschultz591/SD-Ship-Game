using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // stores movement values such as speed and max speed
    // The idea here is that we can separate player functionality over smaller functoins
    // as well as separate values which need to be called from by other scripts




    // does nothing as of now, will use this when we have animations
    private Animator animator;

    private Rigidbody rb;

    private ScannerScript scanner;
    private MovementController mc;

    // by speed its really acceleration
    private float mainThrustSpeed = 20.0f;
    // again, more like acceleration
    // these this is for the force application at specific places
    // for turning and going backwards
    private float auxThrustSpeed = 8.0f;

    // rotation speed 
    // different since it is applying torque, not force
    private float rotSpeed = 0.5f;
    
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

        scanner = gameObject.GetComponent<ScannerScript>();
        mc = gameObject.GetComponent<MovementController>();
        Cursor.lockState = CursorLockMode.Locked;



    }

    // Updates when frame is finished 
    private void Update() 
    {
        #region Keyboard based movement inputs

        // mouse toggle
        if(Input.GetButtonDown("MouseToggle"))
        {
            Debug.Log("mouse control " + mouseControl);
            Debug.Log("lock state " + Cursor.lockState);

            Cursor.lockState = mouseControl?CursorLockMode.Confined:CursorLockMode.Locked;

            mouseControl = !mouseControl;
            Cursor.visible = !mouseControl;


        }



        // this set handles one input directions
        if(Input.GetAxis("Forward") > 0)
        {
            mc.forward = 1;
        }
        if(Input.GetAxis("Forward") < 0)
        {
            mc.forward = -1;
        }
        if(Input.GetAxis("Forward") == 0)
        {
            mc.forward = -0;
        }

        if(Input.GetAxis("Right") > 0)
        {
            mc.right = 1;
        }
        if(Input.GetAxis("Right") < 0)
        {
            mc.right = -1;
        }
        if(Input.GetAxis("Right") == 0)
        {
            mc.right = 0;
        }

        if(Input.GetAxis("Up") > 0)
        {
            mc.up = 1;
        }
        if(Input.GetAxis("Up") < 0)
        {
            mc.up = -1;
        }
        if(Input.GetAxis("Up") == 0)
        {
            mc.up = 0;
        }

        if(Input.GetAxis("Roll") > 0)
        {
            mc.roll = 1;
        }
        if(Input.GetAxis("Roll") < 0)
        {
            mc.roll = -1;
        }
        if(Input.GetAxis("Roll") == 0)
        {
            mc.roll = 0;
        }

        #endregion


        #region Mouse based movement inputs
        //Debug.Log("screen mouse pos" + Camera.main.ScreenToViewportPoint( Input.mousePosition));


        //Debug.Log(Input.GetAxis("Mouse X"));

        if(mouseControl)
        {
            if(Input.GetAxis("Mouse X") != 0)
            {
                mc.mouseX = 1;
            }
            if(Input.GetAxis("Mouse X") == 0)
            {
                mc.mouseX = 0;
            }

            if(Input.GetAxis("Mouse Y") != 0)
            {
                mc.mouseY = 1;
            }
            if(Input.GetAxis("Mouse Y") == 0)
            {
                mc.mouseY = 0;
            }

            // test script for stopping rotation and velocity
            if(Input.GetButtonDown("Stop"))
            {
                rb.velocity.Set(0f,0f,0f);
                rb.angularVelocity.Set(0f,0f,0f);
            }
        }


        if(!mouseControl)
        {
            if(Input.GetButtonDown("LeftMouse"))
            {
                scanner.ScanObject();
                // here you will now use the mosue control for interaction with the world
                // the cursor should make itself known now and it will be bound to the window
                // will probably use a raycast from the camera for interaction with the world
            }

            // test stuff to check if an object is in the log properly
            if(Input.GetButtonDown("Stop"))
            {
                scanner.CheckLog();
            }

        }       

        #endregion


    // max speed limiter
    if (rb.velocity.magnitude > maxSpeed)
        rb.velocity = rb.velocity.normalized * maxSpeed;

    }




    
}


