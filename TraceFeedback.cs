using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class TraceFeedback : MonoBehaviour
{
    public LineVector lineVector;
    public GameObject tipPen;
    public GameObject circle;
    public LineVector[][] alphabet;
    private LineVector[] letter;
    public letter_rotator currentInt;
    public LineVector[] letterArray;
    public StrokeAudio strokeAudio;

    private TemplateMatching templateMatcher;

    //public AudioSource foundPoint;
    public AudioSource directer;
    public AudioSource straightUp;
    public AudioSource circleLeftDown;
    public AudioSource straightDown;
    public AudioSource circleRightUp;
    public AudioSource circleLeftUp;
    public AudioSource circleUpLeft;
    public AudioSource circleUpRight;
    public AudioSource straightLeft;
    public AudioSource hookRight;
    public AudioSource straightUpRight;
    public AudioSource straightDownLeft;
    public AudioSource straightDownRight;
    public AudioSource circleRightDown;
    public AudioSource circleDownRight;
    public AudioSource straightRight;
    public AudioSource hookLeft;

    public AudioSource letterCompleted;

    public AudioSource pickUp;

    public bool startPoint0Reached = false;
    public bool startPoint1Reached = false;
    public bool startPoint2Reached = false;
    public bool startPoint3Reached = false;
    public bool startPoint4Reached = false;
    public bool endPoint0Reached = false;
    public bool endPoint1Reached = false;
    public bool endPoint2Reached = false;
    public bool endPoint3Reached = false;
    public bool endPoint4Reached = false;

    public bool curveReached = false;
    public bool penDown = false;
    public int startSound = 5;
    public float accumulateTime = 0;
    public float fixedTimer;
    public int stroke = 0;

    public Vector3 furtherPoint;
    public Vector3 tipPenLocalPosition;
    public Vector3 circlePoint;

    public LineVector[] LowA = LineVector.GetLowA();
    public LineVector[] LowB = LineVector.GetLowB();
    public LineVector[] LowC = LineVector.GetLowC();
    public LineVector[] LowD = LineVector.GetLowD();
    public LineVector[] LowE = LineVector.GetLowE();
    public LineVector[] LowF = LineVector.GetLowF();
    public LineVector[] LowG = LineVector.GetLowG();
    public LineVector[] LowH = LineVector.GetLowH();
    public LineVector[] LowI = LineVector.GetLowI();
    public LineVector[] LowJ = LineVector.GetLowJ();
    public LineVector[] LowK = LineVector.GetLowK();
    public LineVector[] LowL = LineVector.GetLowL();
    public LineVector[] LowM = LineVector.GetLowM();
    public LineVector[] LowN = LineVector.GetLowN();
    public LineVector[] LowO = LineVector.GetLowO();
    public LineVector[] LowP = LineVector.GetLowP();
    public LineVector[] LowQ = LineVector.GetLowQ();
    public LineVector[] LowR = LineVector.GetLowR();
    public LineVector[] LowS = LineVector.GetLowS();
    public LineVector[] LowT = LineVector.GetLowT();
    public LineVector[] LowU = LineVector.GetLowU();
    public LineVector[] LowV = LineVector.GetLowV();
    public LineVector[] LowW = LineVector.GetLowW();
    public LineVector[] LowX = LineVector.GetLowX();
    public LineVector[] LowY = LineVector.GetLowY();
    public LineVector[] LowZ = LineVector.GetLowZ();
    public LineVector[] Vlup = LineVector.GetVlup();
    public LineVector[] Vldown = LineVector.GetVldown();
    public LineVector[] Hlright = LineVector.GetHlright();
    public LineVector[] Hlleft = LineVector.GetHlleft();
    public LineVector[] Dltlbr = LineVector.GetDltlbr();
    public LineVector[] Dltrbl = LineVector.GetDltrbl();
    public LineVector[] Dlbrtl = LineVector.GetDlbrtl();
    public LineVector[] Dlbltr = LineVector.GetDlbltr();
    public LineVector[] Sctl = LineVector.GetSctl();
    public LineVector[] Sctr = LineVector.GetSctr();
    public LineVector[] Scbl = LineVector.GetScbl();
    public LineVector[] Scbr = LineVector.GetScbr();
    public LineVector[] Sclup = LineVector.GetSclup();
    public LineVector[] Scldown = LineVector.GetScldown();
    public LineVector[] Scrup = LineVector.GetScrup();
    public LineVector[] Scrdown = LineVector.GetScrdown();

    public PenMovementRecorder penMovementRecorder;

    float delayBeforeLetterStrokeAudio = 5.0f;
    float delayBeforeCompletion = 7.0f;
    public bool isDone;
    public Starter start;

    
    public void Start()
    {
        startPoint0Reached = false;
        startPoint1Reached = false;
        startPoint2Reached = false;
        startPoint3Reached = false;
        startPoint4Reached = false;
        endPoint0Reached = false;
        endPoint1Reached = false;
        endPoint2Reached = false;
        endPoint3Reached = false;
        endPoint4Reached = false;

        start = FindObjectOfType<Starter>();

        templateMatcher = FindObjectOfType<TemplateMatching>();
        fixedTimer = Time.fixedDeltaTime;

        currentInt = FindObjectOfType<letter_rotator>();
        LineVector y = new LineVector();
        alphabet = y.InitializeAlphabet();
        //Debug.Log(currentInt.i);
        letterArray = alphabet[currentInt.i];
        /*letterArray = alphabet[1];
        lineVector = letterArray[0]; 
        
        lineVector = LowA[0];*/
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentInt.i);
        if (currentInt.i != previousInt)
        {
            //Debug.Log("works");
            previousInt = currentInt.i; // Update previousInt to the current value

            switch (currentInt.i)
            {
                case 1:
                    lineVector = LowA[0];
                    letterArray = alphabet[1];
                    break;
                case 3:
                    lineVector = LowB[0];
                    letterArray = alphabet[3];
                    //Debug.Log("LOWB");
                    break;
                // Add cases for other values of rotate.i as needed
                case 5:
                    lineVector = LowC[0];
                    letterArray = alphabet[5];
                    break;
                case 7:
                    lineVector = LowD[0];
                    letterArray = alphabet[7];
                    break;
                case 9:
                    lineVector = LowE[0];
                    letterArray = alphabet[9];
                    break;
                case 11:
                    lineVector = LowF[0];
                    letterArray = alphabet[11];
                    break;
                case 13:
                    lineVector = LowG[0];
                    letterArray = alphabet[13];
                    break;
                case 15: 
                    lineVector = LowH[0];
                    letterArray = alphabet[15];
                    break;
                case 17:
                    lineVector = LowI[0];
                    letterArray = alphabet[17];
                    break;
                case 19:
                    lineVector = LowJ[0];
                    letterArray = alphabet[19];
                    break;
                case 21:
                    lineVector = LowK[0];
                    letterArray = alphabet[21];
                    break;
                case 23:
                    lineVector = LowL[0];
                    letterArray = alphabet[23];
                    break;
                case 25:
                    lineVector = LowM[0];
                    letterArray = alphabet[25];

                    break;
                case 27:
                    lineVector = LowN[0];
                    letterArray = alphabet[27];
                    break;
                case 29:
                    lineVector = LowO[0];
                    letterArray = alphabet[29];
                    break;
                case 31:
                    lineVector = LowP[0];
                    letterArray = alphabet[31];
                    break;
                case 33:
                    lineVector = LowQ[0];
                    letterArray = alphabet[33];
                    break;
                case 35:
                    lineVector = LowR[0];
                    letterArray = alphabet[35];
                    break;
                case 37:
                    lineVector = LowS[0];
                    letterArray = alphabet[37];
                    break;
                case 39:
                    lineVector = LowT[0];
                    letterArray = alphabet[39];
                    break;
                case 41:
                    lineVector = LowU[0];
                    letterArray = alphabet[41];
                    break;
                case 43:
                    lineVector = LowV[0];
                    letterArray = alphabet[43];
                    break;
                case 45:
                    lineVector = LowW[0];
                    letterArray = alphabet[45];
                    break;
                case 47:
                    lineVector = LowX[0];
                    letterArray = alphabet[47];
                    break;
                case 49:
                    lineVector = LowY[0];
                    letterArray = alphabet[49];
                    break;
                case 51:
                    lineVector = LowZ[0];
                    letterArray = alphabet[51];
                    break;
                case 53:
                    lineVector = Vlup[0];
                    letterArray = alphabet[53];
                    break;
                case 55:
                    lineVector = Vldown[0];
                    letterArray = alphabet[55];
                    break;
                case 57:
                    lineVector = Hlleft[0];
                    letterArray = alphabet[57];
                    break;
                case 59:
                    lineVector = Hlright[0];
                    letterArray = alphabet[59];
                    break;
                case 61:
                    lineVector = Dltlbr[0];
                    letterArray = alphabet[61];
                    break;
                case 63:
                    lineVector = Dltrbl[0];
                    letterArray = alphabet[63];
                    break;
                case 65:
                    lineVector = Dlbltr[0];
                    letterArray = alphabet[65];
                    break;
                case 67:
                    lineVector = Sctl[0];
                    letterArray = alphabet[67];
                    break;
                case 69:
                    lineVector = Sctr[0];
                    letterArray = alphabet[69];
                    break;
                case 71:
                    lineVector = Scbr[0];
                    letterArray = alphabet[71];
                    break;
                case 73:
                    lineVector = Sclup[0];
                    letterArray = alphabet[73];
                    break;
                case 75:
                    lineVector = Scldown[0];
                    letterArray = alphabet[75];
                    break;
                case 77:
                    lineVector = Scrup[0];
                    letterArray = alphabet[77];
                    break;
                case 79:
                    lineVector = Scrdown[0];
                    letterArray = alphabet[79];
                    break;
                default:
                    // Default case: set lineVector to some default value if needed
                    break;
            }


        }
        CheckContact();
        //SDebug.Log("start: " + startPoint0 + " Pen: " + tipPenLocalPosition);
 
    }

    private int previousInt;


    private void GetToStart(bool startPointReached)
    {
        // Convert the world space position of tipPen to the local space of this game object
        tipPenLocalPosition = transform.InverseTransformPoint(tipPen.transform.position);
        float otherPointX = lineVector.startPoint.x + start.biasX;
        float otherPointZ = lineVector.startPoint.z + start.biasZ;
        float changeX = Mathf.Abs(otherPointX - tipPenLocalPosition.x);
        float changeZ = Mathf.Abs(otherPointZ - tipPenLocalPosition.z);
        if(startPointReached == false)
        {
            Sonification(otherPointX, otherPointZ, tipPenLocalPosition);
        }
    }

    public int CheckContact()
    {
        templateMatcher = FindObjectOfType<TemplateMatching>();
        penMovementRecorder = FindObjectOfType<PenMovementRecorder>();
        //STARTPOINT CHECK
        tipPenLocalPosition = transform.InverseTransformPoint(tipPen.transform.position);
        float distanceStart = Vector3.Distance(new Vector3(lineVector.startPoint.x + start.biasX, 0f, lineVector.startPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));
        //GetToStart(startPoint0Reached);
       

        //Debug.Log("Pen: " + tipPenLocalPosition + " Start: " + lineVector.startPoint);
        if ((distanceStart < 0.05) && startPoint0Reached == false)
        {
            directer.Stop();
            //straightUp.Play();
            letterStroke();
            stroke = 0;
            startPoint0Reached = true;
            penMovementRecorder.StartRecording();
            Debug.Log("Start Point Reached");
            templateMatcher.GetTemplate();
            Debug.Log(lineVector.endPoint.x);
        } 
        //ENDPOINT CHECK
        float distanceEnd = Vector3.Distance(new Vector3(lineVector.endPoint.x + start.biasX, 0f, lineVector.endPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));
        if(startPoint0Reached == true && endPoint0Reached == false)
        {
            
            CheckTrace(accumulateTime, fixedTimer, startSound, startPoint0Reached);  
            if(distanceEnd < 0.05)
            {
                Debug.Log("THIS WORKS");
                directer.Stop();
                accumulateTime = 0f;
                endPoint0Reached = true;
                penMovementRecorder.StopRecording();
                penMovementRecorder.ClearTexture();
                if(letterArray.Length == 1)
                {
                    isDone = true;
                    directer.Stop();
                    StartCoroutine(PlayLetterCompletedAudioWithDelay(templateMatcher.corrections.Count));
                }
                if(letterArray.Length > 1)
                {
                    if(letterArray[1].pickUp == true)
                    {
                        StartCoroutine(PlayPickUpAudioWithDelay(templateMatcher.corrections.Count));
                    }
                }

            }
            Debug.Log("THIS WORKS");
        }
            
        //Debug.Log(letterArray.Length);
        // Letters w/ > 1 vectors
        Debug.Log(letterArray.Length);
        if(letterArray.Length > 1 && endPoint0Reached == true && endPoint1Reached == false)
        {
            lineVector = letterArray[1];
            templateMatcher.GetTemplate();
            float distanceStart1 = Vector3.Distance(new Vector3(lineVector.startPoint.x + start.biasX, 0f, lineVector.startPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));
            
            //GetToStart(startPoint1Reached);
            //Debug.Log(lineVector.startPoint);
            if ((distanceStart1 < 0.05) && startPoint1Reached == false)
            {  
                directer.Stop();
                Debug.Log(templateMatcher.corrections.Count);
                StartCoroutine(PlayLetterStrokeAudioWithDelay(templateMatcher.corrections.Count));
                accumulateTime = 0f;
                startPoint1Reached = true;
                
                penMovementRecorder.StartRecording();
                stroke = 1;
                
            }
            float distanceEnd1 = Vector3.Distance(new Vector3(lineVector.endPoint.x + start.biasX, 0f, lineVector.endPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));

            if(startPoint1Reached == true && endPoint1Reached == false){
                CheckTrace(accumulateTime, fixedTimer, startSound, startPoint1Reached);

                if(distanceEnd1 < 0.05)
                { 
                    directer.Stop();
                    accumulateTime = 0f;
                    endPoint1Reached = true;
                    penMovementRecorder.StopRecording();
                    penMovementRecorder.ClearTexture();
                    if(letterArray.Length == 2)
                    {
                        isDone = true;
                        directer.Stop();
                        StartCoroutine(PlayLetterCompletedAudioWithDelay(templateMatcher.corrections.Count));
                    }
                    if(letterArray.Length > 2)
                    {
                        if(letterArray[2].pickUp == true)
                        {
                            StartCoroutine(PlayPickUpAudioWithDelay(templateMatcher.corrections.Count));
                        }
                    }
                }
            }
        }
        if(letterArray.Length > 2 && endPoint1Reached == true && endPoint2Reached == false)
        {
            lineVector = letterArray[2];
            templateMatcher.GetTemplate();
            float distanceStart2 = Vector3.Distance(new Vector3(lineVector.startPoint.x + start.biasX, 0f, lineVector.startPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));
            //GetToStart(startPoint2Reached);
            if ((distanceStart2 < 0.05) && startPoint2Reached == false)
            {
                directer.Stop();
                StartCoroutine(PlayLetterStrokeAudioWithDelay(templateMatcher.corrections.Count));
                accumulateTime = 0f;
                startPoint2Reached = true;
                penMovementRecorder.StartRecording();
                stroke = 2;
                
            }
            float distanceEnd2 = Vector3.Distance(new Vector3(lineVector.endPoint.x + start.biasX, 0f, lineVector.endPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));

            if(startPoint2Reached == true && endPoint2Reached == false)
            {
                CheckTrace(accumulateTime, fixedTimer, startSound, startPoint2Reached);
                if(distanceEnd2 < 0.05)
                {
                    directer.Stop();
                    accumulateTime = 0f;
                    endPoint2Reached = true;
                    penMovementRecorder.StopRecording();
                    penMovementRecorder.ClearTexture();
                    if(letterArray.Length == 3)
                    {
                        isDone = true;
                        directer.Stop();
                        StartCoroutine(PlayLetterCompletedAudioWithDelay(templateMatcher.corrections.Count));
                    }
                }
            }
        } 
        if(letterArray.Length > 3 && endPoint2Reached == true && endPoint3Reached == false)
        {
            lineVector = letterArray[3];
            float distanceStart3 = Vector3.Distance(new Vector3(lineVector.startPoint.x + start.biasX, 0f, lineVector.startPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));

            //GetToStart(startPoint3Reached);
                if ((distanceStart3 < 0.05) && startPoint3Reached == false)
            {
                directer.Stop();
                StartCoroutine(PlayLetterStrokeAudioWithDelay(templateMatcher.corrections.Count));
                accumulateTime = 0f;
                startPoint3Reached = true;
                penMovementRecorder.StartRecording();
                stroke = 3;
                
            }
            float distanceEnd3 = Vector3.Distance(new Vector3(lineVector.endPoint.x + start.biasX, 0f, lineVector.endPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));

            if(startPoint3Reached == true && endPoint3Reached == false)
            {   
                CheckTrace(accumulateTime, fixedTimer, startSound, startPoint3Reached);
                if(distanceEnd3 < 0.05)
                { 
                    directer.Stop();
                    accumulateTime = 0f;
                    endPoint3Reached = true;
                    penMovementRecorder.StopRecording();
                    penMovementRecorder.ClearTexture();
                    if(letterArray.Length == 4)
                    {
                        isDone = true;
                        directer.Stop();
                        StartCoroutine(PlayLetterCompletedAudioWithDelay(templateMatcher.corrections.Count));
                    }
                }
            }
            
        }
        if(letterArray.Length > 4 && endPoint3Reached == true && endPoint4Reached == false)
        {
            lineVector = letterArray[4];
            templateMatcher.GetTemplate();
            float distanceStart4 = Vector3.Distance(new Vector3(lineVector.startPoint.x + start.biasX, 0f, lineVector.startPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));

            //GetToStart(startPoint4Reached);
            if ((distanceStart4 < 0.05) && startPoint4Reached == false)
            {
                directer.Stop();
                StartCoroutine(PlayLetterStrokeAudioWithDelay(templateMatcher.corrections.Count));
                accumulateTime = 0f;
                startPoint4Reached = true;
                penMovementRecorder.StartRecording();
                stroke = 4;
                
            }
            float distanceEnd4 = Vector3.Distance(new Vector3(lineVector.endPoint.x + start.biasX, 0f, lineVector.endPoint.z + start.biasZ), new Vector3(tipPenLocalPosition.x, 0f, tipPenLocalPosition.z));

            if(startPoint4Reached == true && endPoint4Reached == false)
            {
                CheckTrace(accumulateTime, fixedTimer, startSound, startPoint4Reached);
                if(distanceEnd4 < 0.05)
                { 
                    accumulateTime = 0f;
                    endPoint4Reached = true;
                    penMovementRecorder.StopRecording();
                    penMovementRecorder.ClearTexture();
                    isDone = true;
                    directer.Stop();
                    StartCoroutine(PlayLetterCompletedAudioWithDelay(templateMatcher.corrections.Count));
                
                }
            }
            
        }
            
        return stroke;
    }
        
