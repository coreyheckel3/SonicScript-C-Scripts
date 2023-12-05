/*using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using UnityEngine;

public class SpeechRecognition : MonoBehaviour
{
    public string[] keywords = new string[] { "lowercase a", "lowercase b", "lowercase c", "lowercase d" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;

    public LineVector[][] alphabet;
    public LineVector[] letterArray;

    //public Text results;
    //public Image target;
    public TraceFeedback feedback;
    public letter_rotator rotator;
    public int i;

    protected PhraseRecognizer recognizer;
    protected string word = "lowercase a";
    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            Debug.Log( recognizer.IsRunning );
        }

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        //results.text = "You said: <b>" + word + "</b>";
    }

    // Update is called once per frame
    void Update()
    {
        switch (word)
        {
            case "lowercase a":
            rotator.parent.transform.GetChild(i).gameObject.SetActive(false);
            i = 1;
            rotator.parent.transform.GetChild(i).gameObject.SetActive(true);
            feedback.letterArray = feedback.alphabet[1];
            feedback.lineVector = feedback.letterArray[0];
            feedback.lineVector = feedback.LowA[0];
            break;

            case "lowercase b":
            rotator.parent.transform.GetChild(i).gameObject.SetActive(false);
            i = 3;
            rotator.parent.transform.GetChild(i).gameObject.SetActive(true);
            feedback.letterArray = feedback.alphabet[3];
            feedback.lineVector = feedback.letterArray[0];
            feedback.lineVector = feedback.LowB[0];
            break;

 
        }
        
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
*/