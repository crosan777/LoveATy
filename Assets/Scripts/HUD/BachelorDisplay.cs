using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BachelorDisplay : MonoBehaviour
{
    public CharacterInfo CurrentCharacterInfo;

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
        BachelorPortrait.sprite = CurrentCharacterInfo.image;
        BachelorName.text = CurrentCharacterInfo.name;
        BachelorDescription.text = CurrentCharacterInfo.Description;
        BachelorAge.text = CurrentCharacterInfo.Age.ToString();
    }

}
