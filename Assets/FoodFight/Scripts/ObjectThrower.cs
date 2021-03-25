using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    public string triggerName;
    public Rigidbody[] objects;
    private Rigidbody heldObject;
    public float throwImpulse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the hand's trigger has been pressed
        if (Input.GetButtonDown(triggerName))
        {
            // Choose a random object
            Rigidbody randomObject = objects[Random.Range(0, objects.Length)];
            // if T: Spawn random object
            heldObject = Instantiate(randomObject, transform.position, transform.rotation, transform);
            // attach object to hand by turning off hand
            heldObject.useGravity = false;
            heldObject.isKinematic = true;
        }

        if (Input.GetButtonUp(triggerName))
        {
            //Detach object from hand
            heldObject.transform.SetParent(null); //.transform sets it to parent of the 
            heldObject.useGravity = true;
            heldObject.isKinematic = false;

            // Apply a force to the object to throw it
            heldObject.AddForce(transform.forward * throwImpulse);

        }

    }
}
