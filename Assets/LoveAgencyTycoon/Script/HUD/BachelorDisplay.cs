using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class BachelorDisplay : MonoBehaviour
{
    public int index;
    public CharacterInfo[] CurrentCharacterInfo;
    public Image BachelorPortrait;
    public TMP_Text BachelorName;
    public TMP_Text BachelorAge;
    public TMP_Text BachelorDescription;

    public RightScreen rightScreen;

    public void DisplayBachelorInformation()
    {
        var character = CurrentCharacterInfo[index];
        if (character == null)
        {
            Debug.LogError("CharacterInfo en índice " + index + " es null");
            return;
        }
        if (BachelorPortrait == null) Debug.LogError("BachelorPortrait no está asignado");
        if (BachelorName == null) Debug.LogError("BachelorName no está asignado");
        if (BachelorDescription == null) Debug.LogError("BachelorDescription no está asignado");
        if (BachelorAge == null) Debug.LogError("BachelorAge no está asignado");

        BachelorPortrait.sprite = character.image;
        BachelorName.text = character.Name;
        BachelorDescription.text = character.Description;
        BachelorAge.text = character.Age.ToString();
    }

    public void ThirdScreenBachelorDisplay()
    {
        if (CurrentCharacterInfo == null || CurrentCharacterInfo.Length == 0 || index < 0 || index >= CurrentCharacterInfo.Length)
            return;

      
        BachelorName.text = CurrentCharacterInfo[index].Name;


        if (rightScreen != null)
        {
            rightScreen.UpdateBachelorName(CurrentCharacterInfo[index]);
        }
    }


    public void RightArrow()
    {
        if (CurrentCharacterInfo == null || CurrentCharacterInfo.Length == 0) return;

        index = (index + 1) % CurrentCharacterInfo.Length; 
        Console.WriteLine(index);
        DisplayBachelorInformation();

        ThirdScreenBachelorDisplay();
    }
    public void LeftArrow()
    {
        if (CurrentCharacterInfo == null || CurrentCharacterInfo.Length == 0) return;

        if (index == 0 )
        {
            index = CurrentCharacterInfo.Length -1;
        }
        else index = (index - 1); 
        DisplayBachelorInformation();

        ThirdScreenBachelorDisplay();
    }

    public void Start()
    {
        if (CurrentCharacterInfo != null && CurrentCharacterInfo.Length > 0)
        {
            DisplayBachelorInformation();
            ThirdScreenBachelorDisplay(); 
        }
    }

    //Saber quin es en el matching
    public CharacterInfo GetCurrentBachelor()
    {
        if (CurrentCharacterInfo == null || CurrentCharacterInfo.Length == 0 || index < 0 || index >= CurrentCharacterInfo.Length)
            return null;

        return CurrentCharacterInfo[index];
    }

    public void RemoveCurrentBachelor()
    {
        if (CurrentCharacterInfo.Length == 0) return;
        if (index >= CurrentCharacterInfo.Length)
            index = 0;
        var tempList = new List<CharacterInfo>(CurrentCharacterInfo);
        tempList.RemoveAt(index);
        CurrentCharacterInfo = tempList.ToArray();


        if (CurrentCharacterInfo.Length == 0)
        {
            gameObject.SetActive(false); // no mas
            return;
        }

        if (index >= CurrentCharacterInfo.Length)
            index = 0;


        DisplayBachelorInformation();
        ThirdScreenBachelorDisplay();
    }
}
