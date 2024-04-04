using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVLogger : MonoBehaviour
{
    private string filePath;
    private List<string[]> rowData = new List<string[]>();

    private PenMovementRecorder penMovement;

    private TraceFeedback traceFeedback;
    private TemplateMatching templateMatcher;

    

    void Start()
    {
        penMovement = FindObjectOfType<PenMovementRecorder>();
        traceFeedback = FindObjectOfType<TraceFeedback>();
        templateMatcher = FindObjectOfType<TemplateMatching>();
    
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        filePath = Application.persistentDataPath + $"/log_{timestamp}.csv";

        File.WriteAllText(filePath, "");

        AddRow("Timestamp", "Letter", "Stroke", "Position_X", "Position_Y", "Position_Z", "Pitch", "Volume", "IsRecording", "Corrections");
    }

     void Update()
    {
        LogValues(DateTime.Now.ToString(), traceFeedback.currentInt.i.ToString(), traceFeedback.stroke.ToString(), penMovement.tipPenLocalPosition.x.ToString(), penMovement.tipPenLocalPosition.y.ToString(), penMovement.tipPenLocalPosition.z.ToString(),
                  traceFeedback.directer.pitch.ToString(), traceFeedback.directer.volume.ToString(), penMovement.isRecording.ToString(), templateMatcher.corrections);
    }

    void LogValues(string timestamp, string letter, string stroke, string posX, string posY, string posZ, string pitch, string volume, string isRecording, List<AudioSource> corrections)
    {
        string audioSourceInfo = "";
        foreach (var audioSource in corrections)
        {
            string sourceInfo = $"{audioSource.clip.name}";
            audioSourceInfo += sourceInfo;
        }
        AddRow(timestamp, letter, stroke, posX, posY, posZ, pitch, volume, isRecording, audioSourceInfo);
        Save();
    }

    void AddRow(params string[] values)
    {
        rowData.Add(values);
    }

    void Save()
    {
        string[][] output = new string[rowData.Count][];
        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(",", output[index]));

        File.AppendAllText(filePath, sb.ToString());

        rowData.Clear();
    }
}