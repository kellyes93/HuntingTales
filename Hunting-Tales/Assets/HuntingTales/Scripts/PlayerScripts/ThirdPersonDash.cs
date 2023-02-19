using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonDash : MonoBehaviour
{
   // public bool canJump;
    public bool canDash;
    private float abilityCoolDown;
   
    // Start is called before the first frame update
    void Start()
    {
        abilityCoolDown = 3;
        //canJump = true;
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
       HorizontalDash();
     //  JumpDash();
    }

    // SetBoolFalse method that sets both booleans back to false in order to avoid keep dashing...
    private void SetBoolFalse()
    {
        //canJump = false;
        canDash = false;
    }

    // method that performs the horizontal dash of the player
    private void HorizontalDash()
    {
        // if the left click is pressed and canDash is equal to true triggers the coroutine
         if (Input.GetMouseButtonDown(0) && canDash)
        {
            if(GetComponent<PlayerMovement>().currentHealth >= 1) {
                // call to the SetBoolFalse method in order to avoid keep jumping or dashing...
                SetBoolFalse();
                StartCoroutine(GetComponent<PlayerMovement>().Dash(abilityCoolDown));
            }

            
        }
    }

    // method that performs the jump dash of the player
   /* private void JumpDash()
    {
        // if the right click is pressed and canJump is equal to true triggers the coroutine
        if (Input.GetMouseButtonDown(1) && canJump)
        {
            // call to the SetBoolFalse method in order to avoid keep jumping or dashing...
            SetBoolFalse();
            StartCoroutine(GetComponent<PlayerMovement>().JumpDash(abilityCoolDown));
        }
    }*/
    
}
