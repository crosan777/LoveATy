using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RightScreen : MonoBehaviour
{

    //float compatibility = CompatibilityCalculator.Calculate(currentBachelor, selectedCandidate);

    public BachelorDisplay bachelorDisplay;
    //public SelectedCandidate menuSelect;
    public CandidateDisplayUI candidateDisplay;


    public Image bachelorImageUI;
    public Image candidateImageUI;
    public Image compatibilityWheel;



    private CharacterInfo currentBachelor;
    private CharacterInfo selectedCandidate;

    // boton MATCH
    public void OnMatchButtonPressed()
    {
        currentBachelor = bachelorDisplay.GetCurrentBachelor();
        //selectedCandidate = menuSelect.selectedCandidate;

        if (currentBachelor == null || selectedCandidate == null) return;

        ShowPortraits();
        ShowCompatibility();
    }

    private void ShowPortraits()
    {
        bachelorImageUI.sprite = currentBachelor.image;
        candidateImageUI.sprite = selectedCandidate.image;
    }

    private void ShowCompatibility()
    {
        float compatibility = CalculateCompatibility(currentBachelor, selectedCandidate);

        compatibilityWheel.fillAmount = compatibility;
        compatibilityWheel.color = Color.Lerp(Color.red, Color.green, compatibility);
        // ahora lo hace instantaneo despues le añadimos alguna animacion
    }

    private float CalculateCompatibility(CharacterInfo a, CharacterInfo b)
    {
        int matches = 0;

        if (a.Social == b.Social)
            matches++;

        if (a.Methodology == b.Methodology)
            matches++;

        if (a.Relationship == b.Relationship)
            matches++;

        if (a.Tradition == b.Tradition)
            matches++;

        if (a.Activity == b.Activity)
            matches++;

        //para la ruleta 0.0 o 1.0
        return matches / 5f;
    }



    //Para detetcar el candidate
    public void SetSelectedCandidate(CharacterInfo candidate)
    {
        selectedCandidate = candidate;
    }

}
