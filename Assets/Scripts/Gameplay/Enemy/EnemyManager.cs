using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemy;
    public List<Character> enemyList;

    public void AddAllEnemy(Character playerConfig)
    {
        ConfigManager configManager = ConfigManager.getInstance();
        foreach (Character character in configManager.characterList.characters)
        {
            enemyList.Add(character);
        }
        enemyList.Remove(playerConfig);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
