using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Grabbable
{
    public GameObject laserBeam;
    public float throwImpulse;
    public AudioClip laserPew;
    public float laserVolume = 1;


    public override void OnTriggerStart()
    {
        base.OnTriggerStart();
        //Spawn laser beam
        GameObject beam = Instantiate(laserBeam, transform.position, transform.rotation);
        
        //Add impulse
        beam.GetComponent<Rigidbody>().AddForce(transform.up * throwImpulse);

        //play SFX
        AudioSource.PlayClipAtPoint(laserPew, transform.position, laserVolume);
    }
}
