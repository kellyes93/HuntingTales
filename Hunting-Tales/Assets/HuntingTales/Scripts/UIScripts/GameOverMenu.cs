using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private GameObject gameManager;
    public GameObject player;
    public GameObject gameOverScreen;
    [SerializeField] string activeScene;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
    }

    // method that checks if the gameOver bool variable is to true in order to active the game over screen...
    private void CheckGameOver()
    {
        if (gameManager.GetComponent<GameManager>().gameOver == true)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0.0f;
            
        }
    }
    //method that restarts the level, player health and reset the gameOver bool variable back to false...
    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        player.GetComponent<PlayerMovement>().currentHealth = player.GetComponent<PlayerMovement>().maxHealth;
        gameManager.GetComponent<GameManager>().gameOver = false;
        SceneManager.LoadScene(activeScene);

    }
    // method that enables to go back to main menu as well as restablished the player health...
    public void QuitToMainMenu()
    {
        Time.timeScale = 1.0f;
        player.GetComponent<PlayerMovement>().currentHealth = player.GetComponent<PlayerMovement>().maxHealth;
        gameManager.GetComponent<GameManager>().gameOver = false;
        SceneManager.LoadScene("LevelSelectScreen");
    }

}
