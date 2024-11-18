using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

   [SerializeField] GameObject pulsantiera;
   [SerializeField] GameObject slider;

    public bool gravity;

    void Awake(){
        if(instance==null){
            instance=this;
        }
    }

    public  void impostaFeedback(bool pulsantieraAttiva){
        if(pulsantieraAttiva){
            pulsantiera.SetActive(true);
        }else{
            slider.SetActive(true);
        }
    }

    public void fine(){
        pulsantiera.SetActive(false);
        slider.SetActive(false);
    }

}
