using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class letter_rotator : MonoBehaviour
{

    public GameObject NextBtn;
    public GameObject PrevBtn;
    public GameObject parent;
    public int i = 0;
    
    //public Virtual

    // Start is called before the first frame update
    void Start()
    {
        
        NextBtn = GameObject.Find("Next-Btn");
        PrevBtn = GameObject.Find("Prev-Btn");
        //NextBtn.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(NextButtonPressed);
        //PrevBtn.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(PrevButtonPressed);
        
        hideLetters();
        parent.transform.GetChild(1).gameObject.SetActive(true);
    }
    //Hides letter traces except A
    public void hideLetters(){
        for(int index = 0; index < 52; index++){
            parent.transform.GetChild(index).gameObject.SetActive(false);
            
        }
    }
    //FOR NEXT BTN: Sets current letter active and previous letter inactive
    public void setNextLetter(int i){
        parent.transform.GetChild(i).gameObject.SetActive(true);
        parent.transform.GetChild(i-1).gameObject.SetActive(false);
    }
    //FOR PREV BTN: Sets current letter active and previous letter inactive 
    public void setPrevLetter(int i){
        
        parent.transform.GetChild(i).gameObject.SetActive(true);
        parent.transform.GetChild(i+1).gameObject.SetActive(false);
    
    }
    
    public void NextButtonPressed(VirtualButtonBehaviour vb){
        i++;
        Debug.Log("Button Pressed" + i);
        setNextLetter(i);
    }

    public void PrevButtonPressed(VirtualButtonBehaviour vb){
        if(i<=0){

        }
        if(i>0){
        i--;
        Debug.Log("Button Pressed" + i);
        setPrevLetter(i);
        }
    }


}
