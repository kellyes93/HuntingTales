using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GourdBottle : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) )
        {
            animator.SetBool("IsAim", true);
            
        }

        if (Input.GetKeyDown(KeyCode.Z) )
        {
            animator.SetBool("IsAim", false);
            
        }


    }
}