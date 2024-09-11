using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    public string unitName;
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
    public Character characterConfig;
    public UnitUi unitUi;
    public List<Magic> unitMagics;
    public bool isMagicalForm = true;

    public void Init(Character character)
    {
        unitName = character.Name;
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

        string[] characterSkills = new string[] {
            skill1,
            skill2,
            skill3,
            skill4,
        };

        for (int index = 0; index < characterSkills.Length; index++)
        {
            MagicList magicList = ConfigManager.getInstance().magicList;
            Magic magic = Array.Find(magicList.magics, magic => magic.No == characterSkills[index]);
            unitMagics.Add(magic);
        }
    }

    public void HealthAdjust(int amount)
    {
        if (!isMagicalForm && amount < 0) amount *= 2; 
        health += amount;
        if (health > characterConfig.Health) health = characterConfig.Health;
        unitUi.statusBar.SetHealth(this);

        if(health <= 0)
        {
            Debug.Log("defeat");
        }
    }

    public void ManaAdjust(int amount)
    {
        mana += amount;
        if (mana > characterConfig.Mana) mana = characterConfig.Mana;
        unitUi.ChangeMana(this);
        unitUi.statusBar.SetMana(this);
    }

    public void IncreaseManaTurn()
    {
        if (mana < characterConfig.Mana)
        {
            mana += manaRegen;
            if (mana > characterConfig.Mana) mana = characterConfig.Mana;
            unitUi.statusBar.SetHealth(this);
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

    public void ChangeForm()
    {
        if (isMagicalForm)
        {

        }
        else
        {

        }
        isMagicalForm = !isMagicalForm;

    }

}
