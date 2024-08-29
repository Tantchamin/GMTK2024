using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MagicLoader : MonoBehaviour
{
    public Magic[] characterMagics;  // Array to store 4 selected magics

    void Start()
    {
        // Load the JSON file
        TextAsset jsonFile = Resources.Load<TextAsset>("Magics");
        string jsonString = jsonFile.text;

        // Deserialize the JSON into the MagicList class
        MagicList magicList = JsonUtility.FromJson<MagicList>(jsonString);

        // Select the first 4 magics from the list for the character
        characterMagics = new Magic[4];
        for (int i = 0; i < 4; i++)
        {
            characterMagics[i] = magicList.magics[i]; // Choose the first four or select as needed
        }

        // For debugging, print the selected magics' names
        foreach (var magic in characterMagics)
        {
            Debug.Log("Selected Magic: " + magic.Name);
        }
    }
}
