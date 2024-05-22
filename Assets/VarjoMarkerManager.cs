using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Varjo.XR;
public class VarjoMarkerManager : MonoBehaviour
{

    [Serializable]
    public struct TrackedObject{
        public long id;
        public GameObject gameObject;
        public bool dynamicTracking;
    }

    public TrackedObject[] trackedObjects = new TrackedObject[1];

    private List<VarjoMarker> markers = new List<VarjoMarker>();

    private List<long> removedMarkerIds = new List<long>();

    private void OnEnable(){
        VarjoMarkers.EnableVarjoMarkers(true);
    }

    private void OnDisable(){
        VarjoMarkers.EnableVarjoMarkers(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void buttonClick(){
        Debug.Log("click");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Varjo Marker tracking is enabled and functional.
    if (VarjoMarkers.IsVarjoMarkersEnabled())
    {
        // Get a list of markers with up-to-date data.
        VarjoMarkers.GetVarjoMarkers(out markers);

        // Loop through found markers and update gameobjects matching the marker ID in the array.
        foreach (var marker in markers)
        {
            for (var i = 0; i < trackedObjects.Length; i++)
            {
                if (trackedObjects[i].id == marker.id)
                {
                    // This simple marker manager controls only visibility and pose of the GameObjects.
                    trackedObjects[i].gameObject.SetActive(true);
                    trackedObjects[i].gameObject.transform.localPosition = marker.pose.position;
                    trackedObjects[i].gameObject.transform.localRotation = marker.pose.rotation;

                    // Set the marker tracking mode
                    if ((marker.flags == VarjoMarkerFlags.DoPrediction) != trackedObjects[i].dynamicTracking)
                        {
                            if (trackedObjects[i].dynamicTracking)
                            {
                                VarjoMarkers.AddVarjoMarkerFlags(marker.id, VarjoMarkerFlags.DoPrediction);
                            }
                            else
                            {
                                VarjoMarkers.RemoveVarjoMarkerFlags(marker.id, VarjoMarkerFlags.DoPrediction);
                            }
                        }
                }
            }
        }

        // Get a list of IDs of removed markers.
        VarjoMarkers.GetRemovedVarjoMarkerIds(out removedMarkerIds);

        // Loop through removed marker IDs and deactivate gameobjects matching the marker IDs in the array.
        foreach (var id in removedMarkerIds)
        {
            for (var i = 0; i < trackedObjects.Length; i++)
            {
                if (trackedObjects[i].id == id)
                {
                    trackedObjects[i].gameObject.SetActive(false);
                }
            }
        }
    }
    }
}
