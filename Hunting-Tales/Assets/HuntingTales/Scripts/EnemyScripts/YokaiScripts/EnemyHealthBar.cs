using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private GameObject  enemySlider;
    private Slider yokaiSlider;
    private int damageAmount;
    private float currentDamageAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemySlider = GameObject.Find("YokaiBar");
        yokaiSlider = enemySlider.GetComponentInChildren<Slider>();
        damageAmount = 50; // do not change this value...
        yokaiSlider.maxValue = damageAmount;
        yokaiSlider.value = 0;
        yokaiSlider.fillRect.gameObject.SetActive(false);
    }

    // method that controls the enemy's health bar slider UI...
    public void EnemyHealthBarSlider(float amount)
    {
        currentDamageAmount += amount;
        yokaiSlider.fillRect.gameObject.SetActive(true);
        yokaiSlider.value = currentDamageAmount;
        // if the current damage is greater or equal than damage amount set to (50) destroy the enemy yokai game object...
        if(currentDamageAmount >= damageAmount)
        {
            Destroy(gameObject, 0.1f);
            CaptureScript.canBeCapture = false;
        }
    }

}
