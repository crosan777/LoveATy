using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChSceneControllerScript : MonoBehaviour
{
    public Button randomBtn;
    public Button submitBtn;
    public GameObject bodyPartBtn;
    public Button leftArrowBtn;
    public Button rightArrowBtn;
    public ColorControllerScript colorScript;

    public PlayerScript playerScript;

    private string[] bodyPartNames;
    private int partIndex = 0;

    void Start()
    {
        bodyPartNames = GetPlayerBodyPartNames();
        
        RandomPlayerSprites();

        randomBtn.onClick.AddListener(() => RandomPlayerSprites());
        submitBtn.onClick.AddListener(() => SubmitClickedLoadNextScene());

        leftArrowBtn.onClick.AddListener(() => ArrowClicked(1));
        rightArrowBtn.onClick.AddListener(() => ArrowClicked(-1));
        

        bodyPartBtn.GetComponent<Button>().onClick.AddListener(() => ChangeBodyPartClicked());

        ArrowClicked(0);
    }

    void RandomPlayerSprites()
    {
        int orgPartIndex = partIndex;
        int len = playerScript.bodyParts.Length - 1;
        int rndSpriteIndex;

        for (int i = 0; i < len; i++)
        {
            rndSpriteIndex = UnityEngine.Random.Range(0, playerScript.bodyParts[i].GetSpritesLength());
            playerScript.bodyParts[i].UpdateSprite(rndSpriteIndex);
            partIndex = i;
            RandomizePartColor(playerScript.bodyParts[i].tag);

        }

      
        partIndex = orgPartIndex;
    }

    void RandomizePartColor(String partTag)
    {

        String[] hexColors = colorScript.GetHexDefaultColors(); ;
        switch (partTag)
        {  
            case "Skin":
                hexColors = colorScript.GetHexSkinColors();
                break;
            case "Hair":
                hexColors = colorScript.GetHexHairColors();
                break;
            case "Shirt":
                hexColors = colorScript.GetHexShirtColors();
                break;
            default:
                break;
        }
        String strColor = hexColors[UnityEngine.Random.Range(0, hexColors.Length)];
        ColorUtility.TryParseHtmlString(strColor, out Color color);
        ChangeCurrentPartColor(color);
    }


    void MatchSprites(string tagName)
    {
        GameObject[] sameItem = GameObject.FindGameObjectsWithTag(tagName);
        int index = sameItem[0].GetComponent<BodyPartScript>().GetSpriteIndex();
        sameItem[1].GetComponent<BodyPartScript>().UpdateSprite(index);
    }

    void BodyButtonClicked()
    {
        Debug.Log(playerScript.bodyParts[0].gameObject.name);
    }

    void ArrowClicked(int num)
    {
        partIndex += num;
        if (partIndex > bodyPartNames.Length - 1)
        {
            partIndex = 0;
        }
        else if (partIndex < 0)
        {
            partIndex = bodyPartNames.Length - 1;
        }
        bodyPartBtn.transform.GetChild(0).gameObject.GetComponent<Text>().text = bodyPartNames[partIndex];
        CheckColorButtonOptions();
    }

    void ChangeBodyPartClicked()
    {
        playerScript.bodyParts[partIndex].UpdateToNextSprite();
    }

    void CheckColorButtonOptions()
    {
        if (playerScript.bodyParts[partIndex].CompareTag("Skin"))
        {
            colorScript.ChangeButtonColors(colorScript.GetHexSkinColors());
        }
        else if (playerScript.bodyParts[partIndex].CompareTag("Hair"))
        {
            colorScript.ChangeButtonColors(colorScript.GetHexHairColors());
        }
        else if (playerScript.bodyParts[partIndex].CompareTag("Shirt"))
        {
            colorScript.ChangeButtonColors(colorScript.GetHexShirtColors());
        }
        else
        {
            colorScript.ChangeButtonColors(colorScript.GetHexDefaultColors());
        }
    }

    private string[] GetPlayerBodyPartNames()
    {
        int i = 0;
        string[] allNames = new string[playerScript.bodyParts.Length];
        foreach (BodyPartScript partScript in playerScript.bodyParts)
        {           
            allNames[i] = partScript.gameObject.name;
            i++;
        }
        return allNames;
    }


    public void ChangeCurrentPartColor(Color32 newColor)
    {
        String partTag = playerScript.bodyParts[partIndex].tag;
        if (partTag == "Skin" || partTag == "Leg" || partTag == "Foot" || partTag == "Sleeve")
        {
            GameObject[] allParts = GameObject.FindGameObjectsWithTag(partTag);
            foreach (GameObject part in allParts)
            {
                part.GetComponent<BodyPartScript>().UpdateSpriteColor(newColor);
            }
        }
        else
        {
            playerScript.bodyParts[partIndex].UpdateSpriteColor(newColor);
        }
    }

    

    private void SubmitClickedLoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        playerScript.ChangePlayerScale(0.3f);
    }
}
