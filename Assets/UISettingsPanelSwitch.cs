using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettingsPanelSwitch : MonoBehaviour
{
    

    [SerializeField] List<GameObject> panels;

    private int current;

    void Awake(){
        current = 0;
    }

    public void nextPanel(){
        panels[current].SetActive(false);
        if(current<panels.Count){
        current++;
        panels[current].SetActive(true);
        }
    }
}
