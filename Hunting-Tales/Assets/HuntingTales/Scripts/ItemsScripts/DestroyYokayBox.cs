using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyYokayBox : MonoBehaviour
{
    public GameObject fragments;
    [SerializeField] private AudioClip destroyBox;
     private GameObject yokaiCanvas;
    private Image yokaiUI;

    private void Start() {
        yokaiCanvas = GameObject.Find("YokaiBar");
        yokaiUI =  yokaiCanvas.GetComponentInChildren<Image>();
        yokaiUI.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.Equals("Weapon")){
                yokaiUI.enabled = true;
            SoundController.Instance.ExecuteSound(destroyBox);
             GameObject obj = Instantiate(fragments, transform.position, Quaternion.identity);
            //Instantiate(diamond, transform.position , Quaternion.identity);
            this.gameObject.SetActive(false);
            Destroy(obj,1.5f);     
            //StartCoroutine(DestroyFragments());
        }
    }

    /*public IEnumerator DestroyFragments(){
        for(int i = 0; i < ; i++) {
            fragments.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
    }*/
}
