using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LineVector
{
    public static Vector3 startPoint0;
    public Vector3 startPoint;
    public Vector3 endPoint;
    public bool isCurved;
    public bool openLeft;
  
    public bool openRight;

    public bool openUp;
    public bool openDown;
    public bool isHorizontal;
    public bool isVertical;
    public bool isDiagonal;
    public bool pickUp;

    public Vector3 controlPoint;
    public Vector3 controlPoint2;
    public static LineVector[][] alphabet;
    int i;

    public LineVector[][] InitializeAlphabet()
    {
        alphabet = new LineVector[80][];

         for (i = 0; i < 80; i++)
        {
            alphabet[i] = new LineVector[1];
        }
        alphabet[0] = GetCapA();
        alphabet[1] = GetLowA();
        alphabet[2] = GetLowC();
        alphabet[3] = GetLowB();
        //alphabet[4] = GetCapC();
        alphabet[5] = GetLowC();
        //alphabet[6] = GetCapD();
        alphabet[7] = GetLowD();
        //alphabet[8] = GetCapE();
        alphabet[9] = GetLowE();
        //alphabet[10] = GetCapF();
        alphabet[11] = GetLowF();
        //alphabet[22] = GetCapG();
        alphabet[13] = GetLowG();
        //alphabet[14] = GetCapH();
        alphabet[15] = GetLowH();
        //alphabet[16] = GetCapI();
        alphabet[17] = GetLowI();
        //alphabet[18] = GetCapJ();
        alphabet[19] = GetLowJ();
        //alphabet[20] = GetCapK();
        alphabet[21] = GetLowK();
        //alphabet[22] = GetCapL();
        alphabet[23] = GetLowL();
        //alphabet[24] = GetCapM();
        alphabet[25] = GetLowM();
        //alphabet[26] = GetCapN();
        alphabet[27] = GetLowN();
        //alphabet[28] = GetCapO();
        alphabet[29] = GetLowO();
        //alphabet[30] = GetCapP();
        alphabet[31] = GetLowP();
        //alphabet[32] = GetCapQ();
        alphabet[33] = GetLowQ();
        //alphabet[34] = GetCapR();
        alphabet[35] = GetLowR();
        //alphabet[36] = GetCapS();
        alphabet[37] = GetLowS();
        //alphabet[38] = GetCapT();
        alphabet[39] = GetLowT();
        //alphabet[40] = GetCapU();
        alphabet[41] = GetLowU();
        //alphabet[42] = GetCapV();
        alphabet[43] = GetLowV();
        //alphabet[44] = GetCapQ();
        alphabet[45] = GetLowQ();
        //alphabet[46] = GetCapX();
        alphabet[47] = GetLowX();
        //alphabet[48] = GetCapY();
        alphabet[49] = GetLowY();
        //alphabet[50] = GetCapZ();
        alphabet[51] = GetLowZ();
        alphabet[53] = GetVlup();
        alphabet[55] = GetVldown();
        alphabet[57] = GetHlleft();
        alphabet[59] = GetHlright();
        alphabet[61] = GetDltlbr();
        alphabet[63] = GetDltrbl();
        alphabet[65] = GetDlbltr();
        alphabet[67] = GetSctl();
        alphabet[69] = GetSctr();
        alphabet[71] = GetScbr();
        alphabet[73] = GetSclup();
        alphabet[75] = GetScldown();
        alphabet[77] = GetScrup();
        alphabet[79] = GetScrdown();
        
        return alphabet;
    }
    public static LineVector[] GetCapA()
    {
        LineVector[] capA = new LineVector[3];

        Vector3 startPoint0 = new Vector3(0.007f,0f, 0.2321f); 
        Vector3 endPoint0 = new Vector3(-0.165f,0f, -0.242f);
        Vector3 startPoint1 = new Vector3(0.007f,0f, 0.2321f);
        Vector3 endPoint1 = new Vector3(0.19f,0f, -0.25f);
        Vector3 startPoint2 = new Vector3(-0.11f,0f, -0.09f);
        Vector3 endPoint2 = new Vector3(0.14f,0f, -0.09f);

        capA[0].SetLineVector(startPoint0, endPoint0);
        capA[1].SetLineVector(startPoint1, endPoint1);
        capA[2].SetLineVector(startPoint2, endPoint2);
        

        return capA;
    }

    public static LineVector[] GetLowA()
    {
        LineVector[] lowA = new LineVector[2];

        Vector3 startPoint0 = new Vector3(0.11f,0f, -0.15f);
        Vector3 endPoint0 = new Vector3(0.11f,0f, 0.1f);
        Vector3 startPoint1 = new Vector3(0.11f,0f, 0.1f);
        Vector3 endPoint1 = new Vector3(0.11f,0f, -0.11f);
        Vector3 controlPoint1 = new Vector3(-0.2f,0f, 0.35f);
        Vector3 controlPoint11 = new Vector3(-0.25f,0f, -0.35f);

        lowA[0].SetLineVector(startPoint0, endPoint0);
        lowA[1].SetLineVector(startPoint1, endPoint1, controlPoint1, controlPoint11);
        lowA[0].isCurved = false;
        lowA[0].isVertical = true;
        lowA[0].isHorizontal = false;
        lowA[1].openRight = true;
        lowA[1].isCurved = true;

        return lowA;
    }

    public static LineVector[] GetLowB()
    {
        LineVector[] lowB = new LineVector[2];
        
        Vector3 startPoint0 = new Vector3(-0.1f,0f, 0.23f);
        Vector3 endPoint0 = new Vector3(-0.1f,0f, -0.24f);
        Vector3 endPoint1 = new Vector3(-0.1f,0f, -0.04f);
        Vector3 startPoint1 = new Vector3(-0.1f,0f, -0.24f);
        Vector3 controlPoint11 = new Vector3(0.24f,0f, 0.1f);
        Vector3 controlPoint1 = new Vector3(0.18f,0f, -0.38f);

        lowB[0].SetLineVector(startPoint0, endPoint0);
        lowB[1].SetLineVector(startPoint1, endPoint1, controlPoint1, controlPoint11);
        lowB[0].isVertical = true;
        lowB[1].isCurved = true;
        lowB[1].openLeft = true;

        return lowB;

    }

    public static LineVector[] GetLowC()
    {
        LineVector[] lowC = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0.124f,0f, 0.12f);
        Vector3 endPoint0 = new Vector3(0.124f,0f, -0.125f);
        Vector3 controlPoint0 = new Vector3(-0.23f,0f, 0.35f);
        Vector3 controlPoint01 = new Vector3(-0.23f,0f, -0.35f);

        lowC[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        lowC[0].isCurved = true;
        lowC[0].openRight = true;

        return lowC;
    }

    public static LineVector[] GetLowD()
    {
        LineVector[] lowD = new LineVector[2];

        Vector3 endPoint1 = new Vector3(0.111f, 0f, -0.046f);
        Vector3 startPoint1 = new Vector3(0.111f, 0f, -0.183f);
        Vector3 controlPoint01 = new Vector3(-0.21f, 0f, 0.2f);
        Vector3 controlPoint0 = new Vector3(-0.18f, 0f, -0.48f);
        Vector3 startPoint0 = new Vector3(0.111f, 0f, 0.225f);
        Vector3 endPoint0 = new Vector3(0.111f, 0f, -0.24f);

        lowD[0].SetLineVector(startPoint0, endPoint0);
        lowD[1].SetLineVector(startPoint1, endPoint1, controlPoint0, controlPoint01);
        lowD[0].isVertical = true;
        lowD[1].isCurved = true;
        lowD[1].openRight = true;

        return lowD;
    }

    public static LineVector[] GetLowE()
    {
        LineVector[] lowE = new LineVector[2];

        Vector3 startPoint0 = new Vector3(-0.13f,0f, 0f);
        Vector3 endPoint0 = new Vector3(0.161f,0f, 0f);
        Vector3 startPoint1 = new Vector3(0.161f,0f, 0f);
        Vector3 endPoint1 = new Vector3(0.14f,0f, -0.142f);
        Vector3 controlPoint1 = new Vector3(-0.05f,0f, 0.56f);
        Vector3 controlPoint11 = new Vector3(-0.4f,0f, -0.33f);

        lowE[0].SetLineVector(startPoint0, endPoint0);
        lowE[1].SetLineVector(startPoint1, endPoint1, controlPoint1, controlPoint11);
        lowE[0].isHorizontal = true;
        lowE[1].isCurved = true;
        lowE[1].openRight = true;

        return lowE;
    }

    public static LineVector[] GetLowF()
    {
        LineVector[] lowF = new LineVector[3];

        Vector3 endPoint1 = new Vector3(0.115f,0f, 0.178f);
        Vector3 startPoint0 = new Vector3(-0.041f,0f, -0.244f);
        Vector3 controlPoint1 = new Vector3(-0.05f,0f, 0.35f);
        Vector3 controlPoint11 = new Vector3(0.1f,0f, 0.35f);
        Vector3 endPoint2 = new Vector3(-0.121f,0f, 0f);
        Vector3 startPoint2 = new Vector3(0.06f,0f, 0f);
        Vector3 endPoint0 = new Vector3(-0.041f,0f, 0.2f);
        Vector3 startPoint1 = new Vector3(-0.041f,0f, 0.2f);

        lowF[0].SetLineVector(startPoint0, endPoint0);
        lowF[1].SetLineVector(startPoint1, endPoint1, controlPoint1, controlPoint11);
        lowF[2].SetLineVector(startPoint2, endPoint2);
        lowF[0].isVertical = true;
        lowF[1].isCurved = true;
        lowF[1].openDown = true;
        lowF[2].isHorizontal = true;
        lowF[2].pickUp = true;

        return lowF;
    }

    public static LineVector[] GetLowG()
    {
        LineVector[] lowG = new LineVector[3];

        Vector3 startPoint2 = new Vector3(0.13f,0f, 0.178f);
        Vector3 endPoint2 = new Vector3(0.13f,0f, -0.02f);
        Vector3 controlPoint2 = new Vector3(-0.23f,0f, 0.35f);
        Vector3 controlPoint21 = new Vector3(-0.23f,0f, -0.2f);
        Vector3 endPoint1 = new Vector3(0.13f,0f, 0.174f);
        Vector3 startPoint0 = new Vector3(-0.12f,0f, -0.179f);
        Vector3 controlPoint0 = new Vector3(0.18f,0f, -0.3f);
        Vector3 controlPoint01 = new Vector3(0f,0f, -0.3f);
        Vector3 startPoint1 = new Vector3(0.13f,0f, -0.131f);
        Vector3 endPoint0 = new Vector3(0.13f,0f, -0.131f);

        lowG[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        lowG[1].SetLineVector(startPoint1, endPoint1);
        lowG[2].SetLineVector(startPoint2, endPoint2, controlPoint2, controlPoint21);
        lowG[0].isCurved = true;
        lowG[0].openUp = true;
        lowG[1].isVertical = true;
        lowG[2].isCurved = true;
        lowG[2].openRight = true;

        return lowG;
    }

    public static LineVector[] GetLowH()
    {
        LineVector[] lowH = new LineVector[2];

        Vector3 startPoint0 = new Vector3(-0.085f,0f, 0.235f);
        Vector3 endPoint0 = new Vector3(-0.085f,0f, -0.255f);
        Vector3 startPoint1 = new Vector3(-0.085f,0f, -0.255f);
        Vector3 endPoint1 = new Vector3(0.12f,0f, -0.255f);
        Vector3 controlPoint1 = new Vector3(-0.05f,0f, 0.1f);
        Vector3 controlPoint11 = new Vector3(0.17f,0f, 0f);

        lowH[0].SetLineVector(startPoint0, endPoint0);
        lowH[1].SetLineVector(startPoint1, endPoint1, controlPoint1, controlPoint11);
        lowH[0].isVertical = true;
        lowH[1].isCurved = true;
        lowH[1].openDown = true;

        return lowH;
    }

    public static LineVector[] GetLowI()
    {
        LineVector[] lowI = new LineVector[2];

        Vector3 startPoint1 = new Vector3(0f,0f, 0.043f);
        Vector3 endPoint1 = new Vector3(0f,0f, -0.23f);
        Vector3 startPoint0 = new Vector3(0f,0f, 0.23f);
        Vector3 endPoint0 = new Vector3(0f,0f, 0.14f);

        lowI[0].SetLineVector(startPoint0, endPoint0);
        lowI[1].SetLineVector(startPoint1, endPoint1);
        lowI[0].isVertical = true;
        lowI[1].isVertical = true;
        lowI[1].pickUp = true;

        return lowI;
    }

    public static LineVector[] GetLowJ()
    {
        LineVector[] lowJ = new LineVector[3];

        Vector3 startPoint1 = new Vector3(0.026f,0f, 0.108f);
        Vector3 endPoint2 = new Vector3(-0.05f,0f, -0.25f);
        Vector3 controlPoint2 = new Vector3(0.015f,0f, -0.26f);
        Vector3 controlPoint21 = new Vector3(.07f,0f, -0.35f);
        Vector3 startPoint0 = new Vector3(0.026f,0f, 0.27f);
        Vector3 endPoint0 = new Vector3(0.026f,0f, 0.19f);
        Vector3 endPoint1 = new Vector3(0.026f,0f, -.19f);
        Vector3 startPoint2 = new Vector3(0.026f,0f, -.19f);

        lowJ[0].SetLineVector(startPoint0, endPoint0);
        lowJ[1].SetLineVector(startPoint1, endPoint1);
        lowJ[2].SetLineVector(startPoint2, endPoint2, controlPoint2, controlPoint21);
        lowJ[0].isVertical = true;
        lowJ[1].isVertical = true;
        lowJ[1].pickUp = true;
        lowJ[2].isCurved = true;
        lowJ[2].openUp = true;

        return lowJ;
    }

    public static LineVector[] GetLowK()
    {
        LineVector[] lowK = new LineVector[5];

        Vector3 startPoint0 = new Vector3(-0.074f,0f, 0.25f);
        Vector3 endPoint0 = new Vector3(-0.074f,0f, -0.261f);
        Vector3 startPoint1 = new Vector3(-0.074f,0f, -0.261f);
        Vector3 endPoint1 = new Vector3(-0.074f,0f, -0.129f);
        Vector3 startPoint2 = new Vector3(-0.074f,0f, -0.129f);
        Vector3 endPoint2 = new Vector3(0.085f,0f, 0f);
        Vector3 startPoint3 = new Vector3(0.085f,0f, 0f);
        Vector3 endPoint3 = new Vector3(-0.074f,0f, -0.129f);
        Vector3 startPoint4 = new Vector3(-0.074f,0f, -0.129f);
        Vector3 endPoint4 = new Vector3(0.107f,0f, -0.261f);

        lowK[0].SetLineVector(startPoint0, endPoint0);
        lowK[1].SetLineVector(startPoint1, endPoint1);
        lowK[2].SetLineVector(startPoint2, endPoint2);
        lowK[3].SetLineVector(startPoint3, endPoint3);
        lowK[4].SetLineVector(startPoint4, endPoint4);
        lowK[0].isVertical = true;
        lowK[1].isVertical = true;
        lowK[2].isDiagonal = true;
        lowK[3].isDiagonal = true;
        lowK[4].isDiagonal = true;


        return lowK;
    }

    public static LineVector[] GetLowL()
    {
        LineVector[] lowL = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0.25f);
        Vector3 endPoint0 = new Vector3(0f,0f, -0.26f);

        lowL[0].SetLineVector(startPoint0, endPoint0);
        lowL[0].isVertical = true;

        return lowL;
    }

    public static LineVector[] GetLowM()
    {
        LineVector[] lowM = new LineVector[3];

        Vector3 startPoint0 = new Vector3(-0.205f,0f, 0.137f);
        Vector3 endPoint0 = new Vector3(-0.205f,0f, -0.167f);
        Vector3 startPoint1 = new Vector3(-0.205f,0f, -0.167f);
        Vector3 endPoint1 = new Vector3(0f,0f, -0.167f);
        Vector3 controlPoint1 = new Vector3(-0.23f,0f, 0.2f);
        Vector3 controlPoint11 = new Vector3(0f,0f, 0.2f);
        Vector3 startPoint2 = new Vector3(0f,0f, -0.167f);
        Vector3 endPoint2 = new Vector3(0.21f,0f, -0.167f);
        Vector3 controlPoint2 = new Vector3(0f,0f, 0.2f);
        Vector3 controlPoint21 = new Vector3(0.25f,0f, 0.2f);

        lowM[0].SetLineVector(startPoint0, endPoint0);
        lowM[1].SetLineVector(startPoint1, endPoint1, controlPoint1, controlPoint11);
        lowM[2].SetLineVector(startPoint2, endPoint2, controlPoint2, controlPoint21);
        lowM[0].isVertical = true;
        lowM[1].isCurved = true;
        lowM[1].openDown = true;
        lowM[2].isCurved = true;
        lowM[2].openDown = true;

        return lowM;
    }

    public static LineVector[] GetLowN()
    {
        LineVector[] lowN = new LineVector[2];

        Vector3 startPoint0 = new Vector3(-0.126f,0f, 0.145f);
        Vector3 endPoint0 = new Vector3(-0.121f,0f, -0.175f);
        Vector3 startPoint1 = new Vector3(-0.121f,0f, -0.175f);
        Vector3 endPoint1 = new Vector3(0.133f,0f, -0.175f);
        Vector3 controlPoint1 = new Vector3(-0.15f,0f, 0.226f);
        Vector3 controlPoint11 = new Vector3(0.2f,0f, 0.2f);
        

        lowN[0].SetLineVector(startPoint0, endPoint0);
        lowN[1].SetLineVector(startPoint1, endPoint1, controlPoint1, controlPoint11);
        lowN[0].isVertical = true;
        lowN[1].isCurved = true;
        lowN[1].openDown = true;

        return lowN;
    }

    public static LineVector[] GetLowO() /////////// could fix later had to split o into two parts
    {
        LineVector[] lowO = new LineVector[2];

        Vector3 startPoint0 = new Vector3(0f,0f, 0.15f);
        Vector3 endPoint0 = new Vector3(0f,0f, -0.15f);
        Vector3 controlPoint0 = new Vector3(-0.2f,0f, 0.15f);
        Vector3 controlPoint01 = new Vector3(-0.2f,0f, -0.15f);
        Vector3 startPoint1 = new Vector3(0f,0f, -0.15f);
        Vector3 endPoint1 = new Vector3(0f,0f, 0.15f);
        Vector3 controlPoint1 = new Vector3(0.2f,0f, -0.15f);
        Vector3 controlPoint11 = new Vector3(0.2f,0f, 0.15f);

        lowO[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        lowO[1].SetLineVector(startPoint1, endPoint1, controlPoint1, controlPoint11);
        lowO[0].isCurved = true;
        lowO[0].openRight = true;
        lowO[1].isCurved = true;
        lowO[1].openLeft = true;

        return lowO;
    }

    public static LineVector[] GetLowP()
    {
        LineVector[] lowP = new LineVector[2];

        Vector3 endPoint0 = new Vector3(-0.114f,0f, 0.178f);
        Vector3 startPoint0 = new Vector3(-0.114f,0f, -0.222f);
        Vector3 startPoint1 = new Vector3(-0.114f,0f, 0.159f);
        Vector3 endPoint1 = new Vector3(-0.114f,0f, 0f);
        Vector3 controlPoint1 = new Vector3(0.22f,0f, 0.34f);
        Vector3 controlPoint11 = new Vector3(0.18f,0f, -0.29f);
        

        lowP[0].SetLineVector(startPoint0, endPoint0);
        lowP[1].SetLineVector(startPoint1, endPoint1, controlPoint1, controlPoint11);
        lowP[0].isVertical = true;
        lowP[1].isCurved = true;
        lowP[1].openLeft = true;

        return lowP;
    }

    public static LineVector[] GetLowQ()
    {
        LineVector[] lowQ = new LineVector[3];

        Vector3 startPoint0 = new Vector3(0.177f,0f, -0.177f);
        Vector3 endPoint0 = new Vector3(0.039f,0f, -0.064f);
        Vector3 startPoint1 = new Vector3(0.039f,0f, -0.064f);
        Vector3 endPoint1 = new Vector3(0.039f,0f, 0.181f);
        Vector3 startPoint2 = new Vector3(0.039f,0f, 0.181f);
        Vector3 endPoint2 = new Vector3(0.039f,0f, -0.02f);
        Vector3 controlPoint2 = new Vector3(-0.27f,0f, 0.35f);
        Vector3 controlPoint21 = new Vector3(-0.27f,0f, -0.24f);
        Vector3 controlPoint0 = new Vector3(0.03f,0f, -0.35f);
        Vector3 controlPoint01 = new Vector3(0.03f,0f, -0.35f);

        lowQ[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        lowQ[1].SetLineVector(startPoint1, endPoint1);
        lowQ[2].SetLineVector(startPoint2, endPoint2, controlPoint2, controlPoint21);
        lowQ[0].isCurved = true;
        lowQ[0].openUp = true;
        lowQ[1].isVertical = true;
        lowQ[2].isCurved = true;
        lowQ[2].openRight = true;

        return lowQ;
    }

    public static LineVector[] GetLowR()
    {
        LineVector[] lowR = new LineVector[3];
        
        Vector3 startPoint0 = new Vector3(-0.079f,0f, 0.159f);
        Vector3 endPoint0 = new Vector3(-0.079f,0f, -0.185f);
        Vector3 startPoint1 = new Vector3(-0.079f,0f, -0.185f);
        Vector3 endPoint1 = new Vector3(-0.079f,0f, 0.115f);
        Vector3 startPoint2 = new Vector3(-0.079f,0f, 0.115f);
        Vector3 endPoint2 = new Vector3(0.1f,0f, 0.156f);
        Vector3 controlPoint2 = new Vector3(0f,0f, 0.15f);
        Vector3 controlPoint21 = new Vector3(0f,0f, 0.15f);

        lowR[0].SetLineVector(startPoint0, endPoint0);
        lowR[1].SetLineVector(startPoint1, endPoint1);
        lowR[2].SetLineVector(startPoint2, endPoint2, controlPoint2, controlPoint21);
        lowR[0].isVertical = true;
        lowR[1].isVertical = true;
        lowR[2].isCurved = true;
        lowR[2].openDown = true;

        return lowR;
    }
    

    public static LineVector[] GetLowS()
    {
        LineVector[] lowS = new LineVector[3];

        Vector3 startPoint0 = new Vector3(0.095f,0f, 0.14f);
        Vector3 endPoint0 = new Vector3(-0.086f,0f, 0.045f);
        Vector3 controlPoint0 = new Vector3(-0.1f,0f, 0.24f);
        Vector3 controlPoint01 = new Vector3(-0.2f,0f, 0f);
        Vector3 startPoint1 = new Vector3(-0.086f,0f, 0.045f);
        Vector3 endPoint1 = new Vector3(0.099f,0f, -0.018f);
        Vector3 startPoint2 = new Vector3(0.099f,0f, -0.018f);
        Vector3 endPoint2 = new Vector3(-0.095f,0f, -0.14f);
        Vector3 controlPoint2 = new Vector3(0.2f,0f, 0f);
        Vector3 controlPoint21 = new Vector3(0.1f,0f, -0.27f);


        lowS[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        lowS[1].SetLineVector(startPoint1, endPoint1);
        lowS[2].SetLineVector(startPoint2, endPoint2, controlPoint2, controlPoint21);
        lowS[0].isCurved = true;
        lowS[0].openDown = true;
        lowS[1].isDiagonal = true;
        lowS[2].isCurved = true;
        lowS[2].openUp = true;

        return lowS;
    }

    public static LineVector[] GetLowT()
    {
        LineVector[] lowT = new LineVector[2];

        Vector3 startPoint0 = new Vector3(0.007f,0f, 0.254f);
        Vector3 endPoint0 = new Vector3(0.007f,0f, -0.275f);
        Vector3 startPoint1 = new Vector3(-0.103f,0f, 0.039f);
        Vector3 endPoint1 = new Vector3(0.134f,0f, 0.039f);

        lowT[0].SetLineVector(startPoint0, endPoint0);
        lowT[1].SetLineVector(startPoint1, endPoint1);
        lowT[0].isVertical = true;
        lowT[1].isHorizontal = true;
        lowT[1].pickUp = true;

        return lowT;
    }

    public static LineVector[] GetLowU()
    {
        LineVector[] lowU = new LineVector[2];

        Vector3 startPoint0 = new Vector3(-0.13f,0f, 0.171f);
        Vector3 endPoint0 = new Vector3(0.13f,0f, 0.171f);
        Vector3 controlPoint0 = new Vector3(-0.18f,0f, -0.25f);
        Vector3 controlPoint01 = new Vector3(0f,0f, -0.2f);
        Vector3 startPoint1 = new Vector3(0.13f,0f, 0.171f);
        Vector3 endPoint1 = new Vector3(0.13f,0f, -0.156f);

        lowU[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        lowU[1].SetLineVector(startPoint1, endPoint1);
        lowU[0].isCurved = true;
        lowU[0].openUp = true;
        lowU[1].isVertical = true;

        return lowU;
    }

    public static LineVector[] GetLowV()
    {
        LineVector[] lowV = new LineVector[2];

        Vector3 startPoint0 = new Vector3(-0.116f,0f, 0.152f);
        Vector3 endPoint0 = new Vector3(0f,0f, -0.18f);
        Vector3 startPoint1 = new Vector3(0f,0f, -0.18f);
        Vector3 endPoint1 = new Vector3(0.132f,0f, 0.152f);

        lowV[0].SetLineVector(startPoint0, endPoint0);
        lowV[1].SetLineVector(startPoint1, endPoint1);
        lowV[0].isDiagonal = true;
        lowV[1].isDiagonal = true;

        return lowV;
    }

    public static LineVector[] GetLowW()
    {
        LineVector[] lowW = new LineVector[4];

        Vector3 startPoint0 = new Vector3(-0.223f,0f, 0.158f);
        Vector3 endPoint0 = new Vector3(-0.118f,0f, -0.167f);
        Vector3 startPoint1 = new Vector3(-0.118f,0f, -0.167f);
        Vector3 endPoint1 = new Vector3(0f,0f, 0.158f);
        Vector3 startPoint2 = new Vector3(0f,0f, 0.158f);
        Vector3 endPoint2 = new Vector3(0.118f,0f, -0.167f);
        Vector3 startPoint3 = new Vector3(0.118f,0f, -0.167f);
        Vector3 endPoint3 = new Vector3(0.223f,0f, 0.158f);

        lowW[0].SetLineVector(startPoint0, endPoint0);
        lowW[1].SetLineVector(startPoint1, endPoint1);
        lowW[2].SetLineVector(startPoint2, endPoint2);
        lowW[3].SetLineVector(startPoint3, endPoint3);
        lowW[0].isDiagonal = true;
        lowW[1].isDiagonal = true;
        lowW[2].isDiagonal = true;
        lowW[3].isDiagonal = true;


        return lowW;
    }

    public static LineVector[] GetLowX()
    {
        LineVector[] lowX = new LineVector[2];

        Vector3 startPoint0 = new Vector3(-0.15f,0f, 0.18f);
        Vector3 endPoint0 = new Vector3(0.15f,0f, -0.18f);
        Vector3 startPoint1 = new Vector3(0.15f,0f, 0.18f);
        Vector3 endPoint1 = new Vector3(-0.15f,0f, -0.18f);


        lowX[0].SetLineVector(startPoint0, endPoint0);
        lowX[1].SetLineVector(startPoint1, endPoint1);
        lowX[0].isDiagonal = true;
        lowX[1].isDiagonal = true;

        return lowX;
    }

    public static LineVector[] GetLowY()
    {
        LineVector[] lowY = new LineVector[3];

        Vector3 startPoint0 = new Vector3(-0.1f,0f, 0.205f);
        Vector3 endPoint0 = new Vector3(0.009f,0f, -0.065f);
        Vector3 startPoint1 = new Vector3(0.009f,0f,-0.065f);
        Vector3 endPoint1 = new Vector3(0.1f,0f,0.205f);
        Vector3 startPoint2 = new Vector3(0.1f,0f, 0.205f);
        Vector3 endPoint2 = new Vector3(-0.05f,0f, -0.216f);

        lowY[0].SetLineVector(startPoint0, endPoint0);
        lowY[1].SetLineVector(startPoint1, endPoint1);
        lowY[2].SetLineVector(startPoint2, endPoint2);
        lowY[0].isDiagonal = true;
        lowY[1].isDiagonal = true;
        lowY[2].isDiagonal = true;

        return lowY;
    }
    
    public static LineVector[] GetLowZ()
    {
        LineVector[] lowZ = new LineVector[3];

        Vector3 startPoint0 = new Vector3(-0.153f,0f, 0.175f);
        Vector3 endPoint0 = new Vector3(0.153f,0f, 0.175f);
        Vector3 startPoint1 = new Vector3(0.153f,0f, 0.175f);
        Vector3 endPoint1 = new Vector3(-0.153f,0f, -0.175f);
        Vector3 startPoint2 = new Vector3(-0.153f,0f, -0.175f);
        Vector3 endPoint2 = new Vector3(0.153f,0f, -0.175f);

        lowZ[0].SetLineVector(startPoint0, endPoint0);
        lowZ[1].SetLineVector(startPoint1, endPoint1);
        lowZ[2].SetLineVector(startPoint2, endPoint2);
        lowZ[0].isHorizontal = true;
        lowZ[1].isDiagonal = true;
        lowZ[2].isHorizontal = true;

        return lowZ;
    }

    public static LineVector[] GetVlup()
    {
        LineVector[] vlup = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0);
        Vector3 endPoint0 = new Vector3(0f,0f, 0.2f);

        vlup[0].SetLineVector(startPoint0, endPoint0);
        
        vlup[0].isVertical = true;

        return vlup;
    }

    public static LineVector[] GetVldown()
    {
        LineVector[] vldown = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0);
        Vector3 endPoint0 = new Vector3(0f,0f, -0.2f);

        vldown[0].SetLineVector(startPoint0, endPoint0);
        
        vldown[0].isVertical = true;

        return vldown;
    }

    public static LineVector[] GetHlleft()
    {
        LineVector[] hlleft = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0);
        Vector3 endPoint0 = new Vector3(-0.2f,0f, 0f);

        hlleft[0].SetLineVector(startPoint0, endPoint0);
        
        hlleft[0].isHorizontal = true;

        return hlleft;
    }

    public static LineVector[] GetHlright()
    {
        LineVector[] hlright = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0);
        Vector3 endPoint0 = new Vector3(0.2f,0f, 0f);

        hlright[0].SetLineVector(startPoint0, endPoint0);
        
        hlright[0].isHorizontal = true;

        return hlright;
    }

    public static LineVector[] GetDltlbr()
    {
        LineVector[] dltlbr = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0);
        Vector3 endPoint0 = new Vector3(0.2f,0f, -0.2f);

        dltlbr[0].SetLineVector(startPoint0, endPoint0);
        
        dltlbr[0].isDiagonal = true;

        return dltlbr;
    }

    public static LineVector[] GetDltrbl()
    {
        LineVector[] dltrbl = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0);
        Vector3 endPoint0 = new Vector3(-0.2f,0f, -0.2f);

        dltrbl[0].SetLineVector(startPoint0, endPoint0);
        
        dltrbl[0].isDiagonal = true;

        return dltrbl;
    }

    public static LineVector[] GetDlbrtl()
    {
        LineVector[] dlbrtl = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0);
        Vector3 endPoint0 = new Vector3(-0.2f,0f, 0.2f);

        dlbrtl[0].SetLineVector(startPoint0, endPoint0);
        
        dlbrtl[0].isDiagonal = true;

        return dlbrtl;
    }

    public static LineVector[] GetDlbltr()
    {
        LineVector[] dlbltr = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0);
        Vector3 endPoint0 = new Vector3(0.2f,0f, 0.2f);

        dlbltr[0].SetLineVector(startPoint0, endPoint0);
        
        dlbltr[0].isDiagonal = true;

        return dlbltr;
    }

    public static LineVector[] GetSctl()
    {
        LineVector[] sctl = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0f);
        Vector3 endPoint0 = new Vector3(-0.2f,0f, 0f);
        Vector3 controlPoint0 = new Vector3(0f,0f, 0.2f);
        Vector3 controlPoint01 = new Vector3(-0.2f,0f, 0.2f);

        sctl[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        sctl[0].isCurved = true;
        sctl[0].openDown = true;

        return sctl;
    }

    public static LineVector[] GetSctr()
    {
        LineVector[] sctr = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0f);
        Vector3 endPoint0 = new Vector3(0.2f,0f, 0f);
        Vector3 controlPoint0 = new Vector3(0f,0f, 0.2f);
        Vector3 controlPoint01 = new Vector3(0.2f,0f, 0.2f);

        sctr[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        sctr[0].isCurved = true;
        sctr[0].openDown = true;

        return sctr;
    }

    public static LineVector[] GetScbl()
    {
        LineVector[] scbl = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0f);
        Vector3 endPoint0 = new Vector3(-0.2f,0f, 0f);
        Vector3 controlPoint0 = new Vector3(0f,0f, -0.2f);
        Vector3 controlPoint01 = new Vector3(-0.2f,0f, -0.2f);

        scbl[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        scbl[0].isCurved = true;
        scbl[0].openUp = true;

        return scbl;
    }

    public static LineVector[] GetScbr()
    {
        LineVector[] scbr = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0f);
        Vector3 endPoint0 = new Vector3(0.2f,0f, 0f);
        Vector3 controlPoint0 = new Vector3(0f,0f, -0.2f);
        Vector3 controlPoint01 = new Vector3(0.2f,0f, -0.2f);

        scbr[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        scbr[0].isCurved = true;
        scbr[0].openUp = true;

        return scbr;
    }

    public static LineVector[] GetSclup()
    {
        LineVector[] sclup = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0f);
        Vector3 endPoint0 = new Vector3(0f,0f, 0.2f);
        Vector3 controlPoint0 = new Vector3(-0.2f,0f, 0f);
        Vector3 controlPoint01 = new Vector3(-0.2f,0f, 0.2f);

        sclup[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        sclup[0].isCurved = true;
        sclup[0].openRight = true;

        return sclup;
    }

    public static LineVector[] GetScldown()
    {
        LineVector[] scldown = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0f);
        Vector3 endPoint0 = new Vector3(0f,0f, -0.2f);
        Vector3 controlPoint0 = new Vector3(-0.2f,0f, 0f);
        Vector3 controlPoint01 = new Vector3(-0.2f,0f, -0.2f);

        scldown[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        scldown[0].isCurved = true;
        scldown[0].openRight = true;

        return scldown;
    }

    public static LineVector[] GetScrup()
    {
        LineVector[] scrup = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0f);
        Vector3 endPoint0 = new Vector3(0f,0f, 0.2f);
        Vector3 controlPoint0 = new Vector3(0.2f,0f, 0f);
        Vector3 controlPoint01 = new Vector3(0.2f,0f, 0.2f);

        scrup[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        scrup[0].isCurved = true;
        scrup[0].openLeft = true;

        return scrup;
    }

    public static LineVector[] GetScrdown()
    {
        LineVector[] scrdown = new LineVector[1];

        Vector3 startPoint0 = new Vector3(0f,0f, 0f);
        Vector3 endPoint0 = new Vector3(0f,0f, -0.2f);
        Vector3 controlPoint0 = new Vector3(0.2f,0f, 0f);
        Vector3 controlPoint01 = new Vector3(0.2f,0f, -0.2f);

        scrdown[0].SetLineVector(startPoint0, endPoint0, controlPoint0, controlPoint01);
        scrdown[0].isCurved = true;
        scrdown[0].openLeft = true;

        return scrdown;
    }




   

    

    public void SetLineVector(Vector3 startPoint, Vector3 endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.isCurved = false;
        this.controlPoint = Vector3.zero;
        this.controlPoint2 = Vector3.zero;
    }

    public void SetLineVector(Vector3 startPoint, Vector3 endPoint, Vector3 controlPoint, Vector3 controlPoint2)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.isCurved = true;
        this.controlPoint = controlPoint;
        this.controlPoint2 = controlPoint2;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        LineVector other = (LineVector)obj;

        return startPoint == other.startPoint && endPoint == other.endPoint;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + startPoint.GetHashCode();
            hash = hash * 23 + endPoint.GetHashCode();
            return hash;
        }
    }
    
}
