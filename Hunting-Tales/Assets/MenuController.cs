using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject creditsScene;
    // Start is called before the first frame update
 


    public void LoadSelector()
    {
        SceneManager.LoadScene("LevelSelectScreen");
    }
        public void OnSwitchCredits()
    {
        creditsScene.SetActive(true);
    }

            public void OffSwitchCredits()
    {
         creditsScene.SetActive(false);
    }
}
