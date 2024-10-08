using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackScript : MonoBehaviour
{


    public void test2(int value){
        CiboValutazione.Valutazione valutazione;
        switch(value){
            case 0:{
                valutazione = CiboValutazione.Valutazione.Lvl1;
                break;
            }
            case 1:{
                valutazione = CiboValutazione.Valutazione.Lvl2;
                break;
            }
            case 2:{
                valutazione = CiboValutazione.Valutazione.Lvl3;
                break;
            }
            case 3:{
                valutazione = CiboValutazione.Valutazione.Lvl4;
                break;
            }
            case 4:{
                valutazione = CiboValutazione.Valutazione.Lvl5;
                break;
            }
            default:{
                valutazione = CiboValutazione.Valutazione.UNDEFINED;
                break;
            }
        }


        MainManager.instance.currentEvaluation(valutazione);

    }
}