private void CheckTrace(float accumulateTime, float fixedTimer, int startSound, bool startPointReached)
{
    tipPenLocalPosition = transform.InverseTransformPoint(tipPen.transform.position);
    if (startPointReached)
    {
        directer.volume = 0f;
        if (lineVector.isCurved == false)
        {
            Vector3 closestPoint = ClosestPointOnLineSegment(lineVector.startPoint, lineVector.endPoint, tipPenLocalPosition);
            float distanceToClosestPoint = Vector3.Distance(closestPoint, tipPenLocalPosition);

            float lineLength = Vector3.Distance(lineVector.startPoint, lineVector.endPoint);

            // Calculate t based on distance to the end of the line (instead of distance to the closestPoint)
            float t = Mathf.InverseLerp(0f, lineLength, distanceToClosestPoint);

            // Calculate the furtherPoint as a linear interpolation between closestPoint and endPoint
            furtherPoint = Vector3.Lerp(closestPoint, lineVector.endPoint, t);
            furtherPoint.z += start.biasZ;
            furtherPoint.x += start.biasX;
            furtherPoint.y = 0.04f;
        }
        if (lineVector.isCurved)
        {
            float t = CalculateTClosestToTipPen(lineVector.startPoint, lineVector.endPoint, lineVector.controlPoint, lineVector.controlPoint2, tipPenLocalPosition);
            float tOffset = 0.3f;
            t += tOffset;
            Vector3 closestPoint = ClosestPointOnCubicBezierCurve(lineVector.startPoint, lineVector.endPoint, lineVector.controlPoint, lineVector.controlPoint2, tipPenLocalPosition);
            float distanceToClosestPoint = Vector3.Distance(closestPoint, tipPenLocalPosition);

            float curveLength = CalculateCubicBezierLength(lineVector.startPoint, lineVector.endPoint, lineVector.controlPoint, lineVector.controlPoint2);

            furtherPoint = CalculateCubicBezierPoint(lineVector.startPoint, lineVector.endPoint, lineVector.controlPoint, lineVector.controlPoint2, t);
            furtherPoint.z += start.biasZ;
            furtherPoint.x += start.biasX;
            furtherPoint.y = 0.04f;
        }

        float changeX = Mathf.Abs(furtherPoint.x - tipPenLocalPosition.x);
        float changeZ = Mathf.Abs(furtherPoint.z - tipPenLocalPosition.z);
        accumulateTime = (float)System.Math.Round(accumulateTime, 3);
        StartCoroutine(PlaySonificationWithDelay(templateMatcher.corrections.Count, furtherPoint.x, furtherPoint.z, tipPenLocalPosition, lineVector.startPoint, lineVector.endPoint));

        //Sonification1(furtherPoint.x, furtherPoint.z, tipPenLocalPosition, lineVector.startPoint, lineVector.endPoint);

        if (circle != null)
        {
            circle.transform.localPosition = furtherPoint;
        }
    }
}



    // Calculates the closest point on a line segment to a given point
    private Vector3 ClosestPointOnLineSegment(Vector3 start, Vector3 end, Vector3 point)
    {
        Vector3 line = end - start;
        float lineMagnitude = line.magnitude;
        Vector3 lineDirection = line / lineMagnitude;

        float t = Mathf.Clamp01(Vector3.Dot(lineDirection, point - start) / lineMagnitude);
        Vector3 closestPoint = start + t * line;

        return closestPoint;
    }

    private Vector3 ClosestPointOnCubicBezierCurve(Vector3 startPoint, Vector3 endPoint, Vector3 controlPoint1, Vector3 controlPoint2, Vector3 testPoint)
    {
        int iterations = 100; // Increase iterations for higher accuracy
        float t = 1f; // Initial guess for parameter t
        float step = 0.25f; // Initial step size

        for (int i = 0; i < iterations; i++)
        {
            Vector3 pointOnCurve = CalculateCubicBezierPoint(startPoint, endPoint, controlPoint1, controlPoint2, t);
            Vector3 tangent = CalculateCubicBezierTangent(startPoint, endPoint, controlPoint1, controlPoint2, t);

            Vector3 displacement = testPoint - pointOnCurve;
            float projection = Vector3.Dot(displacement, tangent);

            if (projection > 0)
            {
                t += step;
            }
            else
            {
                t -= step;
            }

            step *= 0.5f;
        }

        return CalculateCubicBezierPoint(startPoint, endPoint, controlPoint1, controlPoint2, t);
    }

    private float CalculateCubicBezierLength(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        int segments = 100; // Increase segments for better accuracy
        float length = 0f;
        Vector3 previousPoint = p0;

        for (int i = 1; i <= segments; i++)
        {
            float t = i / (float)segments;
            Vector3 point = CalculateCubicBezierPoint(p0, p1, p2, p3, t);

            length += Vector3.Distance(previousPoint, point);
            previousPoint = point;
        }

        return length;
    }

    private float CalculateTClosestToTipPen(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 tipPenLocalPos)
    {
        int iterations = 1000;
        float tMin = 0f;
        float tMax = 1f;
        float minDistance = float.MaxValue;
        float closestT = 0f;

        for (int i = 0; i < iterations; i++)
        {
            float t = Mathf.Lerp(tMin, tMax, (float)i / (iterations - 1));
            Vector3 pointOnCurve = CalculateCubicBezierPoint(p0, p1, p2, p3, t);
            float distance = Vector3.Distance(pointOnCurve, tipPenLocalPos);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestT = t;
            }
        }

        return closestT;
    }

    private Vector3 CalculateCubicBezierPoint(Vector3 startPoint, Vector3 endPoint, Vector3 controlPoint1, Vector3 controlPoint2, float t)
    {
        t = Mathf.Clamp01(t);
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point =
            (uuu * startPoint) +
            (3f * uu * t * controlPoint1) +
            (3f * u * tt * controlPoint2) +
            (ttt * endPoint);

        return point;
    }

    private Vector3 CalculateCubicBezierTangent(Vector3 startPoint, Vector3 endPoint, Vector3 controlPoint1, Vector3 controlPoint2, float t)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 tangent =
            (-3f * uu * startPoint) +
            (3f * (1f - 4f * t + 3f * tt) * controlPoint1) +
            (3f * (2f * t - 3f * tt) * controlPoint2) +
            (3f * tt * endPoint);

        return tangent.normalized;
    }

    private void Sonification(float otherPointX, float otherPointZ, Vector3 tipPenLocalPosition)
    {
        // Volume changes based on change in X
        float maxDistanceX = 0.1f; // Define the maximum distance (adjust this value if needed)

        if (otherPointX > tipPenLocalPosition.x)
        {
            // Calculate the distance ratio from tipPen to the leftmost position
            float distanceRatio = Mathf.InverseLerp(otherPointX - maxDistanceX, otherPointX, tipPenLocalPosition.x);

            // Use SmoothStep to achieve a smoother transition
            float volume = Mathf.SmoothStep(1f, 0.7f, distanceRatio);
            directer.volume = volume;
        }
        else if (otherPointX < tipPenLocalPosition.x)
        {
            // Calculate the distance ratio from tipPen to the rightmost position
            float distanceRatio = Mathf.InverseLerp(otherPointX + maxDistanceX, otherPointX, tipPenLocalPosition.x);

            // Use SmoothStep to achieve a smoother transition
            float volume = Mathf.SmoothStep(0.6f, 0.1f, distanceRatio);
            directer.volume = volume;
        }
        // Pitch changes based on change in Z
       float maxDistanceZ = 0.1f; // Define the maximum distance (adjust this value if needed)

        if (otherPointZ > tipPenLocalPosition.z)
        {
            // Calculate the distance ratio from tipPen to the bottommost position
            float distanceRatio = Mathf.InverseLerp(otherPointZ - maxDistanceZ, otherPointZ, tipPenLocalPosition.z);

            // Use SmoothStep to achieve a smoother transition
            float pitch = Mathf.SmoothStep(3f, 2.5f, distanceRatio);
            directer.pitch = pitch;
        }
        else if (otherPointZ < tipPenLocalPosition.z)
        {
            // Calculate the distance ratio from tipPen to the topmost position
            float distanceRatio = Mathf.InverseLerp(otherPointZ + maxDistanceZ, otherPointZ, tipPenLocalPosition.z);

            // Use SmoothStep to achieve a smoother transition
            float pitch = Mathf.SmoothStep(2f, 1.5f, distanceRatio);
            directer.pitch = pitch;
        }
        //directer.Play();
    }

    /*private void Sonification1(float otherPointX, float otherPointZ, Vector3 tipPenLocalPosition, Vector3 start, Vector3 end)
    {
        float maxDistanceX = 0.1f;
        float maxDistanceZ = 0.1f;
        if(lineVector.isVertical)
        {
            float threshold = 0.025f;
            float top;
            float bottom;
            if(start.z > end.z)
            {
                top = start.z;
                bottom = end.z;
            }
            else
            {
                top = end.z;
                bottom = start.z;
            }
            if(tipPenLocalPosition.z > bottom && tipPenLocalPosition.z < top)
            {
                if(tipPenLocalPosition.x < otherPointX - threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointX - maxDistanceX, otherPointX, tipPenLocalPosition.x);
                    // Use SmoothStep to achieve a smoother transition
                    float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                else if(tipPenLocalPosition.x > otherPointX + threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointX + maxDistanceX, otherPointX, tipPenLocalPosition.x);
                    // Use SmoothStep to achieve a smoother transition
                    float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                else
                {
                    float volume = 0.3f;
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
            }
            if(tipPenLocalPosition.z < bottom || tipPenLocalPosition.z > top)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointZ + maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                float pitch = Mathf.SmoothStep(3f, 1.7f, distanceRatio);
                directer.pitch = pitch;
                float volume = 0.3f;
                directer.volume = volume;
            }
        }
        if(lineVector.isHorizontal || lineVector.isDiagonal)
        {
            float threshold = 0.025f;
            float left;
            float right;
            if(start.x > end.x)
            {
                right = start.x;
                left = end.x;
            }
            else
            {
                right = end.x;
                left = start.x;
            }
            if(tipPenLocalPosition.x > left && tipPenLocalPosition.x < right)
            {
                if(tipPenLocalPosition.z < otherPointZ - threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointZ - maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                    float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                    float volume = 0.3f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                else if(tipPenLocalPosition.z > otherPointZ + threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointZ + maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                    float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                    float volume = 0.3f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                else
                {
                    float volume = 0.3f;
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
            }
            if(tipPenLocalPosition.x < left || tipPenLocalPosition.x > right)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointX + maxDistanceX, otherPointX, tipPenLocalPosition.x);
                float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
        }

    //Curve open to right
        if(lineVector.isCurved && lineVector.openRight)
        {
            float threshold = 0.035f;
            float top;
            float bottom;
            if(start.z > end.z)
            {
                top = start.z;
                bottom = end.z;
            }
            else
            {
                top = end.z;
                bottom = start.z;
            }
            //Between Start and End Z
            if(tipPenLocalPosition.z > bottom && tipPenLocalPosition.z < top)
            {
                //Outside threshold X
                if(tipPenLocalPosition.x < otherPointX - threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointX - maxDistanceX, otherPointX, tipPenLocalPosition.x);
                    // Use SmoothStep to achieve a smoother transition
                    float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                else if(tipPenLocalPosition.x > otherPointX + threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointX + maxDistanceX, otherPointX, tipPenLocalPosition.x);
                    // Use SmoothStep to achieve a smoother transition
                    float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                //Good State
                else
                {
                    float volume = 0.3f;
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
            }
            //Outside threshold Z
            else if(tipPenLocalPosition.z < otherPointZ - threshold)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointZ - maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                float volume = 0.3f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            else if(tipPenLocalPosition.z > otherPointZ + threshold)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointZ + maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                float volume = 0.3f;
                directer.pitch = pitch;
                directer.volume = volume;
            }//Good State
            else
            {
                float volume = 0.3f;
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }//Too far right
            if(tipPenLocalPosition.x > start.x)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointX + maxDistanceX, otherPointX, tipPenLocalPosition.x);
                float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
        }

    //Circle open to the left
        if(lineVector.isCurved && lineVector.openLeft)
        {
            float threshold = 0.035f;
            float top;
            float bottom;
            if(start.z > end.z)
            {
                top = start.z;
                bottom = end.z;
            }
            else
            {
                top = end.z;
                bottom = start.z;
            }
            //Between start and end Z
            if(tipPenLocalPosition.z > bottom && tipPenLocalPosition.z < top)
            {
                //Outside threshold X
                if(tipPenLocalPosition.x < otherPointX - threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointX - maxDistanceX, otherPointX, tipPenLocalPosition.x);
                    // Use SmoothStep to achieve a smoother transition
                    float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                else if(tipPenLocalPosition.x > otherPointX + threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointX + maxDistanceX, otherPointX, tipPenLocalPosition.x);
                    // Use SmoothStep to achieve a smoother transition
                    float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                //Good State
                else
                {
                    float volume = 0.3f;
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
            }
            //Outside threshold z
            else if(tipPenLocalPosition.z < otherPointZ - threshold)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointZ - maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                float volume = 0.3f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            else if(tipPenLocalPosition.z > otherPointZ + threshold)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointZ + maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                float volume = 0.3f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            //Good State
            else
            {
                float volume = 0.3f;
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            //Too far left
            if(tipPenLocalPosition.x < start.x)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointX - maxDistanceX, otherPointX, tipPenLocalPosition.x);
                float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
        }


    //Circle open downwards
        if(lineVector.isCurved && lineVector.openDown)
        {
            float threshold = 0.035f;
            float left;
            float right;
            if(start.x > end.x)
            {
                right = start.x;
                left = end.x;
            }
            else
            {
                right = end.x;
                left = start.z;
            }
            //Between start and end X
            if(tipPenLocalPosition.x > left + threshold && tipPenLocalPosition.x < right - threshold)
            {
                //Outside threshold Z
                if(tipPenLocalPosition.z < otherPointZ - threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointZ - maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                    float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                    float volume = 0.3f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                else if(tipPenLocalPosition.z > otherPointZ + threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointZ + maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                    float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                    float volume = 0.3f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                //Good State
                else
                {
                    float volume = 0.3f;
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
            }
            //Outside threshold x
            else if(tipPenLocalPosition.x < otherPointX - threshold)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointX - maxDistanceX, otherPointX, tipPenLocalPosition.x);
                float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            else if(tipPenLocalPosition.x > otherPointX + threshold)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointX + maxDistanceX, otherPointX, tipPenLocalPosition.x);
                float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            //Good State
            else
            {
                float volume = 0.3f;
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            //Too far Down
            if(tipPenLocalPosition.z < start.z)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointZ - maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                float volume = 0.3f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
        }

        //Circle open upwards
        if(lineVector.isCurved && lineVector.openUp)
        {
            float threshold = 0.035f;
            float left;
            float right;
            if(start.x > end.x)
            {
                right = start.x;
                left = end.x;
            }
            else
            {
                right = end.x;
                left = start.z;
            }
            //Between start and end X
            if(tipPenLocalPosition.x > left + threshold && tipPenLocalPosition.x < right - threshold)
            {
                //Outside threshold Z
                if(tipPenLocalPosition.z < otherPointZ - threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointZ - maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                    float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                    float volume = 0.3f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                else if(tipPenLocalPosition.z > otherPointZ + threshold)
                {
                    float distanceRatio = Mathf.InverseLerp(otherPointZ + maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                    float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                    float volume = 0.3f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
                //Good State
                else
                {
                    float volume = 0.3f;
                    float pitch = 1f;
                    directer.pitch = pitch;
                    directer.volume = volume;
                }
            }
            //Outside threshold x
            else if(tipPenLocalPosition.x < otherPointX - threshold)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointX - maxDistanceX, otherPointX, tipPenLocalPosition.x);
                float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            else if(tipPenLocalPosition.x > otherPointX + threshold)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointX + maxDistanceX, otherPointX, tipPenLocalPosition.x);
                float volume = Mathf.SmoothStep(1f, 0.5f, distanceRatio);
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            //Good State
            else
            {
                float volume = 0.3f;
                float pitch = 1f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
            //Too far Up
            if(tipPenLocalPosition.z > start.z)
            {
                float distanceRatio = Mathf.InverseLerp(otherPointZ + maxDistanceZ, otherPointZ, tipPenLocalPosition.z);
                float pitch = Mathf.SmoothStep(3f, 1.5f, distanceRatio);
                float volume = 0.3f;
                directer.pitch = pitch;
                directer.volume = volume;
            }
        }




    }*/

    public void letterStroke()
    {
        //Lowercase A
        if(letterArray == alphabet[1] && lineVector.Equals(letterArray[0]))
        {
            //Debug.Log("Works");
            straightUp.Play();
        }
        if(letterArray == alphabet[1] && lineVector.Equals(letterArray[1]))
        {
            circleLeftDown.Play();
        }

        //Lowercase B
         if(letterArray == alphabet[3] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[3] && lineVector.Equals(letterArray[1]))
        {
            circleRightUp.Play();
        }

        //Lowercase C
         if(letterArray == alphabet[5] && lineVector.Equals(letterArray[0]))
        {
            circleLeftDown.Play();
        }

        //Lowercase D
         if(letterArray == alphabet[7] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[7] && lineVector.Equals(letterArray[1]))
        {
            circleLeftUp.Play();
        }

        //Lowercase E
         if(letterArray == alphabet[9] && lineVector.Equals(letterArray[0]))
        {
            straightRight.Play();
        }
        if(letterArray == alphabet[9] && lineVector.Equals(letterArray[1]))
        {
            circleUpLeft.Play();
        }

        //Lowercase F
         if(letterArray == alphabet[11] && lineVector.Equals(letterArray[0]))
        {
            straightUp.Play();
        }
        if(letterArray == alphabet[11] && lineVector.Equals(letterArray[1]))
        {
            circleUpRight.Play();
        }
        if(letterArray == alphabet[11] && lineVector.Equals(letterArray[2]))
        {
            straightLeft.Play();
        }

        //Lowercase G
         if(letterArray == alphabet[13] && lineVector.Equals(letterArray[0]))
        {
            hookRight.Play();
        }
        if(letterArray == alphabet[13] && lineVector.Equals(letterArray[1]))
        {
            straightUp.Play();
        }
        if(letterArray == alphabet[13] && lineVector.Equals(letterArray[2]))
        {
            circleLeftDown.Play();
        }

        //Lowercase H
         if(letterArray == alphabet[15] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[15] && lineVector.Equals(letterArray[1]))
        {
            circleUpRight.Play();
        }

        //Lowercase I
         if(letterArray == alphabet[17] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[17] && lineVector.Equals(letterArray[1]))
        {
            straightDown.Play();
        }

        //Lowercase J
         if(letterArray == alphabet[19] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[19] && lineVector.Equals(letterArray[1]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[19] && lineVector.Equals(letterArray[2]))
        {
            hookLeft.Play();
        }

        //Lowercase K
         if(letterArray == alphabet[21] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[21] && lineVector.Equals(letterArray[1]))
        {
            straightUp.Play();
        }
        if(letterArray == alphabet[21] && lineVector.Equals(letterArray[2]))
        {
            straightUpRight.Play();
        }
        if(letterArray == alphabet[21] && lineVector.Equals(letterArray[3]))
        {
            straightDownLeft.Play();
        }
        if(letterArray == alphabet[21] && lineVector.Equals(letterArray[4]))
        {
            straightDownRight.Play();
        }

        //Lowercase L
         if(letterArray == alphabet[23] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }

        //Lowercase M
         if(letterArray == alphabet[25] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[25] && lineVector.Equals(letterArray[1]))
        {
            circleUpRight.Play();
        }
        if(letterArray == alphabet[25] && lineVector.Equals(letterArray[2]))
        {
            circleUpRight.Play();
        }

        //Lowercase N
         if(letterArray == alphabet[27] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[27] && lineVector.Equals(letterArray[1]))
        {
            circleUpRight.Play();
        }

        //Lowercase O
         if(letterArray == alphabet[29] && lineVector.Equals(letterArray[0]))
        {
            circleLeftDown.Play();
        }

        //Lowercase P
         if(letterArray == alphabet[31] && lineVector.Equals(letterArray[0]))
        {
            straightUp.Play();
        }
        if(letterArray == alphabet[31] && lineVector.Equals(letterArray[1]))
        {
            circleRightDown.Play();
        }

        //Lowercase Q
         if(letterArray == alphabet[33] && lineVector.Equals(letterArray[0]))
        {
            hookLeft.Play();
        }
        if(letterArray == alphabet[33] && lineVector.Equals(letterArray[1]))
        {
            straightUp.Play();
        }
        if(letterArray == alphabet[33] && lineVector.Equals(letterArray[2]))
        {
            circleLeftDown.Play();
        }

        //Lowercase R
         if(letterArray == alphabet[35] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[35] && lineVector.Equals(letterArray[1]))
        {
            straightUp.Play();
        }
        if(letterArray == alphabet[35] && lineVector.Equals(letterArray[2]))
        {
            circleUpRight.Play();
        }

        //Lowercase S
         if(letterArray == alphabet[37] && lineVector.Equals(letterArray[0]))
        {
            circleLeftDown.Play();
        }
        if(letterArray == alphabet[37] && lineVector.Equals(letterArray[1]))
        {
            straightDownRight.Play();
        }
        if(letterArray == alphabet[37] && lineVector.Equals(letterArray[2]))
        {
            circleLeftUp.Play();
        }

        //Lowercase T
         if(letterArray == alphabet[39] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[39] && lineVector.Equals(letterArray[1]))
        {
            straightRight.Play();
        }

        //Lowercase U
         if(letterArray == alphabet[41] && lineVector.Equals(letterArray[0]))
        {
            circleDownRight.Play();
        }
        if(letterArray == alphabet[41] && lineVector.Equals(letterArray[1]))
        {
            straightDown.Play();
        }

        //Lowercase V
         if(letterArray == alphabet[43] && lineVector.Equals(letterArray[0]))
        {
            straightDownRight.Play();
        }
        if(letterArray == alphabet[43] && lineVector.Equals(letterArray[1]))
        {
            straightUpRight.Play();
        }

        //Lowercase W
         if(letterArray == alphabet[45] && lineVector.Equals(letterArray[0]))
        {
            straightDownRight.Play();
        }
        if(letterArray == alphabet[45] && lineVector.Equals(letterArray[1]))
        {
            straightUpRight.Play();
        }
        if(letterArray == alphabet[45] && lineVector.Equals(letterArray[2]))
        {
            straightDownRight.Play();
        }
        if(letterArray == alphabet[45] && lineVector.Equals(letterArray[3]))
        {
            straightUpRight.Play();
        }

        //Lowercase X
         if(letterArray == alphabet[47] && lineVector.Equals(letterArray[0]))
        {
            straightDownRight.Play();
        }
        if(letterArray == alphabet[47] && lineVector.Equals(letterArray[1]))
        {
            straightDownLeft.Play();
        }

        //Lowercase Y
         if(letterArray == alphabet[49] && lineVector.Equals(letterArray[0]))
        {
            straightDownRight.Play();
        }
        if(letterArray == alphabet[49] && lineVector.Equals(letterArray[1]))
        {
            straightDownLeft.Play();
        }

        //Lowercase Z
         if(letterArray == alphabet[51] && lineVector.Equals(letterArray[0]))
        {
            straightRight.Play();
        }
        if(letterArray == alphabet[51] && lineVector.Equals(letterArray[1]))
        {
            straightDownLeft.Play();
        }
        if(letterArray == alphabet[51] && lineVector.Equals(letterArray[2]))
        {
            straightRight.Play();
        }

        if(letterArray == alphabet[53] && lineVector.Equals(letterArray[0]))
        {
            straightUp.Play();
        }
        if(letterArray == alphabet[55] && lineVector.Equals(letterArray[0]))
        {
            straightDown.Play();
        }
        if(letterArray == alphabet[57] && lineVector.Equals(letterArray[0]))
        {
            straightLeft.Play();
        }
        if(letterArray == alphabet[59] && lineVector.Equals(letterArray[0]))
        {
            straightRight.Play();
        }
        if(letterArray == alphabet[61] && lineVector.Equals(letterArray[0]))
        {
            straightDownRight.Play();
        }
        if(letterArray == alphabet[63] && lineVector.Equals(letterArray[0]))
        {
            straightDownLeft.Play();
        }
        if(letterArray == alphabet[65] && lineVector.Equals(letterArray[0]))
        {
            straightUpRight.Play();
        }
        if(letterArray == alphabet[67] && lineVector.Equals(letterArray[0]))
        {
            circleUpLeft.Play();
        }
        if(letterArray == alphabet[69] && lineVector.Equals(letterArray[0]))
        {
            circleUpRight.Play();
        }
        if(letterArray == alphabet[71] && lineVector.Equals(letterArray[0]))
        {
            circleDownRight.Play();
        }
        if(letterArray == alphabet[73] && lineVector.Equals(letterArray[0]))
        {
            circleLeftUp.Play();
        }
        if(letterArray == alphabet[75] && lineVector.Equals(letterArray[0]))
        {
            circleLeftDown.Play();
        }
        if(letterArray == alphabet[77] && lineVector.Equals(letterArray[0]))
        {
            circleRightUp.Play();
        }
        if(letterArray == alphabet[79] && lineVector.Equals(letterArray[0]))
        {
            circleRightDown.Play();
        }

    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        LineVector other = (LineVector)obj;
        return true;
    }

    IEnumerator PlayLetterStrokeAudioWithDelay(int corrections)
    {
        yield return new WaitForSeconds(corrections * 3); // Delay before playing the audio

  
        letterStroke();
        
        
    }   

    IEnumerator PlayLetterCompletedAudioWithDelay(int corrections)
    {
        yield return new WaitForSeconds(corrections * 3); // Delay before playing the audio

        
        letterCompleted.Play();
        
    }   

    IEnumerator PlayPickUpAudioWithDelay(int corrections)
    {
        yield return new WaitForSeconds(corrections * 3);
        pickUp.Play();
    }

    IEnumerator PlaySonificationWithDelay(int corrections, float furtherPointX, float furtherPointZ, Vector3 tipPenLocalPosition, Vector3 start, Vector3 end)
    {
        yield return new WaitForSeconds(corrections * 3 + 1); // Delay before playing the audio
        if(!directer.isPlaying)
        {
            if(isDone == false)
            {
                directer.Play();
            }
            
        }
        Sonification(furtherPointX, furtherPointZ, tipPenLocalPosition);
        //Sonification1(furtherPointX, furtherPointZ, tipPenLocalPosition, start, end);

    }   

    
    


}