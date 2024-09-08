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
    [SerializeField] private StatusBar statusBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeCharacter(Unit unit)
    {
        characterNameText.text = unit.unitName;
        characterManaText.text = unit.mana.ToString();
        statusBar.SetMaxHealth(unit);
        statusBar.SetMaxMana(unit);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
