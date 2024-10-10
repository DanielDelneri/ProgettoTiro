using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class UISettings : MonoBehaviour
{
    [SerializeField] Toggle gravityToggle;
    [SerializeField] Toggle noGravityToggle;

    [SerializeField] ARPlaneManager planeManager;

    [SerializeField] GameObject board;
    public void confermaImpostazioni(){


        Debug.Log("gravità:"+gravityToggle.isOn);
        SettingsManager.instance.gravity = gravityToggle.isOn;
        board.SetActive(true);
        foreach(var plane in planeManager.trackables){
            if(plane.classification == PlaneClassification.Table){
                board.transform.position = plane.gameObject.transform.position;
                board.transform.rotation = plane.gameObject.transform.rotation;
                board.transform.Rotate(0,-180,0);
                board.transform.position+=new Vector3(0,0.05f,0);
            }
        }

        MainManager.instance.startExperience();
        //SettingsManager.instance.spawna(); // da eliminare
    }

    

}
