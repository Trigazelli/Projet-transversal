using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MouseDragHinge : MonoBehaviour
{
    [SerializeField] private float speed;
    //This script is used to pick up 2d rigid bodies and spin them/throw them
    public Rigidbody2D rb;

    GameObject HingePoint;
    HingeJoint2D hinge;

    Vector2 velocity;
    Vector2 lastPosition;
    Vector2 objPosition;

    bool move = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Finds a GameObject with the name "HingePoint"
        HingePoint = GameObject.Find("HingePoint");
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        HingePoint.transform.position = new Vector3(mousePosition.x, mousePosition.y, HingePoint.transform.position.z);
    }

    private void OnMouseDown()
    {
        //Saves the mouse position to screen coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        HingePoint.transform.position = new Vector3(mousePosition.x, mousePosition.y, HingePoint.transform.position.z);

        //Saves the HingeJoint2D component to variable that we can use
        hinge = HingePoint.GetComponent(typeof(HingeJoint2D)) as HingeJoint2D;
        //A Boolean that indicates we can start calculating movement
        move = true;
        //Reenables the hinge which is likely disabled after OnMouseUp is used
        hinge.enabled = true;
        //Assigns whatever rigid body we have clicked on to our hinge
        hinge.connectedBody = rb;
        //Prevents the hinge from adjusting the anchorpoint during fixed update, this well be set to true in OnMouseUp
        hinge.autoConfigureConnectedAnchor = false;

    }

    private void FixedUpdate()
    {
        if (move == true)
        {
            //Saves the mouse position to screen coordinates
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            HingePoint.transform.position = new Vector3(mousePosition.x, mousePosition.y, HingePoint.transform.position.z);

            //-----Continuously calculates the velocity to apply to the object after it has been thrown-----
            //Takes the current object postition to use for the velocity calculation
            objPosition = transform.position;
            //Calculates velocity
            velocity = (objPosition - lastPosition) / (Time.fixedDeltaTime);
            //Saves the current position for use in the next velocity calculation
            lastPosition = transform.position;

        }
    }

    private void OnMouseUp()
    {
        //Removes the hinges influence from the rigidbody
        hinge.connectedBody = null;
        //Allows the Anchor point to be moved for when we click on a new rigid body
        hinge.autoConfigureConnectedAnchor = true;
        //Disables the rigid body
        hinge.enabled = false;
        //Stops the calculations in FixedUpdate
        move = false;
        //Combines the velocity from the mouse with the velocity from the hinge and applies it to the desired rigid body
        rb.velocity = rb.velocity + velocity * speed;
    }
}