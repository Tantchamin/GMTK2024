using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UnitUi : MonoBehaviour
{
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text characterManaText;
    [SerializeField] private Image character;
    public StatusBar statusBar;

    public void ChangeMana(Unit unit)
    {
        statusBar.SetMana(unit);
        characterManaText.text = $"{unit.mana}";
    }

    public void ChangeCharacter(Unit unit)
    {
        characterNameText.text = unit.unitName;
        characterManaText.text = unit.mana.ToString();
        statusBar.SetMaxHealth(unit);
        statusBar.SetMaxMana(unit);
        Sprite characterImage = FindCharacterImage(unit.unitName, unit.isMagicalForm);
        character.sprite = characterImage;
    }

    public void ChangeCharacterForm(Unit unit)
    {
        Sprite characterImage = FindCharacterImage(unit.unitName, unit.isMagicalForm);
        character.sprite = characterImage;
    }

    Sprite FindCharacterImage(string unitName, bool isMagicalForm)
    {
        ConfigManager configManager = ConfigManager.getInstance();
        string findName = isMagicalForm ? $"{unitName} Transform" : $"{unitName} Normal";
        Sprite characterSprite = Array.Find(configManager.characterSprites, characterSprite => characterSprite.name == findName);
        return characterSprite;
    }
}
