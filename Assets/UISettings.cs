using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class UISettings : MonoBehaviour
{
    [SerializeField] Toggle gravityToggle;
    [SerializeField] Toggle noGravityToggle;
    [SerializeField] Toggle feedbackBoardToggle;

    [SerializeField] ARPlaneManager planeManager;

    [SerializeField] GameObject board;
    [SerializeField] GameObject piatto;

    [SerializeField] Button modificaPiattoButton;

    [SerializeField] UISettingsPanelSwitch uISettingsPanelSwitch;

    [SerializeField] GameObject slider;

    [SerializeField] GameObject hCILab_Cube;


    public void confermaGravita()
    {
        SettingsManager.instance.gravity = gravityToggle.isOn;
        foreach (var plane in planeManager.trackables)
        {
            if (plane.classification == PlaneClassification.Table)
            {
                hCILab_Cube.transform.position = plane.gameObject.transform.position;
                hCILab_Cube.transform.position += new Vector3(-0.5f, 0.12f, 0);

                Vector3 targetPostition = new Vector3(plane.gameObject.transform.position.x,
                    hCILab_Cube.transform.position.y,
                                       plane.gameObject.transform.position.z);
                hCILab_Cube.transform.LookAt(targetPostition);


                piatto.transform.position = plane.gameObject.transform.position;

                piatto.transform.position += new Vector3(0, 0.01f, 0);
                piatto.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
        }
        uISettingsPanelSwitch.nextPanel();
    }

    public void confermaMetodoFeedback()
    {
        piatto.SetActive(true);
        attivaSpostamentoPiatto();
        uISettingsPanelSwitch.nextPanel();
    }

    public void confermaImpostazioni()
    {
        uISettingsPanelSwitch.nextPanel();
        SettingsManager.instance.impostaFeedback(feedbackBoardToggle.isOn);
        disattivaSpostamentoPiatto();
        foreach (var plane in planeManager.trackables)
        {
            if (plane.classification == PlaneClassification.Table)
            {
                /*board.transform.position = plane.gameObject.transform.position;
                board.transform.position += new Vector3(0, 0, 0.5f);
                board.transform.rotation = plane.gameObject.transform.rotation;
                //board.transform.Rotate(0,180,0);
                board.transform.position += new Vector3(0, 0.05f, 0);*/

                Vector3 pos = board.transform.position;
                pos.x = piatto.transform.position.x;
                pos.y = plane.transform.position.y;
                pos.z = piatto.gameObject.transform.position.z;
                board.transform.position = pos;
                board.transform.position += new Vector3(0.5f, 0.05f, 0.15f);
                board.transform.rotation = plane.gameObject.transform.rotation;
                board.transform.LookAt(SettingsManager.instance.origin.transform.position);
                Quaternion quaternion = board.transform.rotation;
                quaternion.x = 0;
                quaternion.z = 0;
                board.transform.rotation = quaternion;
                board.transform.Rotate(0, 180, 0);

                Vector3 pos2 = pos;
                pos2.x = piatto.transform.position.x;
                pos2.y = slider.transform.position.y;
                pos2.z = piatto.transform.position.z + 0.2f;
                //GameObject sliderr = slider.transform.GetChild(0).gameObject;
                GameObject sliderr = slider;
                sliderr.transform.position = pos2;
                sliderr.transform.LookAt(SettingsManager.instance.origin.transform.position);
                quaternion = sliderr.transform.rotation;
                quaternion.x = 0;
                quaternion.z = 0;
                sliderr.transform.rotation = quaternion;
                sliderr.transform.Rotate(0, 180, 0);
                //board.transform.Rotate(0,180,0);}
            }
        }


        Destroy(piatto.GetComponent<XRGrabInteractable>());
        Destroy(piatto.GetComponent<XRGeneralGrabTransformer>());
        MainManager.instance.startExperience();
        //SettingsManager.instance.spawna(); // da eliminare
    }


    private void attivaSpostamentoPiatto()
    {
        piatto.GetComponent<XRGrabInteractable>().enabled = true;
        piatto.GetComponent<XRGeneralGrabTransformer>().enabled = true;


    }

    private void disattivaSpostamentoPiatto()
    {
        piatto.GetComponent<XRGrabInteractable>().enabled = false;
        piatto.GetComponent<XRGeneralGrabTransformer>().enabled = false;
    }



}
