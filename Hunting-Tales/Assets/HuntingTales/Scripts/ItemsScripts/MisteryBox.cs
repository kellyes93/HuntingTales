using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisteryBox : MonoBehaviour
{

    private GameObject yokaiCanvas;
    private Image yokaiUI;

    private GameObject yokaiButtons;
    private void Start() {
        yokaiCanvas = GameObject.Find("YokaiBar");
        yokaiButtons = GameObject.Find("YokaiButtonsUI");

        yokaiUI = yokaiCanvas.GetComponentInChildren<Image>();
        yokaiUI.enabled = false;
    }

    // if player collides with mistery box destroy the game object...
    private void OnCollisionEnter(Collision other) {
       if(other.gameObject.tag.Equals("Player") )
        {
            yokaiUI.enabled = true;
        } 
    }
}
