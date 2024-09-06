using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandPage : MonoBehaviour
{
    [SerializeField] private GameObject[] commandPages;

    public void ChangePage(int index)
    {
        for (int pageNumber = 0; pageNumber < commandPages.Length; pageNumber++)
        {
            commandPages[pageNumber].SetActive(pageNumber == index);
        } 
    }
}
