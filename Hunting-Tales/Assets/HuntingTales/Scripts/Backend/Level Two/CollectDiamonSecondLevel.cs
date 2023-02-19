using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDiamonSecondLevel : MonoBehaviour
{
    private GameObject canvas;
    private ScoreSecondLevel scoreManager;
    [SerializeField] private AudioClip collectSoundEffect;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        scoreManager = canvas.GetComponent<ScoreSecondLevel>();
    }
    
    
        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player")){
            SoundController.Instance.ExecuteSound(collectSoundEffect);
           
            Destroy(gameObject);
            scoreManager.AddPoint();

        }
       
    }
}
