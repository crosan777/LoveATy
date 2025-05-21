using UnityEngine;

public class PortraitGenerator : MonoBehaviour
{
    public PlayerScript playerScript;
    public BodyPartScript bodyPartScript;

    private string[] bodyPartNames;
    private int partIndex = 0;

    public void RandomPlayerSprites() 
    {
        int orgPartIndex = partIndex;
        int len = playerScript.bodyParts.Length - 1;
        int rndSpriteIndex;

        for (int i = 0; i < len; i++)
        {
            rndSpriteIndex = UnityEngine.Random.Range(0, playerScript.bodyParts[i].GetSpritesLength());
            playerScript.bodyParts[i].UpdateSprite(rndSpriteIndex);
            partIndex = i;

        }


        partIndex = orgPartIndex;
    }

    public void ChangeCurrentPartColor(Color32 newColor)
    {
        string partTag = playerScript.bodyParts[partIndex].tag;
        GameObject[] allParts = GameObject.FindGameObjectsWithTag(partTag);
        foreach (GameObject part in allParts)
        {
            part.GetComponent<BodyPartScript>().UpdateSpriteColor(newColor);
        }

    }

}
