using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreePlanters : MonoBehaviour
{
    public Transform placeholderTree;
    public Mesh[] treeMeshes;
    public Forest forest;

    // Start is called before the first frame update
    void Start()
    {
        //RandomizeCurrent tree
        RandomizeTree();
    }

    public void RandomizeTree()
    {
        // Grab a random tree mesh from list of meshes
        placeholderTree.GetComponent<MeshFilter>().mesh = treeMeshes[Random.Range(0, treeMeshes.Length)];
        
    }

    // Update is called once per frame
    void Update()
    {
        // When the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //plant tree
            PlantTree();
        }
    }

    public void PlantTree()
    {
        // Make a clone of the placeholder tree
        Transform newTree = Instantiate(placeholderTree, placeholderTree.position, placeholderTree.rotation);

        // Add the animator of the new tree to the forest's tree animator list
       Animator newTreeAnimator = newTree.GetComponent<Animator>();
        forest.treeAnimators.Add(newTreeAnimator);
        newTreeAnimator.enabled = forest.raining;

        //RandomizeCurrent tree
        RandomizeTree();

    }
}
