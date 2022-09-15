using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipMovement : MonoBehaviour
{
    // Variables
    private Rigidbody2D shipRB;
    private bool yPosFrozen = true;
    public static event Action CollissionEvent;
    
    private float vertSpeed = 20f;
    private float horiSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        // GET COMPONENTS
        shipRB = GetComponent<Rigidbody2D>();
        
        

        // SET SHIP STARTING LOCATION
        shipRB.transform.position = new Vector3(-7f, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //FreezeCheck();

        ShipInput();
    }

    private void FixedUpdate()
    {
        //FreezeCheck();
    }


    // This locks the posistion of the ship when no buttons are being touched. 
    void FreezeCheck()
    {
        if(yPosFrozen == true)
        {
            shipRB.constraints = RigidbodyConstraints2D.FreezePositionX;
            shipRB.constraints = RigidbodyConstraints2D.FreezePositionY;
            shipRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            shipRB.constraints = RigidbodyConstraints2D.None;
            shipRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    // Manages the movement of the ship in space
    void ShipInput()
    {

        if (Input.GetAxisRaw("Vertical") > 0f)//UP
        {
            Debug.Log("Up pressed");
            yPosFrozen = false;
            shipRB.AddForce(new Vector2(0,.2f) * vertSpeed);
            yPosFrozen = true;
            

        }
        if (Input.GetAxisRaw("Vertical") < 0f)//DOWN
        {
            Debug.Log("Down pressed");
            yPosFrozen = false;
            shipRB.AddForce(new Vector2(0, -.2f) * vertSpeed);
            yPosFrozen = true;
            
        }
        if (Input.GetAxisRaw("Horizontal") > 0f)//RIGHT
        {
            Debug.Log("Right pressed");
            yPosFrozen = false;
            shipRB.AddForce(new Vector2(.2f,0) * horiSpeed);
            yPosFrozen = true;
        }
     
        if (Input.GetAxisRaw("Horizontal") < 0f)//LEFT
        {
            Debug.Log("Left pressed");
            yPosFrozen = false;
            shipRB.AddForce(new Vector2(-.2f, 0) * horiSpeed);
            yPosFrozen = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("hit detected");
        CollissionEvent?.Invoke();
    }
}
