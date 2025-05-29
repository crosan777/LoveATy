using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BachelorDisplay : MonoBehaviour
{
    public int index;
    public CharacterInfo[] CurrentCharacterInfo;
    public Image BachelorPortrait;
    public TMP_Text BachelorName;
    public TMP_Text BachelorAge;
    public TMP_Text BachelorDescription;

    public void Start()
    {
        DisplayBachelorInformation();
    }
    public void DisplayBachelorInformation()
    {
        BachelorPortrait.sprite = CurrentCharacterInfo[index].image;
        BachelorName.text = CurrentCharacterInfo[index].name;
        BachelorDescription.text = CurrentCharacterInfo[index].Description;
        BachelorAge.text = CurrentCharacterInfo[index].Age.ToString();
    }
    public void RightArrow()
    {
        index = (index + 1)%CurrentCharacterInfo.Length; //Formula to make the index be in the List length always
        DisplayBachelorInformation();
    }

    //Saber quin es en el matching
    public CharacterInfo GetCurrentBachelor()
    {
        return CurrentCharacterInfo[index];
    }
}
