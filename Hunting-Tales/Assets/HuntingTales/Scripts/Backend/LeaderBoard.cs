using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    int leaderBoardId = 10470;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    public GameObject leaderBoardPanel;
    private bool isLeaderBoardActive;

    [System.Obsolete]

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            ActiveDeactiveLeaderBoard();
        }
        
    }
    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderBoardId, (response) =>{
            if (response.success)
            {
                Debug.Log("Succesfully uploaded score");
                done = true;
            }
            else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    [System.Obsolete]
    public IEnumerator FetchTopHighscoresRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderBoardId, 10,0, (response) =>{
            if(response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";
                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;

            }
            else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
    public void ActiveDeactiveLeaderBoard()
    {
        if (!isLeaderBoardActive)
        {
            isLeaderBoardActive = true;
            leaderBoardPanel.SetActive(true);
            
        }else
        {
            isLeaderBoardActive = false;
            leaderBoardPanel.SetActive(false);
        }
    }
}
