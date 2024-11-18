using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MainManager : MonoBehaviour
{

    public static MainManager instance;


    [SerializeField] TextMeshProUGUI oo;
    [SerializeField] GameObject feedbackBoard;

    [SerializeField] GameObject piatto;

    [SerializeField] TextMeshProUGUI feedbackBoardText;

    public List<CiboValutazione> foods;

    private List<CiboValutazione> foodsAnsia;

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

            foodsAnsia = new List<CiboValutazione>();
        }
    }

    private void inscerisciCiboAnsia(CiboValutazione cibo){
        if(foodsAnsia.Count<8){
            foodsAnsia.Add(cibo);
        }else{
            int j=-1;
            for(int i=0;i<8;i++){
                if(cibo.valutazione_ansia>foodsAnsia[i].valutazione_ansia){
                    j=i;
                }
            }
            if(j!=-1){
                foodsAnsia[j]=cibo;
            }
        }
    }

    public void currentEvaluation(CiboValutazione.Valutazione value)
    {

        if (firstEvaluation)
        {

            firstEvaluation = false;
            foods[current].valutazione_ansia = value;
            inscerisciCiboAnsia(foods[current]);
            feedbackBoardText.text = "Craving";

        }
        else
        {
            foods[current].valutazione_craving = value;
            if (current >= foods.Count - 1)
            {
                //fine
                foreach(CiboValutazione cib in foodsAnsia){
                   // oo.text=oo.text+cib.Nome+'\n';
                }
                seralizeList("valutazioneCompleta",foods);
            }
            else
            {
                Destroy(lastInstantiated);
                current++;
                firstEvaluation = true;
                feedbackBoardText.text = "Ansia";
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
        lastInstantiated = Instantiate(foods[current].cibo,piatto.transform.position,Quaternion.identity);
        //lastInstantiated.transform.position = new Vector3(0, 1.5f, 1);
        if (SettingsManager.instance.gravity)
        {
            lastInstantiated.transform.GetChild(0).GetComponent<XRGrabInteractable>().forceGravityOnDetach = true;
            lastInstantiated.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        }

    }

    public void debug(string ou){
        oo.text=ou;
    }

    private void seralizeList(string fileName, List<CiboValutazione> foods){ // crea un file json a partire dalla List<CiboValutazione>
        try{
        string json;
        json = JsonHelper.ToJson(foods);
        string path = Path.Combine(Application.persistentDataPath, fileName+".txt");
        StreamWriter file = new StreamWriter(path,false);
        file.Write(json);
        file.Close();
        }catch(Exception e){
            oo.text=e.Message;
        }
       // oo.text=json;
    }
}
