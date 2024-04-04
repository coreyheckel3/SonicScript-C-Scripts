/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateVisualizer : MonoBehaviour
{
    public LineVector lineVector;
    public bool visualizeTemplate = true;

    private Texture2D generatedTexture;
    private int textureWidth = 100;
    private int textureHeight = 100;

    private void Start()
    {
        generatedTexture = new Texture2D(textureWidth, textureHeight);
        GenerateAndSaveTemplate();
    }

   private void GenerateAndSaveTemplate()
{
    List<Vector3> interpolatedPoints = LetterTemplates.GetLowFInterpolatedCoordinates();

    foreach (Vector3 point in interpolatedPoints)
    {
        DrawToTexture(point);
    }

    SaveTextureAsImage();
}

private void DrawToTexture(Vector3 point)
{
    Vector2Int pixelPos = WorldToTextureCoordinate(new Vector2(point.x, point.z));

    if (pixelPos.x >= 0 && pixelPos.x < textureWidth && pixelPos.y >= 0 && pixelPos.y < textureHeight)
    {
        generatedTexture.SetPixel(pixelPos.x, pixelPos.y, Color.black);
    }
}

    private void SaveTextureAsImage()
    {
        byte[] bytes = generatedTexture.EncodeToPNG();
        string filePath = Application.persistentDataPath + "/GeneratedImage.png";
        System.IO.File.WriteAllBytes(filePath, bytes);
        Application.OpenURL("file://" + filePath);
        Debug.Log("Saved image to: " + filePath);
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
}*/