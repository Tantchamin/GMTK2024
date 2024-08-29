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
