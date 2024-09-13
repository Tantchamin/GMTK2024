using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandPage : MonoBehaviour
{
    [SerializeField] private GameplayManager gameplayManager;
    [SerializeField] private GameObject[] commandPages;
    [SerializeField] private Button[] commandButtons;
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
        defendText.text = $"Reduce the damage from enemy attack";
    }

    public void UseAttack()
    {
        gameplayManager.CommandAttack();
        gameplayManager.UpdatePhase(GamePhase.playerAction);
    }

    public void UseDefend()
    {
        gameplayManager.CommandDefend();
        gameplayManager.UpdatePhase(GamePhase.playerAction);
    }


    public void UseChangeForm()
    {
        Unit player = gameplayManager.player;
        //player.ChangeForm();
    }

}
