using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    private int index = 0;
    [SerializeField] private TMP_Text characterName;

    void Start()
    {
        CharacterList characterList = ConfigManager.getInstance().characterList;
        characterName.text = characterList.characters[0].Name;
    }

    public void ChangeCharacter(bool isNext)
    {
        CharacterList characterList = ConfigManager.getInstance().characterList;
        int totalCharacters = characterList.characters.Length;

        if (isNext)
        {
            index = (index + 1) % totalCharacters;
        }
        else
        {
            index = (index - 1 + totalCharacters) % totalCharacters;
        }

        characterName.text = characterList.characters[index].Name;
    }

    public void Select()
    {
        PlayerPrefs.SetInt("SelectedCharacter", index);
        SceneManager.LoadScene(2);
    }
}
