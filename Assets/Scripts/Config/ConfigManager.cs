using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    MagicList magicList;
    CharacterList characterList;

    private static ConfigManager instance;

    public static ConfigManager getInstance()
    {
        return ConfigManager.instance;
    }

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        if (!ConfigManager.instance)
        {
            DontDestroyOnLoad(gameObject);
            ConfigManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        //// Load the JSON file
        //TextAsset magicFile = Resources.Load<TextAsset>("Magics");
        //string magicJson = magicFile.text;

        //// Deserialize the JSON into the MagicList class
        //magicList = JsonUtility.FromJson<MagicList>(magicJson);


        //// Load the JSON file
        //TextAsset characterFile = Resources.Load<TextAsset>("Magics");
        //string characterJson = characterFile.text;

        //// Deserialize the JSON into the MagicList class
        //characterList = JsonUtility.FromJson<CharacterList>(characterJson);

        // Load and deserialize MagicList from JSON
        magicList = LoadJsonFile<MagicList>("Magics");

        // Load and deserialize CharacterList from JSON
        characterList = LoadJsonFile<CharacterList>("Characters");

        for(int i =0; i <characterList.characters.Length; i++)
        {
            Debug.Log(characterList.characters[i].Name);
        }

    }
    
    private T LoadJsonFile<T>(string fileName)
    {
        TextAsset file = Resources.Load<TextAsset>(fileName);
        return JsonUtility.FromJson<T>(file.text);
    }
}
