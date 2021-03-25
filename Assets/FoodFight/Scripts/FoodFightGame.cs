using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodFightGame : MonoBehaviour
{
    public int score;
    public Target targetPrefab;
    public BoxCollider spawnArea;
    public float countdown;
    public float gameDuration;
    public TMP_Text scoretext;
    public TMP_Text countdowntext;


    private void Start()
    {
        //Spawn first target
        SpawnTarget();

        //Reset countdown
        countdown = gameDuration;
    }

    private void Update()
    {
        //Decrease the game countdown
        countdown -= Time.deltaTime;

        //UpdateUI
        updateUI();

        //If countdown runs out
        if (countdown <= 0f)
        {
            GameOver();
        }
            
    }

    private void GameOver()
    {
        //Pause the time
        Time.timeScale = 0; //Freeze the time
    }

    private void updateUI()
    {
        //Update the score text
        scoretext.text = $"Score: {score}";

        //Update the countdown text
        countdowntext.text = $"Time: {countdown:F1} sec"; //F1 truncates the decimal places
    }

    public void OnTargetHit(Target target)
    {
        // Increase the score
        score += target.PointValue;

        //Spawn a new target
        SpawnTarget();
    }

    private void SpawnTarget()
    {
        //Calculate new random position for the target from spawn area
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );

        //Spawn new target
        Target newTarget = Instantiate(targetPrefab, randomPosition, Quaternion.Euler(-90,0,0));

        //Connect target to game script
        newTarget.game = this;  //gives reference to self
    }
}
