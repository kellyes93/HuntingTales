using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintToken : MonoBehaviour
{
    public static bool claimButton;

    void Start()
    {
        claimButton = false;
    }
    public void MintingToken()
    {
        
        claimButton = true;
        Application.ExternalCall("claimTokens");
        Debug.Log("Token was claim");
    }
}
