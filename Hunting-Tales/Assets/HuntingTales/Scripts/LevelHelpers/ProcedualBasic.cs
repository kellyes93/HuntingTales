using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedualBasic : MonoBehaviour
{
    public GameObject[] posibleObjects;
    [Range(0f,1f)]
    public float[] difficulty;
    public float pro = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0f,1f)<=pro)
        {
        Instantiate(
            posibleObjects[Random.Range(0,posibleObjects.Length)],
            transform.position,
            Quaternion.Euler(Vector3.up*(Random.Range(0,4)*90))
        );
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
