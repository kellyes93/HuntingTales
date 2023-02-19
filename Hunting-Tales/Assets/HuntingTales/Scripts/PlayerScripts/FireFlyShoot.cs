using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyShoot : MonoBehaviour
{
    [Header("Fireflies Shoot")]
    public GameObject bullet;
    Rigidbody bulletPrefab;
    public Transform shooter;
    public float speedShoot;
    public float timeShoot;
    private float startShoot;

    public BulletCount currentBullets;

    private List<GameObject> pool = new List<GameObject>();

    private Animator hunterAnimator;
    public Animator bottleAnimator;
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource emptySoundEffect;
    //public Dialogue  isDialogue;
    //public bool condition;



    



    // Start is called before the first frame update
    void Start()
    {
        bulletPrefab = bullet.GetComponent<Rigidbody>();
        currentBullets = FindObjectOfType<BulletCount>();
        hunterAnimator = GetComponent<Animator>();
        //condition = isDialogue.dialogue;

        // amountBullets = amountBullets + 5
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > startShoot)

        {
            
            hunterAnimator.SetBool("IsCapturing",true);
            bottleAnimator.SetBool("IsAim",true);
            if (currentBullets.amountBullets >  0  &&  !Dialogue.dialogue )
            {
                shootSoundEffect.Play();
               // GameObject obj = GetWeapon();
               // obj.transform.position = transform.position;
               // obj.transform.rotation = transform.rotation;
                //Rigidbody bulletPrefabInstance;

                startShoot = Time.time + timeShoot;

                GameObject bulletPrefabInstance = Instantiate(bullet, shooter.position, Quaternion.identity);
                bulletPrefabInstance.GetComponent<Rigidbody>().AddForce(shooter.forward * speedShoot * 100);
                Destroy(bulletPrefabInstance,3f);
                //bulletPrefabInstance.SetActive(false);


                currentBullets.amountBullets = currentBullets.amountBullets - 1;

            }
            else{
                emptySoundEffect.Play();
            }

        }

        if (Input.GetKeyUp(KeyCode.Space)){
            hunterAnimator.SetBool("IsCapturing",false);
            bottleAnimator.SetBool("IsAim",false);
        }
            

    }



/*
    public GameObject GetWeapon(){
        for(int i = 0; i < pool.Count; i++) {
            if(!pool[i].activeInHierarchy) {
                pool[i].SetActive(true);
                return pool[i];
            }

        }
            startShoot = Time.time + timeShoot;
            GameObject obj = Instantiate(bullet,shooter.position, Quaternion.identity) as GameObject;
            obj.GetComponent<Rigidbody>().AddForce(shooter.forward * speedShoot * 100);
           // obj.AddForce(shooter.forward * speedShoot * 100);
            pool.Add(obj);
            return obj;
    }*/

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Ground")) {
            Debug.Log("ENTRO");
            Destroy(bullet);
        }
    }


}
