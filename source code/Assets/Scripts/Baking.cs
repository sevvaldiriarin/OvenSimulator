using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baking : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    Text txt;
    
    private bool inOven=false;
    private bool isBaked=false;
    private int secondsinoven;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("ovenbottom")){
            inOven=true;
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("ovenbottom")){
            inOven=false;
        }
    }
    private void Start() {
        StartCoroutine(bake());
    }
   
    IEnumerator bake(){
        while(true){
            while(inOven&&!(CoverOpening.isopen)&&isBaked==false&&secondsinoven<=5){
                canvas.SetActive(true);
                        while(secondsinoven<=5&&!(CoverOpening.isopen)&&inOven){
                        txt.text=secondsinoven.ToString();
                        secondsinoven=secondsinoven+1;
                        yield return new WaitForSeconds(1);
                        if(secondsinoven==6){
                        txt.text="Piştim";
                        GetComponent<MeshRenderer>().material.color=new Color(0.8f,0.4f,0.4f);
                        isBaked=true;
                        }
                        }                    
                }
                yield return null;
            }
        
        }
    
     
    
}
