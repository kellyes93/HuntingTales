using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenFourLevel : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSound;
    private GameObject gameManager;
    public GameObject player;
    public GameObject winScreen;
    public string activeScene;
    //public LeaderBoard leaderBoard;
    //public ScoreSecondLevel scoreManager;
    //public GameObject submitScoreButton;
    // Start is called before the first frame update
    void Start()
    {
        //submitScoreButton.SetActive(false);
        gameManager = GameObject.Find("GameManager");
        //player = GameObject.Find("Player");
        audioSource.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(wasScoreSubmitted);
        if (gameManager.GetComponent<GameManager>().gameWon == true)
        {
            winScreen.SetActive(true);
            //StartCoroutine(PlayWinSound());
            Time.timeScale = 0.0f;
        }
        /*if (ScoreSecondLevel.canSubmitScoreSecondLevel)
        {
            submitScoreButton.SetActive(true);
        }*/
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        player.GetComponent<PlayerMovement>().currentHealth = player.GetComponent<PlayerMovement>().maxHealth;
        player.GetComponent<CaptureScript>().enemyCaptured = false;
        gameManager.GetComponent<GameManager>().gameWon = false;
        SceneManager.LoadScene(activeScene);

    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1.0f;
        player.GetComponent<PlayerMovement>().currentHealth = player.GetComponent<PlayerMovement>().maxHealth;
        player.GetComponent<CaptureScript>().enemyCaptured = false;
        gameManager.GetComponent<GameManager>().gameWon = false;
        SceneManager.LoadScene("LevelSelectScreen");
    }

    public IEnumerator PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
        yield return new WaitForSecondsRealtime(0.2f);
        audioSource.enabled = false;
    }
/*
    public void SubmitScore()
    {
        StartCoroutine(SubmitScoreCoRoutine());
    }

    IEnumerator SubmitScoreCoRoutine()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("call subroutine from player");
        yield return leaderBoard.SubmitScoreRoutine(scoreManager.scoreSecondLevel);
        ScoreSecondLevel.canSubmitScoreSecondLevel = false;
        //submitScoreButton.SetActive(false);
        Time.timeScale = 1f;
    }
*/
}
