using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class letter_rotator : MonoBehaviour
{
    public GameObject parent;
    public int i = 53;
    public TraceFeedback traceFeedback;
    public Starter start;

    
    void Start()
    {
        traceFeedback = FindObjectOfType<TraceFeedback>();
        start = FindObjectOfType<Starter>();
        HideLetters();
        //parent.transform.GetChild(1).gameObject.SetActive(true); 
    }

    // Hides letter traces except the current letter
    public void HideLetters()
    {
        for (int index = 0; index < parent.transform.childCount; index++)
        {
            parent.transform.GetChild(index).gameObject.SetActive(false);
        }
        traceFeedback.directer.Stop();

    }

    // Sets the next letter active and the current letter inactive
    public void SetNextLetter()
    {
        traceFeedback.directer.Stop();

        start.biasFound = false;
        i = (i + 2) % parent.transform.childCount;
        HideLetters();
        //parent.transform.GetChild(i).gameObject.SetActive(true);
        traceFeedback.isDone = false;
        traceFeedback.directer.Stop();
    }

    // Sets the previous letter active and the current letter inactive
    public void SetPrevLetter()
    {
        traceFeedback.directer.Stop();

        start.biasFound = false;
        i = (i - 2 + parent.transform.childCount) % parent.transform.childCount;
        HideLetters();
        //parent.transform.GetChild(i).gameObject.SetActive(true);
        traceFeedback.isDone = false;
        traceFeedback.directer.Stop();
    }

     public void RefreshCurrentLetter()
    {
        traceFeedback.directer.Stop();
        HideLetters(); 
        traceFeedback.letterArray = traceFeedback.alphabet[i];
        switch (i)
            {
                case 1:
                    traceFeedback.lineVector = traceFeedback.LowA[0];
                    break;
                case 3:
                    traceFeedback.lineVector = traceFeedback.LowB[0];
                    break;
                case 5:
                    traceFeedback.lineVector = traceFeedback.LowC[0];
                    break;
                case 7:
                    traceFeedback.lineVector = traceFeedback.LowD[0];
                    break;
                case 9:
                    traceFeedback.lineVector = traceFeedback.LowE[0];
                    break;
                case 11:
                    traceFeedback.lineVector = traceFeedback.LowF[0];
                    break;
                case 13:
                    traceFeedback.lineVector = traceFeedback.LowG[0];
                    break;
                case 15: 
                    traceFeedback.lineVector = traceFeedback.LowH[0];
                    break;
                case 17:
                    traceFeedback.lineVector = traceFeedback.LowI[0];
                    break;
                case 19:
                    traceFeedback.lineVector = traceFeedback.LowJ[0];
                    break;
                case 21:
                    traceFeedback.lineVector = traceFeedback.LowK[0];
                    break;
                case 23:
                    traceFeedback.lineVector = traceFeedback.LowL[0];
                    break;
                case 25:
                    traceFeedback.lineVector = traceFeedback.LowM[0];
                    break;
                case 27:
                    traceFeedback.lineVector = traceFeedback.LowN[0];
                    break;
                case 29:
                    traceFeedback.lineVector = traceFeedback.LowO[0];
                    break;
                case 31:
                    traceFeedback.lineVector = traceFeedback.LowP[0];
                    break;
                case 33:
                    traceFeedback.lineVector = traceFeedback.LowQ[0];
                    break;
                case 35:
                    traceFeedback.lineVector = traceFeedback.LowR[0];
                    break;
                case 37:
                    traceFeedback.lineVector = traceFeedback.LowS[0];
                    break;
                case 39:
                    traceFeedback.lineVector = traceFeedback.LowT[0];
                    break;
                case 41:
                    traceFeedback.lineVector = traceFeedback.LowU[0];
                    break;
                case 43:
                    traceFeedback.lineVector = traceFeedback.LowV[0];
                    break;
                case 45:
                    traceFeedback.lineVector = traceFeedback.LowW[0];
                    break;
                case 47:
                    traceFeedback.lineVector = traceFeedback.LowX[0];
                    break;
                case 49:
                    traceFeedback.lineVector = traceFeedback.LowY[0];
                    break;
                case 51:
                    traceFeedback.lineVector = traceFeedback.LowZ[0];
                    break;
                case 53:
                    traceFeedback.lineVector = traceFeedback.Vlup[0];
                    break;
                case 55:
                    traceFeedback.lineVector = traceFeedback.Vldown[0];
                    break;
                case 57:
                    traceFeedback.lineVector = traceFeedback.Hlleft[0];
                    break;
                case 59:
                    traceFeedback.lineVector = traceFeedback.Hlright[0];
                    break;
                case 61:
                    traceFeedback.lineVector = traceFeedback.Dltlbr[0];
                    break;
                case 63:
                    traceFeedback.lineVector = traceFeedback.Dltrbl[0];
                    break;
                case 65:
                    traceFeedback.lineVector = traceFeedback.Dlbltr[0];
                    break;
                case 67:
                    traceFeedback.lineVector = traceFeedback.Sctl[0];
                    break;
                case 69:
                    traceFeedback.lineVector = traceFeedback.Sctr[0];
                    break;
                case 71:
                    traceFeedback.lineVector = traceFeedback.Scbr[0];
                    break;
                case 73:
                    traceFeedback.lineVector = traceFeedback.Sclup[0];
                    break;
                case 75:
                    traceFeedback.lineVector = traceFeedback.Scldown[0];
                    break;
                case 77:
                    traceFeedback.lineVector = traceFeedback.Scrup[0];
                    break;
                case 79:
                    traceFeedback.lineVector = traceFeedback.Scrdown[0];
                    break;
                default:
                    break;
            }
        traceFeedback.isDone = false;
        traceFeedback.directer.Stop();
    }
}
