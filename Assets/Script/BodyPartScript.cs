using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartScript : MonoBehaviour
{
    
    [Serializable]
    public struct Sprites
    {
        
        public Sprite down;
        
    }

    public Sprites[] sprites;
    int index = 0;

    private void Start()
    {
        if (sprites.Length > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index].down;
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} has no sprites assigned!");
        }
    }

    public void UpdateSprite(int newIndex)
    {
        index = newIndex;
        if (sprites.Length > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index].down;
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} has no sprites assigned!");
        }
    }

    public int GetSpritesLength()
    {
        return sprites.Length;
    }

    public int GetSpriteIndex()
    {
        return index;
    }

    public void UpdateToNextSprite()
    {
        if (++index > sprites.Length - 1) index = 0;
        if (sprites.Length > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index].down;
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} has no sprites assigned!");
        }
    }

    public void UpdateSpriteColor(Color32 newColor)
    {
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }

    
}
