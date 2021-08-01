using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textManager : MonoBehaviour
{
    //We need to access this piece of code from player controller.
    //Player controller keeps track of collision with coin.

    public TextMeshProUGUI textMesh; //variable to connet TechMeshGUI for score to code
    public static textManager instance;
    int score; //keep track of score
    

    //functionality to increase score
    public void IncreaseScore()
    {
        score++;
        instance.textMesh.text = "GATO bag: " + score;
    }
    


    // Start is called before the first frame update
    void Start()
    {
         if(instance == null)
        {
          instance = this;
        }
        score = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
