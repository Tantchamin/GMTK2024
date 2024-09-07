using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GamePhase
{
    standby,
    command,
    playerAction,
    enemyAction,
    end
}
public class GameplayManager : MonoBehaviour
{
    public int characterIndex;
    public Player player;
    public PlayerUi playerUi;
    public Enemy enemy;
    public MagicPage magicPage;
    public CommandPage commandPage;
    ConfigManager configManager;
    Character playerConfig;
    public List<Character> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        configManager = ConfigManager.getInstance();
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter");
        playerConfig = configManager.characterList.characters[characterIndex];
        playerUi.ChangeCharacter(characterIndex);
        player.Init(playerConfig);
        magicPage.ChangeMagicText(characterIndex);
        magicPage.Init(this);
        commandPage.Init(this);

        foreach(Character character in configManager.characterList.characters)
        {
            enemyList.Add(character);
        }
        enemyList.Remove(playerConfig);

    }

    public void UpdatePhase(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.standby:
                IncreaseManaTurn(player.mana, configManager.characterList.characters[characterIndex]);

                break;
            case GamePhase.command:
                break;
            case GamePhase.playerAction:
                break;
            case GamePhase.enemyAction:
                break;
            case GamePhase.end:
                DecreaseBuffTurn(player.buffAttack, player.buffAttackTurn);
                DecreaseBuffTurn(player.buffDefend, player.buffDefendTurn);
                DecreaseBuffTurn(enemy.buffAttack, enemy.buffAttackTurn);
                DecreaseBuffTurn(enemy.buffDefend, enemy.buffDefendTurn);
                break;
        }
    }

    void IncreaseManaTurn(int characterMana, Character characterConfig)
    {
        if (characterMana < characterConfig.Mana)
        {
            characterMana += characterConfig.ManaRegen;
            if (characterMana > characterConfig.Mana) characterMana = characterConfig.Mana;
        }
    }

    void DecreaseBuffTurn(int buffStatus, int buffTurn)
    {
        if (buffTurn > 0)
        {
            buffTurn--;
            if (buffTurn == 0) buffStatus = 0;
        }
    }
}
