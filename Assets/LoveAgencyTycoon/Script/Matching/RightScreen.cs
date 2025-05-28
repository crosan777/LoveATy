using UnityEngine;
using UnityEngine.UI;

public class RightScreen: MonoBehaviour
{
    public BachelorManager bachelorManager; 
    public MenuSeleccionCandidato menuSeleccion;
    public CompatibilityCalculator calculator;

    public Text bachelorStatsText;
    public Text candidateStatsText;
    public Image compatibilityWheel;

    public void ShowComparison(CharacterInfo candidate)
    {
        var bachelor = bachelorManager.GetCurrentBachelor();

        if (bachelor == null || candidate == null) return;

        var bachelorAttr = bachelor.attributes;
        var candidateAttr = candidate.attributes;

        bachelorStatsText.text = FormatAttributes(bachelorAttr);
        candidateStatsText.text = FormatAttributes(candidateAttr);

        float compatibility = calculator.CalculateCompatibility(bachelorAttr, candidateAttr);
        UpdateCompatibilityWheel(compatibility);
    }

    private string FormatAttributes(AttributeData attr)
    {
        return $"Social: {attr.social}\nMetodología: {attr.metodologia}\nRomance: {attr.romance}\nTradición: {attr.tradicion}\nActividad: {attr.actividad}";
    }

    private void UpdateCompatibilityWheel(float value)
    {
        compatibilityWheel.fillAmount = value;
        compatibilityWheel.color = Color.Lerp(Color.red, Color.green, value);
    }
}

