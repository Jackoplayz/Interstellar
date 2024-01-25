using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    List<GameObject> stars = new List<GameObject>();
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
        
        
        //where are the stars
        //how many planets per star
        //reset any player progress, destroy existing stars

        for (int i = 0; i < starsAmount; i++)
        {

            int safety = 1000;
            int whileCounter = 0;
            Vector3 position = Vector3.zero;
            while (whileCounter <= safety)
            {

                //Get a random position
                //Check that that position is valid

                float randomX = Random.Range(minX, maxX);
                float randomY = Random.Range(minY, maxY);
                position = new Vector3(randomX, randomY, -1);
                bool positionIsValid = true;
                for (int j = 0; j < stars.Count; j++)
                {
                    float dist = Vector3.Distance(position, stars[j].transform.position );
                    Debug.Log(dist);
                    if (dist < minStarSpacing )
                    {
                        positionIsValid = false;
                        break;
                    }
                }
                if (positionIsValid)
                {
                    break;
                }
                //If it is valid, break the loop  
                // break;
                whileCounter++;
            }

            if (safety == whileCounter)
            {
                Debug.Log("The safety was hit while spawning stars");
                break;
            }
            

            //Getting the valid position
            

            //Spawning the actual star
            var star = Instantiate(starPrefab, position, Quaternion.identity);
            stars.Add(star);

        } 
    }



}