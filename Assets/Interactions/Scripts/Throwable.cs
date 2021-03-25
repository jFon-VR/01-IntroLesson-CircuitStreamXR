using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : Grabbable
{
    private FixedJoint joint;
    private Vector3 prevPosition;
    private Queue<Vector3> previousVelocities = new Queue<Vector3>();
    public int numVelocitySampes = 10;
    public float throwBoost = 1;

    public override void OnGrab(Grabber grabber)
    {
        // Add a fixed joint between this object's rigid body and the grabber's rigid body
        joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = grabber.GetComponent<Rigidbody>();
        Debug.Log($"{joint.connectedBody.name}");

    }

    public override void OnDrop()
    {
        //Remove the fixed joint
        Destroy(joint);

        //Calculate the average velocity from all velocity samples
        Vector3 averageVelocity = Vector3.zero;
        foreach(Vector3 velocity in previousVelocities)
        {
            averageVelocity += velocity;
        }
        averageVelocity /= previousVelocities.Count;

        //Apply the calculated average velocity to the rigid body to throw it (with an optional boost)
        GetComponent<Rigidbody>().velocity = averageVelocity * throwBoost;
    }

    private void Update()
    {
        //Calculate the velocity of the object since the last update
        Vector3 velocity = transform.position - prevPosition;
        
        //Remember the position from this update so we can calculate the velocity in the next update
        prevPosition = transform.position;

        //Add this calculated velocity to the list of previous velocities
        previousVelocities.Enqueue(velocity);

        // Make sure we don't store too many previous velocity samples
        if(previousVelocities.Count > numVelocitySampes)
        {
            //Toss out the oldest sample
            previousVelocities.Dequeue();
        }
    }

}
