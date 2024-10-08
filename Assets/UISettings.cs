using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    [SerializeField] Toggle gravityToggle;
    [SerializeField] Toggle noGravityToggle;
    public void confermaImpostazioni(){
        Debug.Log("gravità:"+gravityToggle.isOn);
        SettingsManager.instance.gravity = gravityToggle.isOn;
        MainManager.instance.startExperience();
        //SettingsManager.instance.spawna(); // da eliminare
    }
}
