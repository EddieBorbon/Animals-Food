using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float sideBound = 40;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound){
            Destroy(gameObject);
        }else if(transform.position.z < lowerBound){
            Destroy(gameObject);
            gameManager.AddLives(-1);
        }
        else if(transform.position.x > sideBound){
            Destroy(gameObject);
            gameManager.AddLives(-1);
        }
        else if(transform.position.x < -sideBound){
            Destroy(gameObject);
            gameManager.AddLives(-1);
        }
    }
}
