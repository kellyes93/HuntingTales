using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject yokaiMisteryBox;
   // public GameObject healtGuriGuri;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    //public GameObject misteryBox;
    /*
    Variables that sets the position of the mistery boxes these variables can be changed in order to be placed around the level...
    */
    public Vector3 pos1 ;// these can be changed
    public Vector3 pos2 ;// these can be changed
    public Vector3 pos3 ;// these can be changed
    /**/
    public int[] posArr = {0,1,2,3}; // these array is initialized to three because there are three position that can respawn the mistery boxes...
    // Start is called before the first frame update
    void Awake()
    {
       
        //pos1 = new Vector3(24.2999992f,-1.38f,21.4899998f);
        //pos2= new Vector3(31.1f,-1.29999995f,-76.4f);
        //pos3 = new Vector3(0.289999992f,-1.53999996f,44.43f);
        RandomPositionObjectRespawn();
    }

    void Start() {
        //InvokeRepeating("SpawnHealt", spawnTime, spawnDelay);
    }
    // method that instantiate the mistery boxes in three position setting a random position position for the yokai enemy...
    private void RandomPositionObjectRespawn()
    {
        int index = Random.Range(0, posArr.Length);
        if(index == 0)
        {
            Instantiate(yokaiMisteryBox, pos1, yokaiMisteryBox.transform.rotation);
          //  Instantiate(misteryBox, pos2, misteryBox.transform.rotation);
            //Instantiate(misteryBox, pos3, misteryBox.transform.rotation);

        } 
        else if (index == 1)
        {
            Instantiate(yokaiMisteryBox, pos2, yokaiMisteryBox.transform.rotation);
           // Instantiate(misteryBox, pos1, misteryBox.transform.rotation);
            //Instantiate(misteryBox, pos3, misteryBox.transform.rotation);
        }
        else
        {
            Instantiate(yokaiMisteryBox, pos3, yokaiMisteryBox.transform.rotation);
           // Instantiate(misteryBox, pos1, misteryBox.transform.rotation);
            //Instantiate(misteryBox, pos2, misteryBox.transform.rotation);
        }
    }

    /*public void SpawnHealt(){
        Instantiate(healtGuriGuri, transform.position, transform.rotation);
        if(stopSpawning) {
            CancelInvoke("SpawnHealt");
        }
    }*/
}
