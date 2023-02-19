using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class ScoreThirdLevel : MonoBehaviour
{
    public static ScoreThirdLevel instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int scoreThirdLevel = 0;
    public int highScoreThirdLevel = 0 ;
    public LeaderBoard leaderBoard;
    public static bool canSubmitScoreThirdLevel;

    public GameObject claimButton;

    void Awake() 
    {
        instance = this;    
    }

    void Start()
    {
        claimButton.SetActive(false);
        highScoreThirdLevel = PlayerPrefs.GetInt("highscoreThirdLevel", 0);
        scoreText.text = scoreThirdLevel.ToString() + " Gems";
        highScoreText.text = "HighScore: " + highScoreThirdLevel.ToString(); 
    }

    void Update ()
    {
        if (scoreThirdLevel > 5)
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
        scoreThirdLevel += 1;
        scoreText.text = scoreThirdLevel.ToString() + " Gems";
        if (highScoreThirdLevel < scoreThirdLevel)
        {
            PlayerPrefs.SetInt("highscoreThirdLevel", scoreThirdLevel);
            //StartCoroutine(SubmitScoreCoRoutine());
            canSubmitScoreThirdLevel = true;
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
