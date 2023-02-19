using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private GameObject pauseScreen;
    private GameObject[] oniEnemies;
    public bool gameOver = true;
    public bool gameWon;
    
    void Awake() 
    {
        pauseScreen = GameObject.FindWithTag("Pause");
        oniEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    void Start()
    {
        //player = GameObject.Find("Player");
        pauseScreen.SetActive(true);
    }

    void Update()
    {
        CheckWinCondition();
        CheckLoseCondition();
    }

    // methods that checks for the win condition...
    private void CheckWinCondition()
    { 
        if (player.GetComponent<CaptureScript>().enemyCaptured == true)
        {
            for(int i = 0; i < oniEnemies.Length ; i++) {
                oniEnemies[i].GetComponent<EnemyAI>().enabled = false;
            }
            gameWon = true;
            pauseScreen.SetActive(false);
        }
    }

    // method that checks for the Lose Condition...
    private void CheckLoseCondition()
    {  
        if (player.GetComponent<PlayerMovement>().currentHealth <= 0)
        {
            
            StartCoroutine(SetGameOverCoroutine());
            pauseScreen.SetActive(false);
        }

    }

    private IEnumerator SetGameOverCoroutine(){
        yield return new WaitForSecondsRealtime(4f);
        gameOver = true;
    }
}
