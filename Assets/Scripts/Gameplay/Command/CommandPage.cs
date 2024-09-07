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

    public void Init(GameplayManager gameplayManager)
    {
        this.gameplayManager = gameplayManager;
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
        Unit player = gameplayManager.player;
        attackText.text = $"Damage: {player.attack + player.buffAttack}";
    }

    public void SelectDefend()
    {
        Unit player = gameplayManager.player;
        defendText.text = $"Defend: {player.defense + player.buffDefend} damage";
    }

    public void UseAttack()
    {

    }

    public void UseDefend()
    {

    }

}
