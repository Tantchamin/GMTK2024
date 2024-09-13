using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MagicPage : MonoBehaviour
{
    [SerializeField] private GameObject magicButtonPage;
    [SerializeField] private TMP_Text magicText1; 
    [SerializeField] private TMP_Text magicText2; 
    [SerializeField] private TMP_Text magicText3; 
    [SerializeField] private TMP_Text magicText4;
    [SerializeField] private GameObject statusPage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text shieldText;
    [SerializeField] private TMP_Text healText;
    [SerializeField] private TMP_Text accuracyText;
    [SerializeField] private TMP_Text buffAttackText;
    [SerializeField] private TMP_Text buffDefendText;
    [SerializeField] private TMP_Text buffTurnText;
    [SerializeField] private TMP_Text regenManaText;
    [SerializeField] private TMP_Text manaCostText;
    [SerializeField] private Button castButton;
    private GameplayManager gameplayManager;
    private string[] characterSkills;
    public Magic selectedMagic;

    public void Init(GameplayManager gameplayManager)
    {
        this.gameplayManager = gameplayManager;
        ChangeMagicText(gameplayManager.characterIndex);
    }

    public void ChangeMagicText(int characterIndex)
    {
        MagicList magicList = ConfigManager.getInstance().magicList;
        Unit player = gameplayManager.player;

        characterSkills = new string[] {
            player.skill1,
            player.skill2,
            player.skill3,
            player.skill4, 
        };

        TMP_Text[] magicTexts = { magicText1, magicText2, magicText3, magicText4 };

        for (int index = 0; index < magicTexts.Length; index++)
        {
            Magic magic = Array.Find(magicList.magics, magic => magic.No == characterSkills[index]);
            magicTexts[index].text = magic.Name;
        }
    }

    public void SelectMagic(int index)
    {
        MagicList magicList = ConfigManager.getInstance().magicList;
        Magic magic = Array.Find(magicList.magics, magic => magic.No == characterSkills[index]);

        magicButtonPage.SetActive(false);
        statusPage.SetActive(true);

        nameText.text = $"{magic.Name} : \"{magic.Description}\"";
        damageText.text = $"Damage: {magic.Damage + gameplayManager.player.attack + gameplayManager.player.buffAttack}";
        shieldText.text = $"Shield: {magic.Shield}";
        healText.text = $"Heal: {magic.Heal}";
        accuracyText.text = $"Accuracy: {magic.Accuracy}";
        buffAttackText.text = $"Buff atk: {magic.BuffAttack}";
        buffDefendText.text = $"Buff def: {magic.BuffDefense}";
        buffTurnText.text = $"Buff turn: {magic.BuffTurn}";
        regenManaText.text = $"Regenerate mana: {magic.RegenMana}";
        manaCostText.text = $"Mana cost: {magic.ManaCost}";

        castButton.interactable = gameplayManager.player.mana >= magic.ManaCost;
        selectedMagic = magic;
    }

    public void CancelMagic()
    {
        magicButtonPage.SetActive(true);
        statusPage.SetActive(false);
    }

    public void UseMagic()
    {
        gameplayManager.CommandMagic(selectedMagic);
        CancelMagic();
    }

}
