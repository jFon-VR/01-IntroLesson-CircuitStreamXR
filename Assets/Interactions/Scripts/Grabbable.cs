using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public Color touchedColor;
    private Color initialColor;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Store initial color of object
        initialColor = GetComponent<Renderer>().material.color;

        //Store rigid body
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouched(Grabber grabber)
    {
        //Change the color of the object to touched color
        GetComponent<Renderer>().material.color = touchedColor;
    }

    public void OnUnTouched()
    {
        //Change the color back to the initial color
        GetComponent<Renderer>().material.color = initialColor;
    }

    public virtual void OnGrab(Grabber grabber)
    {
        //parent this to to the grabber
        transform.SetParent(grabber.transform);

        //Remove gravity, enable kinematic
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;

    }

    public virtual void OnDrop()
    {
        //Unparent object
        transform.SetParent(null);

        //Turn on physics
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
    }

    public virtual void OnTriggerStart()
    {

    }

    public virtual void OnTriggerEnd()
    {

    }
}
