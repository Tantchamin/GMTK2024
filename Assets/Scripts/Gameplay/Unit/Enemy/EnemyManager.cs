using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Unit enemy;
    public List<Character> enemyList;
    public UnitUi enemyUi;

    public void AddAllEnemy(Character playerConfig)
    {
        ConfigManager configManager = ConfigManager.getInstance();
        foreach (Character character in configManager.characterList.characters)
        {
            enemyList.Add(character);
        }
        enemyList.Remove(playerConfig);
    }

    public void RandomEnemy()
    {
        int index = Random.Range(0, enemyList.Count);
        ChangeEnemyCharacter(index);
        enemyList.RemoveAt(index);
    }

    public void ChangeEnemyCharacter(int index)
    {
        enemy.Init(enemyList[index]);
        enemyUi.ChangeCharacter(enemyList[index]);
    }
}
