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
    public void ThirdScreenBachelorDisplay()
    {
        BachelorPortrait.sprite = CurrentCharacterInfo[index].image;
        BachelorName.text = CurrentCharacterInfo[index].Name;
        BachelorDescription.text = CurrentCharacterInfo[index].Description;
        BachelorAge.text = CurrentCharacterInfo[index].Age.ToString();

        //informa a RightScreen
        if (rightScreen != null)
        {
            rightScreen.UpdateBachelorName(CurrentCharacterInfo[index]);
        }
    }


    public void RightArrow()
    {
        index = (index + 1) % CurrentCharacterInfo.Length; //Formula to make the index be in the List length always
        Console.WriteLine(index);
        DisplayBachelorInformation();

        ThirdScreenBachelorDisplay();
    }
    public void LeftArrow()
    {
        
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
        DisplayBachelorInformation();
    }
    public void DisplayBachelorInformation()
    {
        BachelorPortrait.sprite = CurrentCharacterInfo[index].image;
        BachelorName.text = CurrentCharacterInfo[index].Name;
        BachelorDescription.text = CurrentCharacterInfo[index].Description;
        BachelorAge.text = CurrentCharacterInfo[index].Age.ToString();
    }
    //Saber quin es en el matching
    public CharacterInfo GetCurrentBachelor()
    {
        return CurrentCharacterInfo[index];
    }
    public void RemoveCurrentBachelor()
    {
        if (CurrentCharacterInfo.Length == 0) return;
        var tempList = new List<CharacterInfo>(CurrentCharacterInfo);
        tempList.RemoveAt(index);
        CurrentCharacterInfo = tempList.ToArray();


        if (CurrentCharacterInfo.Length == 0)
        {
            gameObject.SetActive(false); // No quedan más
            return;
        }

        if (index >= CurrentCharacterInfo.Length)
            index = 0;


        DisplayBachelorInformation();
        ThirdScreenBachelorDisplay();
    }
}
