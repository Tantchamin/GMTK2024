using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public MagicList magicList;
    public CharacterList characterList;
    public Sprite[] characterSprites;

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

        // Load all sprites from the "Sprites" folder inside the Resources folder
        characterSprites = Resources.LoadAll<Sprite>("Sprites/Characters");

    }
    
    private T LoadJsonFile<T>(string fileName)
    {
        TextAsset file = Resources.Load<TextAsset>(fileName);
        return JsonUtility.FromJson<T>(file.text);
    }
}
