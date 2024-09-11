using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool isMagic = false, isAttack = false, isDefense = false, isEnemyAttack = false, isEnemyMagic;
    public Magic selectedMagic, selectedEnemyMagic;

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
        isAttack = true;
    }

    public void CommandDefend()
    {
        isDefense = true;
    }

    public void CommandMagic(Magic magic)
    {
        selectedMagic = magic;
        isMagic = true;
        UpdatePhase(GamePhase.playerAction);
    }

    void UseMagic(Unit user, Unit target)
    {
        int successChance = Random.Range(1, 100);
        if (successChance > selectedMagic.Accuracy) return;
        user.HealthAdjust(selectedMagic.Heal);
        target.HealthAdjust(-(selectedMagic.Damage + user.attack + user.buffAttack));
        user.ManaAdjust(-(selectedMagic.ManaCost + selectedMagic.RegenMana));
        user.shield += selectedMagic.Shield;
        if (selectedMagic.BuffAttack != 0)
        {
            user.buffAttack = selectedMagic.BuffAttack;
            user.buffAttackTurn = selectedMagic.BuffTurn;
        }
        if (selectedMagic.BuffDefense != 0)
        {
            user.buffDefend = selectedMagic.BuffDefense;
            user.buffDefendTurn = selectedMagic.BuffTurn;
        }
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
                UpdatePhase(GamePhase.command);
                break;
            case GamePhase.command:
                RandomEnemyCommand(enemy);
                break;
            case GamePhase.playerAction:
                if(isAttack)
                {
                    enemy.HealthAdjust(-player.attack + player.buffAttack);
                }
                else if(isMagic)
                {
                    UseMagic(player, enemy);
                }
                UpdatePhase(GamePhase.enemyAction);
                break;
            case GamePhase.enemyAction:
                Debug.Log("enemy phase");
                UpdatePhase(GamePhase.end);
                break;
            case GamePhase.end:
                player.DecreaseAllBuff();
                enemy.DecreaseAllBuff();
                isAttack = false;
                isMagic = false;
                isDefense = false;
                isEnemyAttack = false;
                isEnemyMagic = false;
                UpdatePhase(GamePhase.standby);
                break;
        }
    }

    void RandomEnemyCommand(Unit enemy)
    {
        List<Magic> usableEnemyMagics = new();
        foreach (Magic enemyMagic in enemy.unitMagics)
        {
            if (enemy.mana >= enemyMagic.ManaCost)
            {
                usableEnemyMagics.Add(enemyMagic);
            }
        }
        int randomCommand = Random.Range(0, 2);
        if (usableEnemyMagics.Count == 0) randomCommand = 0;
        if (randomCommand == 0)
        {
            isEnemyAttack = true;
        }
        else if (randomCommand == 1)
        {
            int randomMagic = Random.Range(0, usableEnemyMagics.Count);
            selectedEnemyMagic = usableEnemyMagics[randomMagic];
            isEnemyMagic = true;
        }
    }

}
