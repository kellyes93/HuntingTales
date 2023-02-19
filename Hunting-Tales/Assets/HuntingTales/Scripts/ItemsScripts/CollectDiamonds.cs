using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDiamonds : MonoBehaviour
{
    private GameObject canvas;
    private ScoreManager scoreManager;
    [SerializeField] private AudioClip collectSoundEffect;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        scoreManager = canvas.GetComponent<ScoreManager>();
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
