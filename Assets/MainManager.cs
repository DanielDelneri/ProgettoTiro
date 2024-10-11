using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MainManager : MonoBehaviour
{

    public static MainManager instance;


    [SerializeField] TextMeshProUGUI oo;
    [SerializeField] GameObject feedbackBoard;

    public List<CiboValutazione> foods;

    private int current;

    private GameObject lastInstantiated;

    private bool firstEvaluation;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            current = 0;
            firstEvaluation = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void currentEvaluation(CiboValutazione.Valutazione value)
    {

        if (firstEvaluation)
        {

            firstEvaluation = false;
            foods[current].valutazione_ansia = value;
        }
        else
        {
            foods[current].valutazione_craving = value;
            if (current >= foods.Count-1)
            {
                //fine
            }
            else
            {
                Destroy(lastInstantiated);
                current++;
                firstEvaluation = true;
                nextFood();
            }
        }
    }

    public void startExperience()
    {
        nextFood();
    }
    public void nextFood()
    {
        lastInstantiated = Instantiate(foods[current].cibo);
        lastInstantiated.transform.position = new Vector3(0, 1.5f, 1);
        if (SettingsManager.instance.gravity)
        {
            lastInstantiated.GetComponent<XRGrabInteractable>().forceGravityOnDetach = true;
            lastInstantiated.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
