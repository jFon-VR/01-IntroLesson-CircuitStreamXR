using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Grabbable
{
    public Light light;

    protected override void Start()
    {
        base.Start();
        light.enabled = false;   
    }

    public override void OnTriggerStart()
    {
        base.OnTriggerStart();
        light.enabled = true;
    }

    public override void OnTriggerEnd()
    {
        base.OnTriggerEnd();
        light.enabled = false;
    }
}
