using UnityEngine;
using System.Collections;

public class CalculateCompatibility : MonoBehaviour
{
    public static float Calculate(CharacterInfo a, CharacterInfo b)
    {
            float total = 0f;
            total += 1f - Mathf.Abs(a.Social - b.Social) / 100f;
            total += 1f - Mathf.Abs(a.Methodology - b.Methodology) / 100f;
            total += 1f - Mathf.Abs(a.Relationship - b.Relationship) / 100f;
            total += 1f - Mathf.Abs(a.Tradition - b.Tradition) / 100f;
            total += 1f - Mathf.Abs(a.Activity - b.Activity) / 100f;

            return total / 5f; 
    }
    


}

