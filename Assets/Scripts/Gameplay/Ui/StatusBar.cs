using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider manaSlider;

    public void SetMaxHealth(Unit unit)
    {
        healthSlider.maxValue = unit.characterConfig.Health;
        healthSlider.value = unit.health;
    }

    public void SetHealth(Unit unit)
    {
        healthSlider.value = unit.health;
    }

    public void SetMaxMana(Unit unit)
    {
        manaSlider.maxValue = unit.characterConfig.Mana;
        manaSlider.value = unit.mana;
    }

    public void SetMana(Unit unit)
    {
        manaSlider.value = unit.mana;
    }
}
