using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject fragments;
    public GameObject diamond;
    [SerializeField] private AudioClip destroyBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.Equals("Weapon")){
            SoundController.Instance.ExecuteSound(destroyBox);
            GameObject obj =Instantiate(fragments, transform.position, Quaternion.identity);
            Instantiate(diamond, transform.position , Quaternion.identity);
            this.gameObject.SetActive(false);
           Destroy(obj,1.5f);       
        
        }
    }

   
}
