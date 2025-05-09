﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public BodyPartScript[] bodyParts;
    public BodyPartScript[] notCustomBodyParts;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
       
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
