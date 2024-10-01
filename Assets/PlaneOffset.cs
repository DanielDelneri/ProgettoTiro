using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaneOffset : MonoBehaviour
{
    public ARPlaneManager planeManager;

    public float offset = 0f;

    void Start(){
        foreach(var plane in planeManager.trackables){
            Debug.Log("id:"+plane.trackableId);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //planeManager.GetPlane()
    }
}
