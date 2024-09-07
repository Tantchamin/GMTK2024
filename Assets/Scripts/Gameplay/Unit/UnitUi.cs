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

    public void ChangeCharacter(Character character)
    {
        characterNameText.text = character.Name;
        characterManaText.text = character.Mana.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
