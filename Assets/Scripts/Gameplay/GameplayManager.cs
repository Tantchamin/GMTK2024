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
    public Unit player;
    public EnemyManager enemyManager;
    public MagicPage magicPage;
    public CommandPage commandPage;
    ConfigManager configManager;
    Character playerConfig;

    void Start()
    {
        configManager = ConfigManager.getInstance();
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter");
        playerConfig = configManager.characterList.characters[characterIndex];
        player.Init(playerConfig);
        player.unitUi.ChangeCharacter(player);
        magicPage.ChangeMagicText(characterIndex);
        magicPage.Init(this);
        commandPage.Init(this);
        enemyManager.AddAllEnemy(playerConfig);
        enemyManager.RandomEnemy();

    }

    public void UpdatePhase(GamePhase phase)
    {
        Unit enemy = enemyManager.enemy;
        switch (phase)
        {
            case GamePhase.standby:
                player.IncreaseManaTurn();
                enemy.IncreaseManaTurn();
                break;
            case GamePhase.command:
                break;
            case GamePhase.playerAction:
                break;
            case GamePhase.enemyAction:
                break;
            case GamePhase.end:
                player.DecreaseAllBuff();
                enemy.DecreaseAllBuff();
                break;
        }
    }

}
