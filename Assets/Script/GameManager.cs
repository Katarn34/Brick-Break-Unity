using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lives;
    public int score;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;

    // Start is called before the first frame update
    //Setting the lives and score for the UI and the nuùber of Bricks for the Victory System
    void Start()
    {
        livesText.text = "lives: " + lives;
        scoreText.text = "score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("bricks").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Lives Function that stop the game if the player have 0 life and update the lives in the UI
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "lives: " + lives;
    }
    //Score Function that will update the score to the UI
    public void UpdateScore(int points)
    {
        score += points;

        scoreText.text = "score: " + score;
    }
    //Getting the number of Bricks and enb the game if there are no more Bricks
    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0)
        {
            GameOver();
        }
    }
    //Game Over Function that will end the game each time that it is called
    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }
    //Play Again Button that restart the game
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
    //Quit Buttton that quit the game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

}
