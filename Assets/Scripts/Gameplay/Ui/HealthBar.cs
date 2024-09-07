using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
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
}
