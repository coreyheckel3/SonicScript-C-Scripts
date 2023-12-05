using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PenMovementRecorder : MonoBehaviour
{
    public Transform penTip; // Reference to the pen tip object

    private bool isRecording = false;
    private List<Vector2Int> penPositions = new List<Vector2Int>();
    private Texture2D drawnTexture;
    private int textureWidth = 34;
    private int textureHeight = 34;

    public Vector3 tipPenLocalPosition;

    private void Start()
    {
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
            Debug.Log("penPos" + penPos);
            Vector2Int pixelPos = WorldToTextureCoordinate(penPos);
            Debug.Log("pixelPos" + pixelPos);
            if (!penPositions.Contains(pixelPos))
            {
                penPositions.Add(pixelPos);
                Debug.Log("penPos" + penPos);
                Debug.Log("pixelPos" + pixelPos);
                Debug.Log("hi" + penPositions);
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

        // Save the generated image as a PNG file
        byte[] bytes = drawnTexture.EncodeToPNG();
        string filePath = Application.persistentDataPath + "/GeneratedImage.png";
        System.IO.File.WriteAllBytes(filePath, bytes);
        Application.OpenURL("file://" + filePath);
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