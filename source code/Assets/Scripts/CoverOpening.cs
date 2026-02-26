using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverOpening : MonoBehaviour
{
    [Range(0f,1f)]
    public float lerp;

    [Range(0f,1f)]
    public float lerp2;

    int numberofclicks=0;

    Quaternion startpos,endpos;

    public GameObject cover;
        
    public static bool isopen;

    private void Start() {
        startpos=transform.rotation;
        endpos=Quaternion.Euler(0,-90f,0);
    }

    IEnumerator CoverOpen(){
            while(lerp<1f){
            lerp+=Time.deltaTime;
            cover.transform.parent.rotation=Quaternion.Lerp(startpos,endpos,lerp);
            yield return null;
         }
    }
    IEnumerator CoverClosing(){
           while(lerp2<1f){
            lerp2+=Time.deltaTime;
            cover.transform.parent.rotation=Quaternion.Lerp(endpos,startpos,lerp2);
            yield return null;
        }
    }
    void OnMouseDown(){
        numberofclicks++;
        lerp=0;
        lerp2=0;
        if(numberofclicks%2==1){
            isopen=true;
            StartCoroutine(CoverOpen());
        }
        else if(numberofclicks%2==0){
            isopen=false;
            StartCoroutine(CoverClosing()); 
        }

    }
}
