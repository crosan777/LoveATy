using UnityEngine;
using System.Collections;

public class NewMonoBehaviour : MonoBehaviour
{
    public static float CalculateCompatibility(CharacterInfo a, CharacterInfo b)
    {
        float total = 0f;
        total += 1f - Mathf.Abs(a.Social - b.Social) / 100f;
        total += 1f - Mathf.Abs(a.Metodologia - b.Metodologia) / 100f;
        total += 1f - Mathf.Abs(a.Romance - b.Romance) / 100f;
        total += 1f - Mathf.Abs(a.Tradicion - b.Tradicion) / 100f;
        total += 1f - Mathf.Abs(a.Actividad - b.Actividad) / 100f;

        return total / 5f; // compatibilidad entre 0 y 1
    }
}

