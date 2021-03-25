using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public string thumbstickInputName;
    public float thumbstickThresholdValue = -0.5f;
    public LineRenderer beam;
    public float range;
    public Color validColor;
    public Color invalidColor;
    public GameObject teleportIndicator;
    public Transform player;

    private bool hasValidTeleportTarget;


    // Start is called before the first frame update
    void Start()
    {
        SetBeamVisible(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If the thumbstick is pressed forward
        if (Input.GetAxis(thumbstickInputName) < thumbstickThresholdValue)
        {
            //Show the beam
            SetBeamVisible(true);

            //Extend beam out to it's maximum range
            SetBeamEndpoint(transform.position + (transform.forward * range));

            // Check if beam hits something
            if (Physics.Raycast(transform.position, transform.forward,out var hit, range))
            {
                // Update the beam's endpoint to point in space that it hit
                SetBeamEndpoint(hit.point);
                // Is the object we hit a valid teleport target
                if (IsValideTeleportTarget(hit.collider.gameObject))
                {
                    // Set the beam to be valid
                    SetTeleportValid(true);

                    //Set position of the teleport indicator
                    teleportIndicator.transform.position = hit.point + Vector3.up * 0.001f;
                }
                // If the object we hit is an invalid teleport target
                else
                {
                    // set beam to be invalid
                    SetTeleportValid(false);
                }
            }
            //If beam doesn't hit anything
            else
            {
                //Set beam to be invalid
                SetTeleportValid(false);
            }

        }
        // If the thumbstick is released
        else
        {
            //Hide the beam
            SetBeamVisible(false);

            // Do we have a valid teleport target
            if (hasValidTeleportTarget)
            {
                // True- Teleport player there
                player.position = teleportIndicator.transform.position;
            }

            //Reset teleport
            SetTeleportValid(false);

        }

        
    }

    private void SetTeleportValid(bool valid)
    {
        // Set the color of the beam
        beam.material.color = valid ? validColor : invalidColor;

        // Show or hide the teleport indicator
        teleportIndicator.SetActive(valid);

        // Remember whether or not we have a valid target
        hasValidTeleportTarget = valid;
    }

    private bool IsValideTeleportTarget(GameObject gameObject)
    {
        return true;
    }

    private void SetBeamEndpoint(Vector3 endpoint)
    {
        beam.SetPosition(0, transform.position);
        beam.SetPosition(1, endpoint);
    }

    private void SetBeamVisible(bool visible)
    {
        beam.enabled = visible;
    }
}
