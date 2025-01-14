using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;
    public GameManager gameManager;
    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void StartSpawnAnimals()
    {
        //InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
        //InvokeRepeating("SpawnRightAnimal", 2, 1.5f);
        //InvokeRepeating("SpawnLeftAnimal", 2, 1.5f);
        Invoke("SpawnRandomAnimal", Random.Range(2.0f,5.0f));
        //Invoke("SpawnRightAnimal", Random.Range(2.0f,5.0f));
        //Invoke("SpawnLeftAnimal", Random.Range(2.0f,5.0f));
    }
    void SpawnRandomAnimal(){
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        if(gameManager.isGameActive){
            Invoke("SpawnRandomAnimal", Random.Range(2.0f,5.0f));
        }
    }
    void SpawnRightAnimal(){
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX,0,Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
        if(gameManager.isGameActive){
            Invoke("SpawnRightAnimal", Random.Range(2.0f,5.0f));
        }  
    }
    void SpawnLeftAnimal(){
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX,0,Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
        if(gameManager.isGameActive){
            Invoke("SpawnLeftAnimal", Random.Range(2.0f,5.0f));
        } 
    }
}
