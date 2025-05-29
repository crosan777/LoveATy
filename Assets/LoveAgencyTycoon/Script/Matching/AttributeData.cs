using UnityEngine;
using System.Collections;
using HUD;

public class AttributeData : MonoBehaviour
{

    public int social;
    public int metodologia;
    public int romance;
    public int tradicion;
    public int actividad;

    

    public int GetMatchingAttributes(AttributeData other)
    {
        int matchCount = 0;
        if (this.social == other.social) matchCount++;
        if (this.metodologia == other.metodologia) matchCount++;
        if (this.romance == other.romance) matchCount++;
        if (this.tradicion == other.tradicion) matchCount++;
        if (this.actividad == other.actividad) matchCount++;
        return matchCount;
    }

    
}

