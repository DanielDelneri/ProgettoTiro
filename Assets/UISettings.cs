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

    private bool modificandoPiatto;

    void Awake()
    {
        modificandoPiatto = false;
    }

    public void confermaImpostazioni()
    {
        SettingsManager.instance.gravity = gravityToggle.isOn;
        board.SetActive(true);
        foreach (var plane in planeManager.trackables)
        {
            if (plane.classification == PlaneClassification.Table)
            {
                board.transform.position = plane.gameObject.transform.position;
                board.transform.position += new Vector3(0, 0, 0.5f);
                board.transform.rotation = plane.gameObject.transform.rotation;
                //board.transform.Rotate(0,180,0);
                board.transform.position += new Vector3(0, 0.05f, 0);

                piatto.transform.position = plane.gameObject.transform.position;
                piatto.transform.position += new Vector3(0, 0.01f, 0);
                piatto.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

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
            Vector3 pos = board.transform.position;
            pos.x = piatto.gameObject.transform.position.x;
            pos.z = piatto.gameObject.transform.position.z;
            board.transform.position = pos;
            board.transform.position += new Vector3(0, 0, 0.3f);
            //board.transform.Rotate(0,180,0);
            board.SetActive(true);

        }
        else
        {
            ColorBlock cb = modificaPiattoButton.colors;
            cb.normalColor = Color.green;
            modificaPiattoButton.colors = cb;
            piatto.GetComponent<XRGrabInteractable>().enabled = true;
            board.SetActive(false);
            piatto.GetComponent<XRGeneralGrabTransformer>().enabled = true;
        }

        modificandoPiatto = !modificandoPiatto;
    }


}
