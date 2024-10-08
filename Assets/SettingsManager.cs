using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    //da eliminare
    public GameObject prefab;

    public bool gravity;

    void Awake(){
        if(instance==null){
            instance=this;
        }
    }

}
