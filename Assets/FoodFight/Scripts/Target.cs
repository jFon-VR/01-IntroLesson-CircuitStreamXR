using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed;
    public float range;
    public FoodFightGame game;
    public float minScale;
    public float maxScale;
    public int PointValue;

    private Vector3 initialPosition;



    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        SetRandomScaleAndPoints();
    }

    // Update is called once per frame
    void Update()
    {
        // Slide the target back and forth
        transform.position = initialPosition + transform.right * Mathf.Sin(Time.time * speed) * range;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"Target has been hit by {collision.collider.gameObject.name}"); //Get the name of the object that collides

        //Let the game know the target was hit
        game.OnTargetHit(this);

        // Destroy Target
        Destroy(gameObject);

    }

    private void SetRandomScaleAndPoints()
    {
        //Get a random scale factor
        float scaleFactor = Random.Range(minScale, maxScale);
        
        // scale the target based on the randomized scale factor
        Vector3 newScale = new Vector3 (scaleFactor,gameObject.transform.localScale.y,scaleFactor);
        gameObject.transform.localScale = newScale;

        //Set points value based on scale factor
        if (scaleFactor < 0.5)
        {
            PointValue = 2;
        }
        else
        {
            PointValue = 1;
        }
    }
}
