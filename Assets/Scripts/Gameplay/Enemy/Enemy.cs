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
    }
}
