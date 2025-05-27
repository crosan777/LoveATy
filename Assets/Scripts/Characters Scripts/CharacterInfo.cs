using System.Collections.Generic;
using UnityEngine;



public enum ActivityType { Activo, Tranquilo }
public enum MethodologyType { Despreocupado, Espontaneo, Metodico }
public enum SocialType { Extrovertido, Introvertido, Neutral }
<<<<<<< HEAD:Assets/Script/Characters/CharacterInfo.cs
public enum TraditionType { Clasico , Moderno }
=======
public enum TraditionType { Clasico, Moderno }
>>>>>>> main:Assets/Scripts/Characters Scripts/CharacterInfo.cs
public enum RelationshipType { Romantico, Picante, Evitativo }

public enum GenderType { Male, Female }


[CreateAssetMenu(fileName = "NewCharacterInfo", menuName = "Love Agency/Character")]
public class CharacterInfo : ScriptableObject
{
    #region Atributes
<<<<<<< HEAD:Assets/Script/Characters/CharacterInfo.cs
    public Sprite PortraitSprite;

    public string Name { get; set; } 
=======
    public Sprite image;
    public string Name;
>>>>>>> main:Assets/Scripts/Characters Scripts/CharacterInfo.cs
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
<<<<<<< HEAD:Assets/Script/Characters/CharacterInfo.cs

    public bool IsCompatible(Character Candidate)
    {
        return Age == Candidate.Age;
    }
}
=======
}
>>>>>>> main:Assets/Scripts/Characters Scripts/CharacterInfo.cs
