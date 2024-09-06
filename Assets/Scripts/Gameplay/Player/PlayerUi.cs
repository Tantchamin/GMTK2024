using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private TMP_Text playerManaText;
    [SerializeField] private Image playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeCharacter(int characterIndex)
    {
        CharacterList characterList = ConfigManager.getInstance().characterList;
        playerNameText.text = characterList.characters[characterIndex].Name;
        playerManaText.text = characterList.characters[characterIndex].Mana.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
