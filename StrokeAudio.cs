using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeAudio : MonoBehaviour
{
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
    public AudioSource paperDetected;
    public AudioSource paperNotDetected;
    public AudioSource penDetected;
    public AudioSource penNotDetected;

    private AudioSource[] strokes;
    
    void Start()
    {
        strokes = new AudioSource[16];
        strokes[0] = straightUp;
        strokes[1] = circleLeftDown;
        strokes[2] = straightDown;
        strokes[3] = circleRightUp;
        strokes[4] = circleLeftUp;
        strokes[5] = circleUpLeft;
        strokes[6] = circleUpRight;
        strokes[7] = straightLeft;
        strokes[8] = hookRight;
        strokes[9] = straightUpRight;
        strokes[10] = straightDownLeft;
        strokes[11] = straightDownRight;
        strokes[12] = circleRightDown;
        strokes[13] = circleDownRight;
        strokes[14] = straightRight;
        strokes[15] = hookLeft;
    }

    public void PlayStroke(int index)
    {
         if (strokes == null)
    {
        Debug.LogWarning("strokes array is null");
        return;
    }
        if (index >= 0 && index < strokes.Length)
        {
            strokes[index].Play();
        }
        else
        {
            Debug.LogWarning("Invalid stroke index");
        }
    }

    public void PlayPaperDetected()
    {
        paperDetected.Play();
    }

    public void PlayPaperNotDetected()
    {
        paperNotDetected.Play();
    }

    public void PlayPenDetected()
    {
        penDetected.Play();
    }

    public void PlayPenNotDetected()
    {
        penNotDetected.Play();
    }

    
}
