using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MagicPage : MonoBehaviour
{
    [SerializeField] private TMP_Text magicText1; 
    [SerializeField] private TMP_Text magicText2; 
    [SerializeField] private TMP_Text magicText3; 
    [SerializeField] private TMP_Text magicText4;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    public void ChangeMagicText(int characterIndex)
    {
        MagicList magicList = ConfigManager.getInstance().magicList;
        CharacterList characterList = ConfigManager.getInstance().characterList;

        string[] characterSkills = {
            characterList.characters[characterIndex].Skill1,
            characterList.characters[characterIndex].Skill2,
            characterList.characters[characterIndex].Skill3,
            characterList.characters[characterIndex].Skill4, 
        };

        TMP_Text[] magicTexts = { magicText1, magicText2, magicText3, magicText4 };

        for (int index = 0; index < magicTexts.Length; index++)
        {
            var magic = Array.Find(magicList.magics, magic => magic.No == characterSkills[index]);
            magicTexts[index].text = magic.Name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
