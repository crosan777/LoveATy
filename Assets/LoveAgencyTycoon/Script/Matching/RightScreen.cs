using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RightScreen : MonoBehaviour
{

    //float compatibility = CompatibilityCalculator.Calculate(currentBachelor, selectedCandidate);

    public BachelorDisplay bachelorDisplay;
    //public SelectedCandidate menuSelect;
    public CandidateDisplayUI candidateDisplay;


    public TMP_Text bachelorNameText;
    public TMP_Text candidateNameText;
    public Image compatibilityWheel;



    private CharacterInfo currentBachelor;
    private CharacterInfo selectedCandidate;


    //Para detetcar el candidate
    public void SelectedCandidate(CharacterInfo candidate)
    {
        selectedCandidate = candidate;
        candidateNameText.text = $"{selectedCandidate.Name} {selectedCandidate.Surname} {selectedCandidate.Surname2}";

    }

    public void UpdateBachelorName(CharacterInfo bachelor)
    {
        currentBachelor = bachelor;
        bachelorNameText.text = bachelor.Name;
    }



    // boton MATCH
    public void MatchButton()
    {
        currentBachelor = bachelorDisplay.GetCurrentBachelor();
        //selectedCandidate = menuSelect.selectedCandidate;

        if (currentBachelor == null || selectedCandidate == null) return;

        Name();
        CompatibilityDisplay();
    }

    private void Name()
    {
        bachelorNameText.text = currentBachelor.Name;
        candidateNameText.text = $"{selectedCandidate.Name} {selectedCandidate.Surname} {selectedCandidate.Surname2}";
    }


    private void CompatibilityDisplay()
    {
        float compatibility = CalculateCompatsibility(currentBachelor, selectedCandidate);

        compatibilityWheel.fillAmount = compatibility;
        compatibilityWheel.color = Color.Lerp(Color.red, Color.green, compatibility);
        // ahora lo hace instantaneo despues le añadimos alguna animacion
    }

    private float CalculateCompatsibility(CharacterInfo bachelor, CharacterInfo candidate)
    {
        int matches = 0;

        if (bachelor.Social == candidate.Social)
            matches++;

        if (bachelor.Methodology == candidate.Methodology)
            matches++;

        if (bachelor.Relationship == candidate.Relationship)
            matches++;

        if (bachelor.Tradition == candidate.Tradition)
            matches++;

        if (bachelor.Activity == candidate.Activity)
            matches++;

        //para la ruleta 0.0 o 1.0
        return matches / 5f;
    }
}
