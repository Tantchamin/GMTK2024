using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public int characterIndex;
    public PlayerUi playerUi;
    public MagicPage magicPage;

    // Start is called before the first frame update
    void Start()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter");
        playerUi.ChangeCharacter(characterIndex);
        magicPage.ChangeMagicText(characterIndex);
        magicPage.init(this);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
