using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    private GameObject[] oniEnemies;
    private GameObject[] oniPatrolEnemies;
    private bool isPaused;
    public GameObject scoreCanvas;

    void Start() 
    {
        oniEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        oniPatrolEnemies = GameObject.FindGameObjectsWithTag("EnemyPatroll");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }
    public void PauseUnpause()
    {
        if (!isPaused)
        {
            scoreCanvas.SetActive(false);
            Cursor.visible = true;
            pauseScreen.SetActive(true);
            isPaused = true;
          foreach(GameObject oniEnemy in oniEnemies)
          {
            oniEnemy.GetComponent<EnemyAI>().enabled = false;

          }
        foreach(GameObject oniEnemyPatrol in oniPatrolEnemies)
          {
            oniEnemyPatrol.GetComponent<EnemyPatrollingAI>().enabled = false;

          }
            Time.timeScale = 0.0f;
        }
        else
        {   scoreCanvas.SetActive(true);
            //Cursor.visible = false;
            pauseScreen.SetActive(false);
            isPaused = false;
            foreach(GameObject oniEnemy in oniEnemies)
            {
                oniEnemy.GetComponent<EnemyAI>().enabled = true;
            }
            Time.timeScale = 1.0f;
        }
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("LevelSelectScreen");
    }
}
