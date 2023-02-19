using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerSecondLevelManager : MonoBehaviour
{ 
    //public static PlayerSecondLevelManager instance;
    public LeaderBoard leaderBoard;
    //public TMP_InputField playerNameInputField;
    /*
    private void Awake()
    {
        instance = this;
    }

    void Start() 
    {
        //StartCoroutine(SetupRoutine());
        if (PlayerPrefs.GetString("playerNameSecondLevel") != "")
        {
            //playerNameInputField.interactable = false;
        }    
    }

    public void SavePlayerName()
    {
        if (PlayerPrefs.GetString("playerNameSecondLevel") == "")
        {
            //PlayerPrefs.SetString("playerNameSecondLevel", playerNameInputField.text);
            //SetPlayerName();
            //playerNameInputField.interactable = false;
        }
    }
 
    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) => {
            if (response.success)
            {
                 Debug.Log("Succesfully set player name: "+ playerNameInputField.text);
            }
            else
            {
                 Debug.Log("Could not set player name... " + response.Error);
            }
        });
    }*/

    void Start() 
    {
        StartCoroutine(SetupRoutine());
        
    }
    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderBoard.FetchTopHighscoresRoutine();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) => {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

}
