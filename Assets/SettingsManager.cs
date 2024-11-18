using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

   [SerializeField] GameObject pulsantiera;
   [SerializeField] GameObject slider;

    [SerializeField] TextMeshProUGUI feedbackBoardText;

    [SerializeField] TextMeshProUGUI sliderText;

   [SerializeField] public GameObject origin;

    public bool gravity;

    public bool usingBoard;

    void Awake(){
        if(instance==null){
            instance=this;
        }
    }

    public  void impostaFeedback(bool pulsantieraAttiva){
        usingBoard = pulsantieraAttiva;
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


    public void setFeedbackText(string text){
        MainManager.instance.debug("o:"+text);
        if(usingBoard){
            feedbackBoardText.text = text;
        }else{
            MainManager.instance.debug(text);
            sliderText.text = text;
        }
    }
}
