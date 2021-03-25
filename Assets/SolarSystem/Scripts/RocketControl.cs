using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float turningForce;
    private bool engineOn;
    public float engineForce;
    public GameObject engineLight;
    public float fuel;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        engineLight.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get values from mouse controls from x and y axis
        float yaw = Input.GetAxis("Mouse X");
        float pitch = -Input.GetAxis("Mouse Y");

        // Debug.Log($"Mouse X: {yaw}, Mouse Y: {pitch}");

        // Rotate the rocket using the mouse control
        rigidBody.AddRelativeTorque(
            pitch * turningForce * Time.deltaTime,  //Pitch
            yaw * turningForce * Time.deltaTime,    //Yaw
            0.0f);                                  //Roll
        
        // Turn the rocket engine when W is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (fuel > 0.0f)           //check if there's enough fuel
            {
                engineOn = true;
                engineLight.SetActive(true);
            }
        }

        // Turn the rocket engine when W is pressed
        if (Input.GetKeyUp(KeyCode.W))
        {
            engineOn = false;
            engineLight.SetActive(false);
        }


        // If engine is on
        if (engineOn)
        {
            rigidBody.AddForce(transform.forward * engineForce * Time.deltaTime);
            fuel= fuel - 1 * Time.deltaTime;
            if (fuel <= 0.0f)
            {
                engineOn = false;
                engineLight.SetActive(false);
            }
            // Debug.Log($"Fuel= {fuel}");
   
        }
    }
}
