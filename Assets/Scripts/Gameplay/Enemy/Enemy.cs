using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int health;
    public int mana;
    public int manaRegen;
    public int attack;
    public int defense;
    public int shield;
    public string skill1;
    public string skill2;
    public string skill3;
    public string skill4;
    public int buffAttack;
    public int buffDefend;
    public int buffAttackTurn;
    public int buffDefendTurn;
    Character characterConfig;

    public void Init(Character character)
    {
        enemyName = character.Name;
        health = character.Health;
        mana = character.Mana;
        manaRegen = character.ManaRegen;
        attack = character.Attack;
        defense = character.Defense;
        shield = character.Shield;
        skill1 = character.Skill1;
        skill2 = character.Skill2;
        skill3 = character.Skill3;
        skill4 = character.Skill4;
        buffAttack = character.BuffAttack;
        buffDefend = character.BuffDefend;
        buffAttackTurn = character.BuffAttackTurn;
        buffDefendTurn = character.BuffDefendTurn;
        characterConfig = character;
    }

    public void IncreaseManaTurn()
    {
        if (mana < characterConfig.Mana)
        {
            mana += manaRegen;
            if (mana > characterConfig.Mana) mana = characterConfig.Mana;
        }
    }

    public void DecreaseAllBuff()
    {
        DecreaseBuff(buffAttack, buffAttackTurn);
        DecreaseBuff(buffDefend, buffDefendTurn);
    }

    void DecreaseBuff(int buffStatus, int buffTurn)
    {
        if (buffTurn > 0)
        {
            buffTurn--;
            if (buffTurn == 0) buffStatus = 0;
        }
    }
}
