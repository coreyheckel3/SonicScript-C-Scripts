using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Vuforia;

public class Starter : MonoBehaviour
{
    public letter_rotator letter;
    public TraceFeedback traceFeedback;

    public DefaultObserverEventHandler target1Observer;
    public DefaultObserverEventHandler target2Observer;
    int[] center = {1,5,9,27,29,35,37,41,43,47,51,53,55,57,59,61,63,65,67,69,71,73,75,77,79};
    int[] up = {3,7,15,17,19,21,23,39,49};
    int[] down = {11,13,31};
    int[] left = {25,45};
    int right = 33;
    

    float paperHeight = 0f;
    float heightThresh = 0.02f;
    //Bounding Box for center of paper
    float centerUp = 0.2f;
    float centerDown = -0.2f;
    float centerLeft = -0.2f;
    float centerRight = 0.2f;
    //Bounding Box for up portion of paper
    float upUp = 0.38f;
    float upDown = -0.02f;
    float upLeft = -0.2f;
    float upRight = 0.2f;
    //Bounding Box for down portion of paper
    float downUp = 0.04f;
    float downDown = -0.36f;
    float downLeft = -0.2f;
    float downRight = 0.2f;
    //Bounding Box for left portion of paper
    float leftUp = 0.2f;
    float leftDown = -0.2f;
    float leftLeft = -0.4f;
    float leftRight = 0f;
    //Bounding Box for right portion of paper
    float rightUp = 0.04f;
    float rightDown = -0.36f;
    float rightLeft = -0.07f;
    float rightRight = 0.33f;


    //Bias for point translation
    public float biasX = 0f;
    public float biasZ = 0f;
    public bool biasFound = false;

    // Start is called before the first frame update
    void Start()
    {
        traceFeedback = FindObjectOfType<TraceFeedback>();
        letter = FindObjectOfType<letter_rotator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        bool target1Tracked = IsTrackedOrExtendedTracked(target1Observer.mPreviousTargetStatus);
        bool target2Tracked = IsTrackedOrExtendedTracked(target2Observer.mPreviousTargetStatus);

        if (target1Tracked && target2Tracked && biasFound == false)
        {
            
            if(checkPenDown(traceFeedback.tipPenLocalPosition))
            {
                
                if(center.Contains(letter.i))
                {
                    if(checkBoundingBox(traceFeedback.tipPenLocalPosition, centerUp, centerDown, centerLeft, centerRight))
                    {
                        calculateBias(traceFeedback.tipPenLocalPosition, traceFeedback.lineVector.startPoint);

                        letter.parent.transform.GetChild(letter.i).gameObject.SetActive(true);
                        Vector3 newPosition = new Vector3(
                        letter.parent.transform.GetChild(letter.i).localPosition.x + biasX,
                        0.01f,
                        letter.parent.transform.GetChild(letter.i).localPosition.z + biasZ
                        );
                        
                        letter.parent.transform.GetChild(letter.i).localPosition = newPosition;
                        
                    }
                }
                else if(up.Contains(letter.i))
                {
                    Debug.Log("YES");
                    if(checkBoundingBox(traceFeedback.tipPenLocalPosition, upUp, upDown, upLeft, upRight))
                    {
                        calculateBias(traceFeedback.tipPenLocalPosition, traceFeedback.lineVector.startPoint);
                        letter.parent.transform.GetChild(letter.i).gameObject.SetActive(true);
                        Vector3 newPosition = new Vector3(
                        letter.parent.transform.GetChild(letter.i).localPosition.x + biasX,
                        0.01f,
                        letter.parent.transform.GetChild(letter.i).localPosition.z + biasZ
                        );
                        
                        letter.parent.transform.GetChild(letter.i).localPosition = newPosition;
                    }
                }
                else if(down.Contains(letter.i))
                {
                    if(checkBoundingBox(traceFeedback.tipPenLocalPosition, downUp, downDown, downLeft, downRight))
                    {
                        calculateBias(traceFeedback.tipPenLocalPosition, traceFeedback.lineVector.startPoint);
                        letter.parent.transform.GetChild(letter.i).gameObject.SetActive(true);
                        Vector3 newPosition = new Vector3(
                        letter.parent.transform.GetChild(letter.i).localPosition.x + biasX,
                        0.01f,
                        letter.parent.transform.GetChild(letter.i).localPosition.z + biasZ
                        );
                        
                        letter.parent.transform.GetChild(letter.i).localPosition = newPosition;
                    }
                }
                else if(left.Contains(letter.i))
                {
                    if(checkBoundingBox(traceFeedback.tipPenLocalPosition, leftUp, leftDown, leftLeft, leftRight))
                    {
                        calculateBias(traceFeedback.tipPenLocalPosition, traceFeedback.lineVector.startPoint);
                        letter.parent.transform.GetChild(letter.i).gameObject.SetActive(true);
                        Vector3 newPosition = new Vector3(
                        letter.parent.transform.GetChild(letter.i).localPosition.x + biasX,
                        0.01f,
                        letter.parent.transform.GetChild(letter.i).localPosition.z + biasZ
                        );
                        
                        letter.parent.transform.GetChild(letter.i).localPosition = newPosition;
                    }
                }
                else if(letter.i == right)
                {
                    if(checkBoundingBox(traceFeedback.tipPenLocalPosition, rightUp, rightDown, rightLeft, rightRight))
                    {
                        calculateBias(traceFeedback.tipPenLocalPosition, traceFeedback.lineVector.startPoint);
                        letter.parent.transform.GetChild(letter.i).gameObject.SetActive(true);
                        Vector3 newPosition = new Vector3(
                        letter.parent.transform.GetChild(letter.i).localPosition.x + biasX,
                        0.01f,
                        letter.parent.transform.GetChild(letter.i).localPosition.z + biasZ
                        );
                        
                        letter.parent.transform.GetChild(letter.i).localPosition = newPosition;
                    }
                }
            }
        
        }
        }

        


    public bool checkPenDown(Vector3 penPos)
    {
        if(penPos.y >= paperHeight - heightThresh && penPos.y <= paperHeight + heightThresh)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkBoundingBox(Vector3 penPos, float up, float down, float left, float right)
    {
        if(penPos.x >= left && penPos.x <= right && penPos.z >= down && penPos.z <= up)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void calculateBias(Vector3 penPos, Vector3 startPoint)
    {
        biasX = penPos.x - startPoint.x;
        biasZ = penPos.z - startPoint.z;
        biasFound = true;
        Debug.Log("DONE");
    }

    bool IsTrackedOrExtendedTracked(TargetStatus targetStatus)
    {
        return targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED;
    }
}
