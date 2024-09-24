using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (LoaderUtility
            .GetActiveLoader()?
            .GetLoadedSubsystem<XRCameraSubsystem>() != null)
        {
            Debug.Log("funziona");
        }else{
            Debug.Log("Non funziona");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
