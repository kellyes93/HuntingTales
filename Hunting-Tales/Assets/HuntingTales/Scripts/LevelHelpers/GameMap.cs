using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    [SerializeField] Transform[] levels;
    Camera cam;
    int currentIndex = 0;
    [SerializeField] float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cam.transform.position = Vector2.Lerp(cam.transform.position, levels[currentIndex].position, speed);
    }

    public void  ClickRight(){
        Move(1); //1: right  -1:left
    }
    public void  ClickLeft(){
        Move(-1); //1: right  -1:left
    }
    public void Click(){}
    void Move(int dir){
    currentIndex += dir;
    currentIndex = (currentIndex < 0 ) ? levels.Length -1 : currentIndex;
    currentIndex = (currentIndex >= levels.Length)? 0 : currentIndex;
    }
}
//> <