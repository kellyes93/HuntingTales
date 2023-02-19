using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int score = 0;
    public int highScore = 0 ;
    public LeaderBoard leaderBoard;
    public static bool canSubmitScore;

    public GameObject claimButton;

    void Awake() 
    {
        instance = this;    
    }

    void Start()
    {
        claimButton.SetActive(false);
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " Gems";
        highScoreText.text = "HighScore: " + highScore.ToString(); 
    }

    void Update ()
    {
        if (score > 14)
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
        score += 1;
        scoreText.text = score.ToString() + " Gems";
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            //StartCoroutine(SubmitScoreCoRoutine());
            canSubmitScore = true;
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
