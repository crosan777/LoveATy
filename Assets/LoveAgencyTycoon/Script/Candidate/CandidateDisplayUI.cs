using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandidateDisplayUI : MonoBehaviour
{
    public PortraitGenerator portraitGenerator;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI AgeNumber;
    public TextMeshProUGUI genderText;

    public Image activityIconImage;
    public Sprite activoSprite;
    public Sprite tranquiloSprite;

    public Image methodologyIconImage;
    public Sprite despreocupadoSprite;
    public Sprite espontaneoSprite;
    public Sprite metodicoSprite;

    public Image socialIconImage;
    public Sprite extrovertidoSprite;
    public Sprite introvertidoSprite;
    public Sprite neutralSprite;

    public Image traditionIconImage;
    public Sprite clasicoSprite;
    public Sprite modernoSprite;

    public Image relationIconImage;
    public Sprite romanticoSprite;
    public Sprite picanteSprite;
    public Sprite evitativoSprite;

    private CandidateCreator candidateCreator;

    public CharacterInfo currentCandidate;

    public CharacterInfo GetCurrentCandidate()
    {
        return currentCandidate;
    }

    public void CandidateButtonPressed()
    {
        CharacterInfo candidate = GetCurrentCandidate();

        RightScreen rightScreen = Object.FindFirstObjectByType<RightScreen>();
        if (rightScreen != null)
        {
            rightScreen.SelectedCandidate(candidate);
        }
    }



    void Start()
    {
        candidateCreator = new CandidateCreator();
        ChangeCandidate();
    }

    public void ChangeCandidate()
    {
        currentCandidate = candidateCreator.GenerateFullRandomCandidate();
        DisplayCandidate(currentCandidate);
    }

    //REFF
    //public enum ActivityType { Activo, Tranquilo } 
    //public enum MethodologyType { Despreocupado, Espontaneo, Metodico }
    //public enum SocialType { Extrovertido, Introvertido, Neutral }
    //public enum TraditionType { Clasico, Moderno }
    //public enum RelationshipType { Romantico, Picante, Evitativo }

    public void DisplayCandidate(CharacterInfo candidate)
    {
        portraitGenerator.RandomPlayerSprites();


        nameText.text = $"{candidate.Name} {candidate.Surname} {candidate.Surname2}";
        AgeNumber.text = $"{candidate.Age} años";
        genderText.text = $"{candidate.Gender}";


        //activityText.text = $"Actividad: {candidate.Activity}";
        //methodologyText.text = $"Metodolog�a: {candidate.Methodology}";
        //socialText.text = $"Social: {candidate.Social}";
        //relationshipText.text = $"Relaci�n: {candidate.Relationship}";
        //traditionText.text = $"Tradici�n: {candidate.Tradition}";

       // activityIconImage.sprite = character.Activity ==

        // ACTIVITY AMARILLO
        switch (candidate.Activity)
        {
            case ActivityType.Tranquilo:
                activityIconImage.sprite = tranquiloSprite;
                break;
            case ActivityType.Activo:
                activityIconImage.sprite = activoSprite;
                break;
        }
        // METHODOLOGY AZUL 
        switch (candidate.Methodology)
        {
            case MethodologyType.Despreocupado:
                methodologyIconImage.sprite = despreocupadoSprite;
                break;
            case MethodologyType.Espontaneo:
                methodologyIconImage.sprite = espontaneoSprite;
                break;
            case MethodologyType.Metodico:
                methodologyIconImage.sprite = metodicoSprite;
                break;
        }
        // SOCIAL VERDE
        switch (candidate.Social)
        {
            case SocialType.Extrovertido:
                socialIconImage.sprite = extrovertidoSprite;
                break;
            case SocialType.Introvertido:
                socialIconImage.sprite = introvertidoSprite;
                break;
            case SocialType.Neutral:
                socialIconImage.sprite = neutralSprite;
                break;
        }
        // TRADITIONAL LILA
        switch (candidate.Tradition)
        {
            case TraditionType.Clasico:
                traditionIconImage.sprite = clasicoSprite;
                break;
            case TraditionType.Moderno:
                traditionIconImage.sprite = modernoSprite;
                break;
        }
        // RELATIONSHIP ROJO
        switch (candidate.Relationship)
        {
            case RelationshipType.Romantico:
                relationIconImage.sprite = romanticoSprite;
                break;
            case RelationshipType.Picante:
                relationIconImage.sprite = picanteSprite;
                break;
            case RelationshipType.Evitativo:
                relationIconImage.sprite = evitativoSprite;
                break;
        }

    }

    void OnBecomeInvisible()
    {
        Debug.Log("HOLA");
    }
}
