using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float minStarSpacing = 1;
    public GameObject starPrefab;
    public static GameController instance;
    public float minX, maxX, minY, maxY;
    public int starsAmount = 5;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
        // Start is called before the first frame update
        void Start()
        {
         minX = -8.8f;
         maxX = 8.8f;
         minY = -5f;
         maxY = 5f;
        CreateNewGame();
        }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateNewGame()
    {
        //how many stars
        //where the ship spawns 
        //where are the stars
        //how many planets per star
        //reset any player progress

        for (int i = 0; i < starsAmount; i++)
        {

            int safety = 1000;
            int whileCounter = 0;
            while (whileCounter <= safety)
            {

                //Get a random position
                //Check that that position is valid

                //If it is valid, break the loop  
               // break;
                whileCounter++;
            }

            if (safety == whileCounter) Debug.Log("The safety was hit while spawning stars");


            //Getting the valid position
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 position = new Vector3(randomX, randomY, -1);

            //Spawning the actual star
            var Star = Instantiate(starPrefab, position, Quaternion.identity);

        } 
    }



}
