using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public PlayerMovement player;
    public HealthBar healthBar;
    private float healingFactor;
    [SerializeField] private AudioClip collectHealthEffect;

    void Start()
    {
       
        healingFactor = 10.0f;
    }
    void OnTriggerEnter(Collider other) 
    {
        // compare conditional on trigger with player...
        if(other.CompareTag("Player"))
        {
            SoundController.Instance.ExecuteSound(collectHealthEffect);
            HealthControl();

        }    
    }



    private void HealthControl(){
                    // first conditional case if player has max life amount only destroy the gameobject...
            if (player.currentHealth >= player.maxHealth)
            {
                Destroy(gameObject);
            }
            // second conditional case with a range in order to set rigth amount of life...
            else if (player.currentHealth >= 90.0f && player.currentHealth <= 99.0f)
            {
                player.currentHealth += player.maxHealth - player.currentHealth;
                healthBar.SetHealth(player.currentHealth);
                Destroy(gameObject);
            }
            else
            {
                player.currentHealth += healingFactor;
                healthBar.SetHealth(player.currentHealth);
                Destroy(gameObject);
            }
    }



    

}
