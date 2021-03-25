using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed;


    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("The start method was run!");
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object by a ? speed on the Y axis
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }
}
