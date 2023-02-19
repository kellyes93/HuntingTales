using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrollingAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5;
    NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;
    
    public PlayerMovement playerMovementScript;
    [SerializeField] float enemyDamageAttack = 10.0f;
    public HealthBar healthBar;
    public Animator animator;
    
    
     [SerializeField] private AudioClip hitSoundEffect, monsterSoundEffect ;
     [SerializeField] private GameObject hitEffect, paralizeEffect;
     public static bool canMove = true;
     //Patrolling
     public Transform[] wayPoints;
     public int wayPointIndex;
     public Vector3 patrollingTarget;
     public bool wasEngage;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        
        animator = GetComponent<Animator>();

       // playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // checks every frame the distance between target and enemy
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= chaseRange)
        {
            EngageTarget();
        }

        if (distanceToTarget >= chaseRange && wasEngage)
        {
            animator.SetBool("IsAttacking", false);
            DesEngage();
        }
        //patrolling
        if (Vector3.Distance(transform.position, patrollingTarget) < 4)
        {
            animator.SetBool("IsWalking", true);
            IterateWaypointIndex();
            UpdateDestination();
        }
        

        
    }

    private void UpdateDestination(){
        patrollingTarget = wayPoints[wayPointIndex].position;
        navMeshAgent.SetDestination(patrollingTarget);
    }

    private void  IterateWaypointIndex(){
        wayPointIndex++;

        if(wayPointIndex == wayPoints.Length) {
            wayPointIndex = 0;
        }
        
    }



    // method that decides between Chase the player or Attack the player...
    private void EngageTarget()
    {
        wasEngage = true;
        // if the distance to the player is within the chase range enemry starts persecution...
        if(distanceToTarget <= chaseRange)
        {
          
           ChaseTarget(); 
        }
        // if the distance to the player is less than the stoppping distance starts attacking the player...
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
           
           // StartCoroutine(HitSoundCoroutine());
           
        }
        
    }

    private void DesEngage()
    {

       //animator.SetBool("IsWalking", false);
       wayPointIndex = 0;
       UpdateDestination();
       wasEngage = false;
    }
    // method that positions the enemy with the player position...
    private void ChaseTarget()
    {
 
        navMeshAgent.SetDestination(target.position);
        animator.SetBool("IsWalking", true);
    }

    // method that attacks the enemy also subtracts player health and update the healthbar value...
    private void AttackTarget()
    {
        
        animator.SetBool("IsAttacking", true);
        playerMovementScript.currentHealth -= enemyDamageAttack;
        healthBar.SetHealth(playerMovementScript.currentHealth);
       

    }


    // method that is implemented to debug the range of the enemy draw a gismo on screen...
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }
    
    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.Equals("Weapon")){
            
            SoundController.Instance.ExecuteSound(hitSoundEffect);
            hitEffect.SetActive(true);
            canMove = false;
            StartCoroutine(HitEffectCoroutine());
            //BulletCount.particle.SetActive(true);
           // other.gameObject.HitParticles.SetActive(true);

           // other.gameObject.SetActive(false);
            //GameObject obj =Instantiate(fragments, transform.position, Quaternion.identity);
            //Instantiate(diamond, transform.position , Quaternion.identity);
           //Destroy(obj,1.5f);       
        
        }
     }

    private IEnumerator HitEffectCoroutine()
    {
        
        yield return new WaitForSeconds(0.5f);
         hitEffect.SetActive(false);

    }

        private IEnumerator CanMoveCoroutine()
    {
        
        yield return new WaitForSeconds(5f);
         canMove = true;
         paralizeEffect.SetActive(false);

    }
}