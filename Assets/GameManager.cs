using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int lives = 3;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    public SpawnManager spawnManager;
    public void Start(){
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartGame();
    }
    void StartGame(){
        isGameActive = true;
        score = 0;
        lives = 3;
        spawnManager.StartSpawnAnimals();
        livesText.text = "Lives = " + lives;
    }

    public void AddLives(int value){
        lives += value;
        if(lives <= 0){
            Debug.Log("Game Over");
            lives = 0;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }
        Debug.Log("Lives = " + lives);
        livesText.text = "Lives = " + lives;
    }
    public void AddScore(int value){
        score += value;
        Debug.Log("Score = " + score);
        scoreText.text = "Score = " + score;
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
