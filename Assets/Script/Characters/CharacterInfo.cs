using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    #region Atributes
    public string Name { get; set; } 
    public string Surname { get; set; }
    public string Surname2 { get; set; }

    public string Description;

    public int Age = 18;

    public enum ActivityType { Activo, Tranquilo } 
    public enum MethodologyType { Despreocupado, Espontaneo, Metodico }
    public enum SocialType { Extrovertido, Introvertido, Neutral }
    public enum TraditionType { Clasico , Moderno }
    public enum RelationshipType { Romantico, Picante, Tierno, Evitativo }
    

    public ActivityType Activity;
    public MethodologyType Methodology;
    public SocialType Social;
    public TraditionType Tradition;
    public RelationshipType Relationship;

    #endregion

    public Character (string name, string surname, string surname2, string Description, 
          ActivityType activity, MethodologyType methodology,
          SocialType social, TraditionType tradition,
          RelationshipType relationship) // Constructor for characters
    {
        Name = name; //Name
        Surname = surname; //Surname
        Surname2 = surname2; //Surname2
        Activity = activity; //Activity type
        Methodology = methodology; //Methodology Type
        Social = social; //Social Type
        Tradition = tradition; //Tradition type
        Relationship = relationship; //Relationship type
    }
}
