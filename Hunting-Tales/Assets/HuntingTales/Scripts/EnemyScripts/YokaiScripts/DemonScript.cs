using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DemonScript : MonoBehaviour
{
    public static float enemyLife;
    private float damage = 0.1f;
    private CaptureScript captureScript;
    private EnemyHealthBar enemyHealthBar;
    private Rigidbody yokaiRb;
    private float speed;
    private GameObject playerTarget;
    [SerializeField] private AudioClip laugh;
    //public GameObject buttonImage;
    void Start()
    {
        playerTarget = GameObject.Find("Player");
        yokaiRb = GetComponent<Rigidbody>();
        speed = 2.0f;
        captureScript = FindObjectOfType<CaptureScript>();
        enemyHealthBar = FindObjectOfType<EnemyHealthBar>(); 
        enemyLife = 50.0f;
        //buttonImage.SetActive(false);
    }

   

    void FixedUpdate() 
    {
        
        CaptureEnemy();
    }

    // main capture enemy method...
    private void CaptureEnemy()
    {
        // if the bool isCapturing is set to true then add force to the enemy rigidbody, also checks and update the enemy life and enemy's heath bar... 
        if (CaptureScript.isCapturing)
        {
            yokaiRb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
            if (enemyLife >= 0)
                DamageEnemy();
                enemyHealthBar.EnemyHealthBarSlider(0.1f);
            if (enemyLife <= 0)
                captureScript.DetachEnemy();
        }else{
            // if is not capturing always look at the player position...
            transform.LookAt(playerTarget.transform);
        }
    }

    // damage enemy method subtracts damage tot he enemy's life...
    private void DamageEnemy()
    {
        enemyLife -= damage;
    }

     private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Weapon")) {
            //buttonImage.SetActive(true);
            SoundController.Instance.ExecuteSound(laugh);
        }
     }
}
