using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    // Start is called before the first frame update
    public void LoadOne()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene("Level");
    }
        public void LoadSecond()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene("Level3");
    }
        public void LoadThird()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene("Level2");
    }
        public void LoadFour()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene("Level4");
    }
}
