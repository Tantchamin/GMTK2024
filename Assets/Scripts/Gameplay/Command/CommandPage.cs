using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandPage : MonoBehaviour
{
    [SerializeField] private GameplayManager gameplayManager;
    [SerializeField] private GameObject[] commandPages;
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text defendText;
    private CharacterList characterList;
    private Character character;

    public void Init(GameplayManager gameplayManager)
    {
        this.gameplayManager = gameplayManager;
        characterList = ConfigManager.getInstance().characterList;
        character = characterList.characters[gameplayManager.characterIndex];
    }

    public void ChangePage(int index)
    {
        if (index == 0)
        {
            SelectAttack();
        }
        else if (index == 2)
        {
            SelectDefend();
        }

        for (int pageNumber = 0; pageNumber < commandPages.Length; pageNumber++)
        {
            commandPages[pageNumber].SetActive(pageNumber == index);
        } 
    }

    public void SelectAttack()
    {
        Player player = gameplayManager.player;
        attackText.text = $"Damage: {player.attack + player.buffAttack}";
    }

    public void SelectDefend()
    {
        Player player = gameplayManager.player;
        defendText.text = $"Defend: {player.defense + player.buffDefend} damage";
    }

    public void UseAttack()
    {

    }

    public void UseDefend()
    {

    }

}
