using System.Collections.Generic;
using UnityEngine;

public enum ActivityType { Activo, Tranquilo } 
public enum MethodologyType { Despreocupado, Espontaneo, Metodico }
public enum SocialType { Extrovertido, Introvertido, Neutral }
public enum TraditionType { Clasico , Moderno }
public enum RelationshipType { Romantico, Picante, Evitativo }

public enum GenderType { Male, Female }

public class Character : MonoBehaviour
{
    #region Atributes
    public Sprite PortraitSprite;

    public string Name { get; set; } 
    public string Surname { get; set; }
    public string Surname2 { get; set; }

    public string Description;

    public int Age = 18;

    public GenderType Gender;

    public ActivityType Activity;
    public MethodologyType Methodology;
    public SocialType Social;
    public TraditionType Tradition;
    public RelationshipType Relationship;



    #endregion

    public bool IsCompatible(Character Candidate)
    {
        return Age == Candidate.Age;
    }
}
