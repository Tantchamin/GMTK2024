[System.Serializable]
public class Magic
{
    public string No;
    public string Name;
    public string Type;
    public string MagicVisual;
    public int Damage;
    public int Shield;
    public int Heal;
    public int Accuracy;
    public int BuffAttack;
    public int BuffDefense;
    public int BuffTurn;
    public int RegenMana;
    public int ManaCost;
    public string Description;
}

[System.Serializable]
public class MagicList
{
    public Magic[] magics;
}

[System.Serializable]
public class Character
{
    public string No;
    public string Name;
    public string Type;
    public string MagicVisual;
    public int Health;
    public int Mana;
    public int ManaRegen;
    public int Attack;
    public int Defense;
    public int Shield;
    public string Skill1;
    public string Skill2;
    public string Skill3;
    public string Skill4;
}

[System.Serializable]
public class CharacterList
{
    public Character[] characters;
}
