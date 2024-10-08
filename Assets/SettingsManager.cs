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

    //da eliminare
    public void spawna(){
        GameObject instantiated = Instantiate(prefab);
        instantiated.transform.position = new Vector3(0,1,1);
        if(gravity){
        instantiated.GetComponent<XRGrabInteractable>().forceGravityOnDetach = true;
        instantiated.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
