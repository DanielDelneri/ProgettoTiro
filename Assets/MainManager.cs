using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MainManager : MonoBehaviour
{

    public static MainManager instance;



    [SerializeField] GameObject feedbackBoard;

    public List<CiboValutazione> foods;

    private int current;

    private GameObject lastInstantiated;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            current = 0;

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
        foods[current].valutazione = value;
        Destroy(lastInstantiated);
        if (current >= foods.Count)
        {
            //fine
        }
        else
        {
            current++;
            nextFood();
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
