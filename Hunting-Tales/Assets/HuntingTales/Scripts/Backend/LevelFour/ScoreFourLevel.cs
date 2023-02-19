using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class ScoreFourLevel : MonoBehaviour
{
    public static ScoreFourLevel instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int scoreFourLevel = 0;
    public int highScoreFourLevel = 0 ;
    public LeaderBoard leaderBoard;
    public static bool canSubmitScoreFourLevel;

    public GameObject claimButton;

    void Awake() 
    {
        instance = this;    
    }

    void Start()
    {
        claimButton.SetActive(false);
        highScoreFourLevel = PlayerPrefs.GetInt("highscoreFourLevel", 0);
        scoreText.text = scoreFourLevel.ToString() + " Gems";
        highScoreText.text = "HighScore: " + highScoreFourLevel.ToString(); 
    }

    void Update ()
    {
        if (scoreFourLevel > 10)
        {
            Cursor.visible = true;
            claimButton.SetActive(true);
        }
        if (MintToken.claimButton)
        {
            claimButton.SetActive(false);
        }
    }

    public void AddPoint()
    {
        scoreFourLevel += 1;
        scoreText.text = scoreFourLevel.ToString() + " Gems";
        if (highScoreFourLevel < scoreFourLevel)
        {
            PlayerPrefs.SetInt("highscoreFourLevel", scoreFourLevel);
            //StartCoroutine(SubmitScoreCoRoutine());
            canSubmitScoreFourLevel = true;
        }
    }


    /*
    void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this button.
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }*/

}
