using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public MagicList magicList;
    public CharacterList characterList;

    private static ConfigManager instance;

    public static ConfigManager getInstance()
    {
        return ConfigManager.instance;
    }

    private void Awake()
    {
        Init();
        LoadResource();

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

    void LoadResource()
    {
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
