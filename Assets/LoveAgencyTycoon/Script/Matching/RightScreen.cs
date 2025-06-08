using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class RightScreen : MonoBehaviour
{

    //float compatibility = CompatibilityCalculator.Calculate(currentBachelor, selectedCandidate);

    public BachelorDisplay bachelorDisplay;
    //public SelectedCandidate menuSelect;
    public CandidateDisplayUI candidateDisplay;


    public TMP_Text bachelorNameText;
    public TMP_Text candidateNameText;
    //public Image compatibilityWheel;

    public Image greenFill;
    public Image redFill;
    public GameObject inactiveWheel;

    private CharacterInfo currentBachelor;
    private CharacterInfo selectedCandidate;

    public TMP_Text matchCounterText;
    private int successfulMatches = 0;

    public RectTransform arrowTransform;
    public Image failureScreen;
    public GameObject confettiEffect;




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



    void Start()
    {
        inactiveWheel.SetActive(true);
        greenFill.fillAmount = 0f;
        redFill.fillAmount = 0f;

        if (confettiEffect != null)
            confettiEffect.SetActive(false);

        if (failureScreen != null)
            failureScreen.color = new Color(1, 0, 0, 0f);
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

        inactiveWheel.SetActive(false);


        greenFill.fillAmount = compatibility;
        redFill.fillAmount = 1f;

        SpinArrow(compatibility);
    }

    private IEnumerator SpinAndDecide(float targetAngle, float greenChance, float duration)
    {
        if (greenChance <= 0f)
        {
            StartCoroutine(FlashFailure());
            yield break;
        }

        float startAngle = arrowTransform.rotation.eulerAngles.z;
        float endAngle = targetAngle + 1080f;

        float time = 0f;
        while (time < duration)
        {
            float angle = Mathf.Lerp(startAngle, endAngle, time / duration);
            arrowTransform.rotation = Quaternion.Euler(0f, 0f, -angle);
            time += Time.deltaTime;
            yield return null;
        }

        float arrowZ = arrowTransform.eulerAngles.z;
        float normalizedArrowAngle = (arrowZ + 360f) % 360f;

        float greenCenter = 90f;
        float greenAngleRange = greenChance * 360f;

        float greenStart = (greenCenter - greenAngleRange / 2f + 360f) % 360f;
        float greenEnd = (greenCenter + greenAngleRange / 2f) % 360f;

        bool isGreen;
        if (greenStart < greenEnd)
        {
            isGreen = normalizedArrowAngle >= greenStart && normalizedArrowAngle <= greenEnd;
        }
        else
        {
            isGreen = normalizedArrowAngle >= greenStart || normalizedArrowAngle <= greenEnd;
        }

        if (isGreen)
        {
            successfulMatches++;
            UpdateMatchCounter();
            TriggerSuccessEffect();
            RemoveMatchedCharacters();
        }
        else
        {
            StartCoroutine(FlashFailure());
        }
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


    //FLECHA
    public void SpinArrow(float greenChance)
    {
        float randomAngle = Random.Range(0f, 360f);
        float duration = 3f;// 3 vueltas
        StartCoroutine(SpinAndDecide(randomAngle, greenChance, duration));
    }

   
    private void UpdateMatchCounter()
    {
        matchCounterText.text = $"Matches: {successfulMatches}";
    }


    private void TriggerSuccessEffect()
    {
        confettiEffect.SetActive(true);
        Invoke("StopConfetti", 2f); //2sec

        if (successfulMatches >= 3)
        {
            Win();
        }

    }

    private void StopConfetti()
    {
        confettiEffect.SetActive(false);
    }

    private IEnumerator FlashFailure()
    {
        failureScreen.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        failureScreen.color = new Color(1, 0, 0, 0f);

    }

    private void RemoveMatchedCharacters()
    {
        if (candidateDisplay != null)
        {
            candidateDisplay.ChangeCandidate(); 
            candidateDisplay.gameObject.SetActive(true);
        }

        if (bachelorDisplay != null)
            bachelorDisplay.RemoveCurrentBachelor();
    }


    public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }


}
