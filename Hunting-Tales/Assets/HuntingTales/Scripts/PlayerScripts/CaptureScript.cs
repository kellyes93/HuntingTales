using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CaptureScript : MonoBehaviour
{
    public GameObject child;
    public Transform parent;
    public Transform target;
    public static bool isCapturing;
    public static bool canBeCapture;
    public bool enemyCaptured;
    private float t;
    private float poschildx;
    private float poschildz;
    public ParticleSystem captureParticle;
    public ThirdPersonDash dash;
    private GameObject yokai;
    private Animator yokaiAnimator;

    private Animator animator; 
    void Awake() 
    {
        isCapturing = false;   
    }

    void Start()
    {
        dash.enabled = true;
        animator = GetComponent<Animator>();
        yokai = GameObject.FindGameObjectWithTag("DemonEnemy");
        yokaiAnimator = yokai.GetComponentInChildren<Animator>();
        t = 0.01f;
        child = GameObject.FindWithTag("DemonEnemy");
        poschildx = child.transform.position.x;
        poschildz = child.transform.position.z;
    }
    void FixedUpdate()
    {
        if (child == null)
        {
            enemyCaptured = true;
        }
        if (target == null)
        {
            target = parent;
        }
        
        CaptureUserInput();

        if (DemonScript.enemyLife <= 0)
        {
            isCapturing = false;
        }

        if (!enemyCaptured)
        {
            // variables needed to check every frame for the player position and target position (yokai)...
            Vector3 playerPos = transform.position; 
            Vector3 targetPos = child.transform.position;
            if (isCapturing)
            {
                Capturing(playerPos, targetPos);
            }
        }
        
    }

    // method that checks every frame if user pressed X button to capture or Z button to detach the enemy....
    private void CaptureUserInput()
    {
        if (Input.GetKeyDown(KeyCode.X) && canBeCapture)
        {
            captureParticle.Play();
            animator.SetBool("IsCapturing", true);
            yokaiAnimator.SetBool("IsCapturing", true);
            CaptureEnemy(parent);
            isCapturing = true;

        }

        if ( isCapturing && Input.GetKeyDown(KeyCode.Z))
        { 
            UnCaptureProcess();
        }
        if(GetComponent<PlayerMovement>().currentHealth <= 0 ){
                UnCaptureProcess();
        }
    }

    public void UnCaptureProcess(){
            captureParticle.Stop();
            dash.enabled = true;
            animator.SetBool("IsCapturing", false);
            yokaiAnimator.SetBool("IsCapturing", false);
            isCapturing = false;
            DetachEnemy();
    }

    // method that makes the enemy yokai game object a child of player...
    private void CaptureEnemy(Transform newParent)
    {
        child.transform.SetParent(newParent);
    }

    // methods that moves the player game object towards the target position in this case the enemy yokai...
    private void Capturing(Vector3 playerPos, Vector3 targetPos)
    {
        transform.position = Vector3.Lerp(playerPos, targetPos , t);
        poschildx = transform.position.x;   
        poschildz = transform.position.z; 
    }

    // method that detach enemy child from the player game object...
    public void DetachEnemy()
    {
        child.transform.SetParent(null);
    }

    /*
    Trigger enter that sets canBeCapture bool to true, in order to check if player is within the range of capture...
    */
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("DemonEnemy"))
        {
            canBeCapture = true;
        }
    }

    /*
    Trigger exit that sets canBeCapture bool to false, in order to check if player is out of the capture range...
    */
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("DemonEnemy"))
        {
            canBeCapture = false;
        }
    }

}
