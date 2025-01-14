using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            //Debug.Log("Game Over");
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }else if(other.CompareTag("Animal")){
            //gameManager.AddScore(5);
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
            Destroy(gameObject);
            //Destroy(other.gameObject);
        }
    }
}
