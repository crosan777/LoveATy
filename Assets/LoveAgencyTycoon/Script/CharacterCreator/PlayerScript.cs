﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public BodyPartScript[] bodyParts;
    public BodyPartScript[] notCustomBodyParts;


    //Variables del jugador
    public string playerName;
    public int playerAge;


    void Start()
    {
        GameObject rootObject = gameObject.transform.root.gameObject;
        DontDestroyOnLoad(rootObject);
    }



    void ChangeBodyPartSprite(int partIndex, int spriteIndex)
    {
        if(spriteIndex < bodyParts[partIndex].sprites.Length - 1)
        {
            spriteIndex = 0;
        }
        bodyParts[partIndex].UpdateSprite(spriteIndex);
    }

   
}
