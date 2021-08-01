using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTokens : MonoBehaviour
{
    //Timer, executes code a set intervals dump tokens
    
    public float spawnLengthTime; //set time between spawn from inspector
    public GameObject prefab; //connect prefab to code inform which prefab to use, pass prefab in inspector
    
    private float timeUntilSpawn; //to keep track of spawn time

    void Start()
    {
        timeUntilSpawn = spawnLengthTime; //from jump, set the time until next drop.
    }

    void Spawn() 
    {
        //we want to display 27 tokens, we will iterate through 27 tokens
        for(int i =0; i < 27; i++)
             Instantiate(prefab, new Vector2(-10 + 0.7f * i, 20),Quaternion.identity); 
        /*
            We generate coins by using the Instantiate function and passing
            the prefab (via the inspector), followed by where to place these new
             gameObjects - 
             implement formula to pass x and y  to vector then specify rotation 
             (not relevant to our 2D game, so we pass an identity matrix, ).
    
        */
           
    }


    void Update () 
    {
          /*
            60 tps
            60 fps
            1/60 of a sec to calculate
            for slower machines, lower fps
          */
         timeUntilSpawn -= Time.deltaTime;
        if(timeUntilSpawn <= 0.0f)
        {
            Spawn();
            
            timeUntilSpawn = spawnLengthTime;
        }
       
           
            
        
    }
}

