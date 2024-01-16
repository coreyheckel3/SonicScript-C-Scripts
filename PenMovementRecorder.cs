using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PenMovementRecorder : MonoBehaviour
{
    public Transform penTip; // Reference to the pen tip object

    private bool isRecording = false;
    private List<Vector2Int> penPositions = new List<Vector2Int>();
    public Texture2D drawnTexture;
    private int textureWidth = 128;
    private int textureHeight = 128;

    public Vector3 tipPenLocalPosition;
    private TemplateMatching templateMatcher;

    private void Start()
    {
        templateMatcher = FindObjectOfType<TemplateMatching>();
        // Initialize the texture with a size of 28x28
        drawnTexture = new Texture2D(textureWidth, textureHeight);
        ClearTexture();
    }

    private void Update()
    {
        // Record the pen's position if recording is active
        if (isRecording)
        {
            tipPenLocalPosition = transform.InverseTransformPoint(penTip.transform.position);
            Vector2 penPos = new Vector2(tipPenLocalPosition.x, tipPenLocalPosition.z);
            //Debug.Log("penPos" + penPos);
            Vector2Int pixelPos = WorldToTextureCoordinate(penPos);
            //Debug.Log("pixelPos" + pixelPos);
            if (!penPositions.Contains(pixelPos))
            {
                penPositions.Add(pixelPos);
                //Debug.Log("penPos" + penPos);
                //Debug.Log("pixelPos" + pixelPos);
                //Debug.Log("hi" + penPositions);
            }
        }
    }

    public void StartRecording()
    {
        isRecording = true;
        penPositions.Clear(); // Clear previous recorded positions
    }

    public void StopRecording()
    {
        isRecording = false;
        GenerateAndSaveImage();
    }

    public void GenerateAndSaveImage()
    {
        ConvertToImage();
        templateMatcher.Match();
        // Save the generated image as a PNG file
        byte[] bytes = drawnTexture.EncodeToPNG();
        string folderPath = Application.persistentDataPath + "/GeneratedImages/"; // Create a folder path
        string filePath = folderPath + "GeneratedImage.png"; // Define the file path

        // Check if the folder exists, if not, create it
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Write the PNG file to the defined path
        System.IO.File.WriteAllBytes(filePath, bytes);
        Debug.Log("Image saved to: " + filePath);
}

    private void ConvertToImage()
    {
        foreach (Vector2Int pos in penPositions)
        {
            drawnTexture.SetPixel(pos.x, pos.y, Color.black);
        }

        drawnTexture.Apply();
    }

    public void ClearTexture()
    {
        Color[] clearColors = new Color[textureWidth * textureHeight];
        for (int i = 0; i < clearColors.Length; i++)
        {
            clearColors[i] = Color.white;
        }
        drawnTexture.SetPixels(clearColors);
        drawnTexture.Apply();
    }

private Vector2Int WorldToTextureCoordinate(Vector2 penPos)
{
    float minX = -0.34f;
    float maxX = 0.34f;
    float minZ = -0.34f;
    float maxZ = 0.34f;

    float mappedX = Mathf.InverseLerp(minX, maxX, penPos.x) * (textureWidth - 1);
    float mappedZ = Mathf.InverseLerp(minZ, maxZ, penPos.y) * (textureHeight - 1);

    int pixelX = Mathf.Clamp(Mathf.FloorToInt(mappedX), 0, textureWidth - 1);
    int pixelY = Mathf.Clamp(Mathf.FloorToInt(mappedZ), 0, textureHeight - 1);

    return new Vector2Int(pixelX, pixelY);
}
}