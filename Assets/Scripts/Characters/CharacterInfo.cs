using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterInfo", menuName = "Love Agency/Character")]
    public class CharacterInfo : ScriptableObject
{
    #region Atributes
    public Sprite imagen;

    public string Name { get; set; } 
    public string Surname { get; set; }
    public string Surname2 { get; set; }

    public string Description;

    public int Age = 18;

    
    public enum Gender { Male, Female }
    public enum ActivityType { Activo, Tranquilo } 
    public enum MethodologyType { Despreocupado, Espontaneo, Metodico }
    public enum SocialType { Extrovertido, Introvertido, Neutral }
    public enum TraditionType { Clasico , Moderno }
    public enum RelationshipType { Romantico, Picante, Evitativo }
    
    public ActivityType Activity;
    public MethodologyType Methodology;
    public SocialType Social;
    public TraditionType Tradition;
    public RelationshipType Relationship;

    #endregion
    public void getCandidateInfo ()
    {
         
    }
 
   
}
