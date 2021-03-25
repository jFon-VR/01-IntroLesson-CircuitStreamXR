using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Forest : MonoBehaviour
{
    public bool raining;
    public TMP_Text forecastText;
    public RainScript rainEffect;
    public List<Animator> treeAnimators = new List<Animator>(); //List is defined on the left and then needs to be created on the right

    public void ToggleRain()
    {
        raining = !raining;     //Toggles the variable

        // Update forecast text
        forecastText.text = raining ? "Forecast: \nRaining" : "Forecast: \nCalm"; //asking for value of rain ? <value if true> : <value if false?

        // Enable or disable the rain effect
        rainEffect.RainIntensity = raining ? 1f : 0f;

        // For each item on list toggloe on or off 
        foreach(Animator treeAnimator in treeAnimators)
        {
            // enable or disable animator
            treeAnimator.enabled = raining;
        }
    }
}
