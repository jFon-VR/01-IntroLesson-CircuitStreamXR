using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public string gripButton;
    public string triggerButton;

    private Grabbable touchedObject;
    private Grabbable grabbedObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the grab button is pressed
        if (Input.GetButtonDown(gripButton))
        {
            //Play gripped animation
            GetComponent<Animator>().SetBool("Gripped", true);

            //If we are touching something grippable
            if (touchedObject != null)
            {
                //let touched object know it's been grabbed
                touchedObject.OnGrab(this);

                //store the grabbed object
                grabbedObject = touchedObject;
            }
        }

        if (Input.GetButtonUp(gripButton))
        {   //Play ungrip animation
            GetComponent<Animator>().SetBool("Gripped", false);

            //If we have a grabbed object
            if(grabbedObject != null)
            {
                //Let grabbed object know it's been dropped
                grabbedObject.OnDrop();

                //clear grabbed object
                grabbedObject = null;
            }
        }

        if (Input.GetButtonDown(triggerButton))
        {
            if(grabbedObject != null)
            {
                //let the grabbed object know it's been triggered
                grabbedObject.OnTriggerStart();
            }
        }

        if (Input.GetButtonUp(triggerButton))
        {
            if(grabbedObject != null)
            {
                //let the grabbed object know it's been untriggered
                grabbedObject.OnTriggerEnd();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if object touched is a grabbable object
        Grabbable grabbable = other.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            //Let the object know it was touched
            grabbable.OnTouched(this);

            //store the currently touched object
            touchedObject = grabbable;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Grabbable grabbable = other.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            //Let object know it was untouched
            grabbable.OnUnTouched();

            //reset currently touched object
            touchedObject = null;
        }
      

    }
}
