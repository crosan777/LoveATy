using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartController : MonoBehaviour
{
    [Serializable]
    private struct Part
    {
        public string name;
        public Sprite sprite;
    }


    private List<Part> parts = new List<Part>();
    private int index = 0;
    SpriteRenderer sr;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        if (parts.Count > 0)
        {
            sr.sprite = parts[index].sprite;
        }
    }

    public void SetBodyPart(string name, Sprite sprite)
    {
        Part newPart = new Part;
        {
            name = name,
            sprite = sprite 

        };
        parts.Add(newPart);
    }

    public void NextPart()
    {
        if (parts.Count == 0) return;
        index = (index + 1) % parts.Count;
        sr.sprite = parts[index].sprite;
    }

    public void PreviousPart()
    {
        if (parts.Count == 0) return;
        index = (index - 1 + parts.Count) % parts.Count;
        sr.sprite = parts[index].sprite;
    }

    public void UpdateSpriteColor(Color32 newColor)
    {
        sr.color = newColor;
    }

}
