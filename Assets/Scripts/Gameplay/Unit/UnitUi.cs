using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUi : MonoBehaviour
{
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text characterManaText;
    [SerializeField] private Image character;
    public StatusBar statusBar;

    public void ChangeMana(Unit unit)
    {
        characterManaText.text = $"{unit.mana}";
    }

    public void ChangeCharacter(Unit unit)
    {
        characterNameText.text = unit.unitName;
        characterManaText.text = unit.mana.ToString();
        statusBar.SetMaxHealth(unit);
        statusBar.SetMaxMana(unit);
    }

}
