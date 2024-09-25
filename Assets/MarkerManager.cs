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
       
    }

    // Update is called once per frame
    void Update()
    {
 if (LoaderUtility
            .GetActiveLoader()?
            .GetLoadedSubsystem<XRPlaneSubsystem>() != null)
        {
            Debug.Log("funziona");
        }else{
            Debug.Log("Non funziona");
        }
    }
}
