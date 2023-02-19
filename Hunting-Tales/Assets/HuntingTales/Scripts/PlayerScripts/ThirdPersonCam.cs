using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }  

    void Update()
    {
        if (gameManager.gameOver == true)
        {
            Cursor.visible = true;   
        }

        if (gameManager.gameWon == true)
        {
            Cursor.visible = true;
        }
    }      
}
