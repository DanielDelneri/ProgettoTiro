using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CiboValutazione
{     
    public GameObject cibo;

    public Valutazione valutazione;

    [Serializable]
    public enum Valutazione{
    UNDEFINED,Lvl1,Lvl2,Lvl3,Lvl4,Lvl5
}

}


