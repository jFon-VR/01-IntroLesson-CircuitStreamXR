using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GrassPlanter : MonoBehaviour
{
    public Transform placeHolderGrass;
    public Forest forest;
    public float plantingGrassDuration;
    public float timeBetweenGrassPlants;
    public Button plantGrassButton;
    public float plantingRadius;


    private bool isPlanting;
    private float timeLeftPlantingGrass;
    private float timeToNextGrassPlant;


    public void StartPlantingGrass()
    {
        // Mark as planting grass
        isPlanting = true;

        // Reset the planting grass timer
        timeLeftPlantingGrass = plantingGrassDuration;

        // Disable plant grass button
        plantGrassButton.interactable = false;

    }

    private void Update()
    {
        // If planting grass enabled
        if (isPlanting)
        {
            // Count down time left planting grass
            timeLeftPlantingGrass -= Time.deltaTime;

            //If planting grass stops
            if (timeLeftPlantingGrass <= 0f)
            {
                //Stop planting grass
                StopPlantingGrass();
            }

            //Counter for grass interval
            timeToNextGrassPlant -= Time.deltaTime;

            //If it time to plant new grass
            if (timeToNextGrassPlant <=0f)
            {
                //Plant grass
                PlantGrass();

                //Reset grass planting timer
                timeToNextGrassPlant = timeBetweenGrassPlants;


            }
        }
    }

    private void StopPlantingGrass()
    {
        // Unmark planting grass
        isPlanting = false;

        // Enable plant grass button
        plantGrassButton.interactable = true;
    }


    public void PlantGrass()
    {   //calculate random position and rotation for graphy
        Vector3 randomOffset = Random.insideUnitSphere * plantingRadius;
        randomOffset.y = 0;


        // Make a clone of the placeholder tree
        Transform newTree = Instantiate(placeHolderGrass, placeHolderGrass.position + randomOffset, placeHolderGrass.rotation);
    }
}
