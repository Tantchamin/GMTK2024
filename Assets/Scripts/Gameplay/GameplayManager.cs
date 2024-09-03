using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public int characterIndex;

    // Start is called before the first frame update
    void Start()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter");    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
