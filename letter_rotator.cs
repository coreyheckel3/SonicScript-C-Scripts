using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class letter_rotator : MonoBehaviour
{
    public GameObject parent;
    public int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        HideLetters();
        parent.transform.GetChild(1).gameObject.SetActive(true); // Assuming the first child is initially active
    }

    // Hides letter traces except the current letter
    public void HideLetters()
    {
        for (int index = 0; index < parent.transform.childCount; index++)
        {
            parent.transform.GetChild(index).gameObject.SetActive(false);
        }
    }

    // Sets the next letter active and the current letter inactive
    public void SetNextLetter()
    {
        i = (i + 2) % parent.transform.childCount;
        HideLetters();
        parent.transform.GetChild(i).gameObject.SetActive(true);
    }

    // Sets the previous letter active and the current letter inactive
    public void SetPrevLetter()
    {
        i = (i - 2 + parent.transform.childCount) % parent.transform.childCount;
        HideLetters();
        parent.transform.GetChild(i).gameObject.SetActive(true);
    }
}
