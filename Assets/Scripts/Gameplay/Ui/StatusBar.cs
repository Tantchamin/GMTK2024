using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider manaSlider;
    public Unit unit;

    public void SetMaxHealth()
    {
        healthSlider.maxValue = unit.characterConfig.Health;
        healthSlider.value = unit.health;
    }

    public void SetHealth()
    {
        healthSlider.value = unit.health;
    }

    public void SetMaxMana()
    {
        manaSlider.maxValue = unit.characterConfig.Mana;
        manaSlider.value = unit.mana;
    }

    public void SetMana()
    {
        manaSlider.value = unit.mana;
    }
}
