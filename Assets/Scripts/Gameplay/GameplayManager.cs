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
    public bool isMagic = false, isAttack = false, isDefense = false;
    public Magic selectedMagic;

    void Start()
    {
        configManager = ConfigManager.getInstance();
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter");
        playerConfig = configManager.characterList.characters[characterIndex];
        player.Init(playerConfig);
        player.unitUi.ChangeCharacter(player);
        magicPage.Init(this);
        commandPage.Init(this);
        enemyManager.AddAllEnemy(playerConfig);
        enemyManager.RandomEnemy();

    }

    public void CommandAttack()
    {
        enemyManager.enemy.HealthAdjust(-player.attack + player.buffAttack);
    }

    public void CommandDefend()
    {
        isDefense = true;
    }

    public void SetCommand()
    {

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
                if(isAttack)
                {

                }
                else if(isMagic)
                {

                }
                UpdatePhase(GamePhase.enemyAction);
                break;
            case GamePhase.enemyAction:
                UpdatePhase(GamePhase.end);
                break;
            case GamePhase.end:
                player.DecreaseAllBuff();
                enemy.DecreaseAllBuff();
                isAttack = false;
                isMagic = false;
                isDefense = false;
                UpdatePhase(GamePhase.standby);
                break;
        }
    }

}
