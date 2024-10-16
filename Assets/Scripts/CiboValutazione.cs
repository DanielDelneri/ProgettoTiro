using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CiboValutazione
{     
    public GameObject cibo;

    public string Nome;

    public Valutazione valutazione_ansia,valutazione_craving;

    [Serializable]
    public enum Valutazione{
    UNDEFINED = -1,Lvl1 = 1,Lvl2 = 2,Lvl3 = 3,Lvl4 = 4,Lvl5 = 5
}

}


