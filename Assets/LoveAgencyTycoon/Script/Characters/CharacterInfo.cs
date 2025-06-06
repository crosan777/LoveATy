using System.Collections.Generic;
using UnityEngine;



public enum ActivityType { Activo, Tranquilo }
public enum MethodologyType { Despreocupado, Espontaneo, Metodico }
public enum SocialType { Extrovertido, Introvertido, Neutral }
public enum TraditionType { Clasico, Moderno }
public enum RelationshipType { Romantico, Picante, Evitativo }

public enum GenderType { Male, Female }


[CreateAssetMenu(fileName = "NewCharacterInfo", menuName = "Love Agency/Character")]
public class CharacterInfo : ScriptableObject
{
    #region Atributes
    public Sprite image;
    public string Name;
    public string Surname { get; set; }
    public string Surname2 { get; set; }


    [TextArea(3, 10)] //para el scroll
    public string Description;

    public int Age = 18;

    public GenderType Gender;

    public ActivityType Activity;
    public MethodologyType Methodology;
    public SocialType Social;
    public TraditionType Tradition;
    public RelationshipType Relationship;



    #endregion
}