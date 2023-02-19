using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class ScoreSecondLevel : MonoBehaviour
{
    public static ScoreSecondLevel instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int scoreSecondLevel = 0;
    public int highScoreSecondLevel = 0 ;
    public LeaderBoard leaderBoard;
    public static bool canSubmitScoreSecondLevel;

    public GameObject claimButton;

    void Awake() 
    {
        instance = this;    
    }

    void Start()
    {
        claimButton.SetActive(false);
        highScoreSecondLevel = PlayerPrefs.GetInt("highscoreSecondLevel", 0);
        scoreText.text = scoreSecondLevel.ToString() + " Gems";
        highScoreText.text = "HighScore: " + highScoreSecondLevel.ToString(); 
    }

    void Update ()
    {
        if (scoreSecondLevel > 14)
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
        scoreSecondLevel += 1;
        scoreText.text = scoreSecondLevel.ToString() + " Gems";
        if (highScoreSecondLevel < scoreSecondLevel)
        {
            PlayerPrefs.SetInt("highscoreSecondLevel", scoreSecondLevel);
            //StartCoroutine(SubmitScoreCoRoutine());
            canSubmitScoreSecondLevel = true;
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
