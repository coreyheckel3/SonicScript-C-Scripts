using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateMatching : MonoBehaviour
{
    public Texture2D templateImage;
    public Texture2D inputImage;
    public TraceFeedback trace;
    public LineVector currentStroke;
    public LineVector lineVector;
    private PenMovementRecorder penRecorder;
    private letter_rotator letter;

    public AudioSource wideRight;
    public AudioSource wideLeft;
    public AudioSource wideUp;
    public AudioSource wideDown;
    public AudioSource widerRight;
    public AudioSource widerLeft;
    public AudioSource widerUp;
    public AudioSource widerDown;
    public AudioSource straightenBoth;
    public AudioSource straightenLeft;
    public AudioSource straightenRight;
    public AudioSource correctStroke;
    public AudioSource straightenUp;
    public AudioSource straightenDown;

    public float grayscaleThreshold = 0.6f; // Threshold to differentiate between black and white
    public int pixelThreshold = 100; // Threshold for pixel proximity
    public int proxThreshold = 5;

    public List<AudioSource> corrections;
    

   public void Match()
    {
        penRecorder = GetComponent<PenMovementRecorder>();
        currentStroke = trace.lineVector;
        inputImage = penRecorder.drawnTexture;
        GetTemplate();
        if(!templateImage)
        {
            Debug.Log("no template");
        }
        if(!inputImage)
        {
            Debug.Log("no input");
        }
        /*Debug.Log(templateImage.width);
        Debug.Log(inputImage.width);
        Debug.Log(templateImage.height);
        Debug.Log(inputImage.height);*/

        if (templateImage.width != inputImage.width || templateImage.height != inputImage.height)
        {
            Debug.LogError("Template and input images have different dimensions.");
            Debug.Log(templateImage.width);
            Debug.Log(inputImage.width);
            return;
        }
        // Convert texture data to arrays
        Color[] templatePixels = templateImage.GetPixels();
        Color[] inputPixels = inputImage.GetPixels();
        corrections = new List<AudioSource>();
        if(currentStroke.isCurved == false)
        {
             // Convert pixels to grayscale arrays
            float[] templateGrayscale = new float[templatePixels.Length];
            float[] inputGrayscale = new float[inputPixels.Length];

            // Create arrays for each row of pixels in the template
            List<List<int>> templateRowPixelIndices = new List<List<int>>();
            int templateWidth = templateImage.width;
            int templateHeight = templateImage.height;

            for (int y = 0; y < templateHeight; y++)
            {
                List<int> rowIndices = new List<int>();
                for (int x = 0; x < templateWidth; x++)
                {
                    int pixelIndex = y * templateWidth + x;
                    rowIndices.Add(pixelIndex);

                    templateGrayscale[pixelIndex] = templatePixels[pixelIndex].grayscale; 
                    inputGrayscale[pixelIndex] = inputPixels[pixelIndex].grayscale; 
                }
                templateRowPixelIndices.Add(rowIndices);
            }


            List<List<int>> templateColumnPixelIndices = new List<List<int>>();

            for (int x = 0; x < templateWidth; x++)
            {
                List<int> columnIndices = new List<int>();
                for (int y = 0; y < templateHeight; y++)
                {
                    int pixelIndex = y * templateWidth + x;
                    columnIndices.Add(pixelIndex);

                    templateGrayscale[pixelIndex] = templatePixels[pixelIndex].grayscale; 
                    inputGrayscale[pixelIndex] = inputPixels[pixelIndex].grayscale; 
                }
                templateColumnPixelIndices.Add(columnIndices);
            }
            if(currentStroke.isVertical == true || currentStroke.isDiagonal == true)
            {
                bool leftExceedThreshold = false;
                bool rightExceedThreshold = false;

                
                foreach (var rowIndices in templateRowPixelIndices)
                {
                    for (int i = 0; i < rowIndices.Count; i++)
                    {
                        int templatePixelIndex = rowIndices[i];

                        // Check if the template pixel is black
                        if (templateGrayscale[templatePixelIndex] < grayscaleThreshold)
                        {
                            // Check nearby pixels in the input within the threshold
                            for (int j = Mathf.Max(0, i - pixelThreshold); j < Mathf.Min(rowIndices.Count, i + pixelThreshold + 1); j++)
                            {
                                if (j != i)
                                {
                                    int inputPixelIndex = rowIndices[j];
                                    // Check if the input pixel is black and outside the threshold
                                    if (inputGrayscale[inputPixelIndex] < grayscaleThreshold)
                                    {
                                        
                                            if (j < i - proxThreshold) // To the left
                                            {
                                                leftExceedThreshold = true;
                                            }
                                            else if(j > i + proxThreshold)// To the right
                                            {
                                                rightExceedThreshold = true;
                                            }
                                        
                                    }
                                }
                            }
                        }
                    }
                }

                if (leftExceedThreshold && rightExceedThreshold)
                {
                    Debug.Log("Black pixels found exceeding the threshold on both sides.");
                    corrections.Add(straightenBoth);
                }
                else if (leftExceedThreshold)
                {
                    Debug.Log("Black pixels found exceeding the threshold to the left.");
                    corrections.Add(straightenRight);
                }
                else if (rightExceedThreshold)
                {
                    Debug.Log("Black pixels found exceeding the threshold to the right.");
                    corrections.Add(straightenLeft);
                }
                else
                {
                    Debug.Log("No black pixels found exceeding the threshold on either side.");
                    //corrections.Add(correctStroke);
                }
            }
            if(currentStroke.isHorizontal == true)
            {
                bool topExceedThreshold = false;
                bool bottomExceedThreshold = false;

                // Iterate through each column of the template to find matching pixels in the input
                foreach (var columnIndices in templateColumnPixelIndices)
                {
                    for (int i = 0; i < columnIndices.Count; i++)
                    {
                        int templatePixelIndex = columnIndices[i];

                        // Check if the template pixel is black
                        if (templateGrayscale[templatePixelIndex] < grayscaleThreshold)
                        {
                            // Check nearby pixels in the input within the threshold
                            for (int j = Mathf.Max(0, i - pixelThreshold); j < Mathf.Min(columnIndices.Count, i + pixelThreshold + 1); j++)
                            {
                                if (j != i)
                                {
                                    int inputPixelIndex = columnIndices[j];
                                    // Check if the input pixel is black and outside the threshold
                                    if (inputGrayscale[inputPixelIndex] < grayscaleThreshold)
                                    {
                                        if (j < i - proxThreshold) // Above
                                        {
                                            topExceedThreshold = true;
                                        }
                                        else if (j > i + proxThreshold) // Below
                                        {
                                            bottomExceedThreshold = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (topExceedThreshold && bottomExceedThreshold)
                {
                    Debug.Log("Black pixels found exceeding the threshold both above and below.");
                    corrections.Add(straightenBoth);
                }
                else if (topExceedThreshold)
                {
                    Debug.Log("Black pixels found exceeding the threshold above.");
                    corrections.Add(straightenDown);
                }
                else if (bottomExceedThreshold)
                {
                    Debug.Log("Black pixels found exceeding the threshold below.");
                    corrections.Add(straightenUp);
                }
                else
                {
                    Debug.Log("No black pixels found exceeding the threshold either above or below.");
                    //corrections.Add(correctStroke);
                }
            }

            
        }
        if(currentStroke.isCurved == true)
        {
            int templateWidth = templateImage.width;
            int templateHeight = templateImage.height;

            // Find the farthest left, up, and down pixel indices in the entire template image
            int farthestLeftIndex = FindFarthestLeftPixelIndex(templatePixels, templateWidth, templateHeight);
            int farthestRightIndex = FindFarthestRightPixelIndex(templatePixels, templateWidth, templateHeight);
            int farthestUpIndex = FindFarthestUpPixelIndex(templatePixels, templateWidth, templateHeight);
            int farthestDownIndex = FindFarthestDownPixelIndex(templatePixels, templateWidth, templateHeight);


            // Similarly, find the farthest left, up, and down pixel indices in the entire input image
            int farthestLeftInputIndex = FindFarthestLeftPixelIndex(inputPixels, templateWidth, templateHeight);
            int farthestRightInputIndex = FindFarthestRightPixelIndex(inputPixels, templateWidth, templateHeight);
            int farthestUpInputIndex = FindFarthestUpPixelIndex(inputPixels, templateWidth, templateHeight);
            int farthestDownInputIndex = FindFarthestDownPixelIndex(inputPixels, templateWidth, templateHeight);

            if(currentStroke.openRight == true)
            {
                if(farthestLeftInputIndex > farthestLeftIndex + proxThreshold)
                {
                    Debug.Log("Circle needs to be wider to the left");
                    corrections.Add(widerLeft);
                }
                if(farthestLeftInputIndex < farthestLeftIndex - proxThreshold)
                {
                    Debug.Log("Circle is too wide to the left");
                    corrections.Add(wideLeft);
                }
                if(farthestDownInputIndex > farthestDownIndex + proxThreshold)
                {
                    Debug.Log("Circle needs to be wider downwards");
                    corrections.Add(widerDown);
                }
                if(farthestDownInputIndex < farthestDownIndex - proxThreshold)
                {
                    Debug.Log("Circle is too wide downwards");
                    corrections.Add(wideDown);
                }
                if(farthestUpInputIndex > farthestUpIndex + proxThreshold)
                {
                    Debug.Log("Circle is too wide upwards");
                    corrections.Add(wideUp);
                }
                if(farthestUpInputIndex < farthestUpIndex - proxThreshold)
                {
                    Debug.Log("Circle needs to be wider upwards");
                    corrections.Add(widerUp);
                }
            }
            if(currentStroke.openLeft == true)
            {
                if(farthestRightInputIndex < farthestRightIndex + proxThreshold)
                {
                    Debug.Log("Circle needs to be wider to the right");
                    corrections.Add(widerRight);
                }
                if(farthestRightInputIndex > farthestRightIndex - proxThreshold)
                {
                    Debug.Log("Circle is too wide to the right");
                    corrections.Add(wideRight);
                }
                if(farthestDownInputIndex > farthestDownIndex + proxThreshold)
                {
                    Debug.Log("Circle needs to be wider downwards");
                    corrections.Add(widerDown);
                }
                if(farthestDownInputIndex < farthestDownIndex - proxThreshold)
                {
                    Debug.Log("Circle is too wide downwards");
                    corrections.Add(wideDown);
                }
                if(farthestUpInputIndex > farthestUpIndex + proxThreshold)
                {
                    Debug.Log("Circle is too wide upwards");
                    corrections.Add(wideUp);
                }
                if(farthestUpInputIndex < farthestUpIndex - proxThreshold)
                {
                    Debug.Log("Circle needs to be wider upwards");
                    corrections.Add(widerUp);
                }
            }
            if(currentStroke.openDown == true)
            {
                if(farthestLeftInputIndex > farthestLeftIndex + proxThreshold)
                {
                    Debug.Log("Circle needs to be wider to the left");
                    corrections.Add(widerLeft);
                }
                if(farthestLeftInputIndex < farthestLeftIndex - proxThreshold)
                {
                    Debug.Log("Circle is too wide to the left");
                    corrections.Add(wideLeft);
                }
                if(farthestUpInputIndex > farthestUpIndex + proxThreshold)
                {
                    Debug.Log("Circle is too wide upwards");
                    corrections.Add(wideUp);
                }
                if(farthestUpInputIndex < farthestUpIndex - proxThreshold)
                {
                    Debug.Log("Circle needs to be wider upwards");
                    corrections.Add(widerUp);
                }
                if(farthestRightInputIndex < farthestRightIndex + proxThreshold)
                {
                    Debug.Log("Circle needs to be wider to the right");
                    corrections.Add(widerRight);
                }
                if(farthestRightInputIndex > farthestRightIndex - proxThreshold)
                {
                    Debug.Log("Circle is too wide to the right");
                    corrections.Add(wideRight);
                }
            }
            if(currentStroke.openUp == true)
            {
                if(farthestLeftInputIndex > farthestLeftIndex + proxThreshold)
                {
                    Debug.Log("Circle needs to be wider to the left");
                    corrections.Add(widerLeft);
                }
                if(farthestLeftInputIndex < farthestLeftIndex - proxThreshold)
                {
                    Debug.Log("Circle is too wide to the left");
                    corrections.Add(wideLeft);
                }
                if(farthestDownInputIndex > farthestDownIndex + proxThreshold)
                {
                    Debug.Log("Circle needs to be wider downwards");
                    corrections.Add(widerDown);
                }
                if(farthestDownInputIndex < farthestDownIndex - proxThreshold)
                {
                    Debug.Log("Circle is too wide downwards");
                    corrections.Add(wideDown);
                }
                if(farthestRightInputIndex < farthestRightIndex + proxThreshold)
                {
                    Debug.Log("Circle needs to be wider to the right");
                    corrections.Add(widerRight);
                }
                if(farthestRightInputIndex > farthestRightIndex - proxThreshold)
                {
                    Debug.Log("Circle is too wide to the right");
                    corrections.Add(wideRight);
                }
            }

        }
        StartCoroutine(PlayAudioWithDelay(corrections));
  
    }

    IEnumerator PlayAudioWithDelay(List<AudioSource> audioList)
    {
        foreach (var audio in audioList)
        {
            audio.Play();
            yield return new WaitForSeconds(3.0f); 
        }
    }

    int FindFarthestLeftPixelIndex(Color[] pixels, int width, int height)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int pixelIndex = y * width + x;
                if (pixels[pixelIndex].grayscale < grayscaleThreshold)
                {
                    return x; // Return the column index where the farthest left black pixel is found
                }
            }
        }

        return -1; // No black pixels found in the image
    }

    int FindFarthestUpPixelIndex(Color[] pixels, int width, int height)
    {

        for (int y = height - 1; y >= 0; y--)
        {
            for (int x = 0; x < width; x++)
            {
                int pixelIndex = y * width + x;
                if (pixels[pixelIndex].grayscale < grayscaleThreshold)
                {
                    return y; // Return the row index where the farthest down black pixel is found
                }
            }
        }

        return -1; // No black pixels found in the image
    }
    int FindFarthestRightPixelIndex(Color[] pixels, int width, int height)
    {
        for (int x = width - 1; x >= 0; x--)
        {
            for (int y = 0; y < height; y++)
            {
                int pixelIndex = y * width + x;
                if (pixels[pixelIndex].grayscale < grayscaleThreshold)
                {
                    return x; // Return the column index where the farthest right black pixel is found
                }
            }
        }

        return -1; // No black pixels found in the image
    }

    int FindFarthestDownPixelIndex(Color[] pixels, int width, int height)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int pixelIndex = y * width + x;
                if (pixels[pixelIndex].grayscale < grayscaleThreshold)
                {
                    return y; // Return the row index where the farthest up black pixel is found
                }
            }
        }

        return -1; // No black pixels found in the image
    }
    public void GetTemplate()
    {
        trace = GetComponent<TraceFeedback>();
        letter = GetComponent<letter_rotator>();
        //Debug.Log("lowA0: " + lowA0);
        //Debug.Log("trace: " + trace.lineVector);
       // Debug.Log("Stroke: "+ trace.stroke);

       //a
        if (letter.i == 1)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowA0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowA1");
            }
        }
        //b
        if (letter.i == 3)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowB0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowB1");
            }
        }
        //c
        if (letter.i == 5)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowC0");
            }
        }
        //d
        if (letter.i == 7)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowD0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowD1");
            }
        }
        //e
        if (letter.i == 9)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowE0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowE1");
            }
        }
        //f
        if (letter.i == 11)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowF0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowF1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowF2");
            }
        }
        //g
        if (letter.i == 13)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowG0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowG1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowG2");
            }
        }
        //h
        if (letter.i == 15)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowH0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowH1");
            }
        }
        //i
        if (letter.i == 17)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowI0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowI1");
            }
        }
        //j
        if (letter.i == 19)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowJ0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowJ1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowJ2");
            }
        }
        //k
        if (letter.i == 21)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowK0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowK1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowK2");
            }
            if(trace.stroke == 3)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowK3");
            }
            if(trace.stroke == 4)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowK4");
            }
        }
        //l
        if (letter.i == 23)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowL0");
            }
        }
        //m
        if (letter.i == 25)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowM0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowM1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowM2");
            }
        }
        //n
        if (letter.i == 27)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowN0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowN1");
            }
        }
        //o
        if (letter.i == 29)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowO0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowO1");
            }
        }
        //p
        if (letter.i == 31)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowP0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowP1");
            }
        }
        //q
        if (letter.i == 33)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowQ0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowQ1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowQ2");
            }
        }
        //r
        if (letter.i == 35)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowR0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowR1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowR2");
            }
        }
        //s
        if (letter.i == 37)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowS0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowS1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowS2");
            }
        }
        //t
        if (letter.i == 39)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowT0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowT1");
            }
        }
        //u
        if (letter.i == 41)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowU0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowU1");
            }
        }
        //v
        if (letter.i == 43)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowV0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowV1");
            }
        }
        //w
        if (letter.i == 45)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowW0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowW1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowW2");
            }
            if(trace.stroke == 3)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowW3");
            }
        }
        //x
         if (letter.i == 47)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowX0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowX1");
            }
        }
        //y
         if (letter.i == 49)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowY0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowY1");
            }
        }
        //z
         if (letter.i == 51)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowZ0");
            }
            if(trace.stroke == 1)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowZ1");
            }
            if(trace.stroke == 2)
            {
                templateImage = Resources.Load<Texture2D>("Templates/lowZ2");
            }
        }
        if (letter.i == 53)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/vlup");
            }
        }
        if (letter.i == 55)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/vldown");
            }
        }
        if (letter.i == 57)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/hlleft");
            }
        }
        if (letter.i == 59)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/hlright");
            }
        }
        if (letter.i == 61)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/dltlbr");
            }
        }
        if (letter.i == 63)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/dltrbl");
            }
        }
        if (letter.i == 65)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/dlbltr");
            }
        }
        if (letter.i == 67)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/sctl");
            }
        }
        if (letter.i == 69)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/sctr");
            }
        }
        if (letter.i == 71)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/scbr");
            }
        }
        if (letter.i == 73)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/sclup");
            }
        }
        if (letter.i == 75)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/scldown");
            }
        }
        if (letter.i == 77)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/scrup");
            }
        }
        if (letter.i == 79)
        {
            if(trace.stroke == 0)
            {
                templateImage = Resources.Load<Texture2D>("Templates/scrdown");
            }
        }
        
    }   

}

