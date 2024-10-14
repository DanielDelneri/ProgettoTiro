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

    [SerializeField] ARPlaneManager planeManager;

    [SerializeField] GameObject board;
    [SerializeField] GameObject piatto;

    [SerializeField] Button modificaPiattoButton;

    [SerializeField] UISettingsPanelSwitch uISettingsPanelSwitch;


    private bool modificandoPiatto;

    void Awake()
    {
        modificandoPiatto = false;
    }

    public void confermaGravita()
    {
        SettingsManager.instance.gravity = gravityToggle.isOn;
        foreach (var plane in planeManager.trackables)
        {
            if (plane.classification == PlaneClassification.Table)
            {
                piatto.transform.position = plane.gameObject.transform.position;
                piatto.transform.position += new Vector3(0, 0.01f, 0);
                piatto.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
        }
        uISettingsPanelSwitch.nextPanel();
    }

    public void confermaImpostazioni()
    {
        uISettingsPanelSwitch.nextPanel();
        board.SetActive(true);
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
                pos.x = piatto.gameObject.transform.position.x;
                pos.z = piatto.gameObject.transform.position.z;
                pos.y = plane.gameObject.transform.position.y;
                board.transform.position = pos;
                board.transform.position += new Vector3(0, 0.05f, 0.3f);
                board.transform.rotation = plane.gameObject.transform.rotation;
                //board.transform.Rotate(0,180,0);
            }
        }

        MainManager.instance.startExperience();
        //SettingsManager.instance.spawna(); // da eliminare
    }

    public void spostaPiatto()
    {
        if (modificandoPiatto)
        {
            ColorBlock cb = modificaPiattoButton.colors;
            cb.normalColor = Color.blue;
            modificaPiattoButton.colors = cb;
            piatto.GetComponent<XRGrabInteractable>().enabled = false;
            piatto.GetComponent<XRGeneralGrabTransformer>().enabled = false;
        }
        else
        {
            ColorBlock cb = modificaPiattoButton.colors;
            cb.normalColor = Color.green;
            modificaPiattoButton.colors = cb;
            piatto.GetComponent<XRGrabInteractable>().enabled = true;
            piatto.GetComponent<XRGeneralGrabTransformer>().enabled = true;
        }

        modificandoPiatto = !modificandoPiatto;
    }


}
