using UnityEngine;
using System.Collections.Generic;

public class CandidateCreator : MonoBehaviour
{

    public Character RandomCharacter;
    public CandidateCreator candidateCreator;
    public static Character CreatedCharacter;
    public PlayerScript playerScript;

    List<string> maleNames = new List<string> {
    "Liam", "Noah", "Oliver", "Oleksiy" , "Elijah", "James", "William", "Benjamin", "Lucas", "Henry", "Alexander",
    "Mason", "Michael", "Ethan", "Daniel", "Jacob", "Logan", "Jackson", "Levi", "Sebastian", "Mateo",
    "Jack", "Owen", "Theodore", "Aiden", "Samuel", "Joseph", "John", "David", "Wyatt", "Matthew",
    "Luke", "Asher", "Carter", "Julian", "Grayson", "Leo", "Jayden", "Gabriel", "Isaac", "Lincoln",
    "Anthony", "Hudson", "Dylan", "Ezra", "Thomas", "Charles", "Christopher", "Jaxon", "Maverick", "Josiah"
    };

    List<string> femaleNames = new List<string> {
    "Olivia", "Emma", "Ava", "Charlotte", "Sophia", "Amelia", "Isabella", "Mia", "Evelyn", "Harper",
    "Luna", "Camila", "Gianna", "Elizabeth", "Eleanor", "Ella", "Abigail", "Emily", "Scarlett", "Grace",
    "Chloe", "Victoria", "Riley", "Aria", "Lily", "Aubrey", "Zoey", "Penelope", "Nora", "Hazel",
    "Layla", "Lillian", "Addison", "Violet", "Aurora", "Savannah", "Brooklyn", "Bella", "Claire", "Skylar",
    "Lucy", "Paisley", "Everly", "Anna", "Caroline", "Nova", "Genesis", "Emilia", "Kennedy", "Samantha"
    };

    List<string> surnames = new List<string> {
    "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
    "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
    "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
    "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
    "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts"
    };



    public void FillCharacterAttributesRandomly(ref Character NewCharacter)
    {
        NewCharacter.Gender = (GenderType)Random.Range(0,2);

        if (NewCharacter.Gender == GenderType.Female)
        {
            NewCharacter.Name = femaleNames[Random.Range(0, femaleNames.Count)];
            NewCharacter.Surname = surnames[Random.Range(0, femaleNames.Count)];
            NewCharacter.Surname2 = surnames[Random.Range(0, femaleNames.Count)];
        }
        else
        {
            NewCharacter.Name = maleNames[Random.Range(0, femaleNames.Count)];
            NewCharacter.Surname = surnames[Random.Range(0, femaleNames.Count)];
            NewCharacter.Surname2 = surnames[Random.Range(0, femaleNames.Count)];
        }

        NewCharacter.Activity = (ActivityType)Random.Range(0, 2);
        NewCharacter.Methodology = (MethodologyType)Random.Range(0,3);
        NewCharacter.Social = (SocialType)Random.Range(0, 3);
        NewCharacter.Tradition = (TraditionType)Random.Range(0, 2);
        NewCharacter.Relationship = (RelationshipType)Random.Range(0, 3);
    }

    public Character GenerateRandomCharacter()
    {
        RandomCharacter = new Character();
        FillCharacterAttributesRandomly(ref RandomCharacter);
        return RandomCharacter;
    }
    //portrait
    private PlayerScript RandomPlayerSprites()
    {
        // Lógica para randomizar sprites dentro de playerScript
        // Ejemplo que ya tienes
        int orgPartIndex = 0;
        int len = playerScript.bodyParts.Length;

        for (int i = 0; i < len; i++)
        {
            int rndSpriteIndex = Random.Range(0, playerScript.bodyParts[i].GetSpritesLength());
            playerScript.bodyParts[i].UpdateSprite(rndSpriteIndex);
            RandomizePartColor(playerScript.bodyParts[i].tag);
        }

        return playerScript;
    }

    public PlayerScript CreateRandomCandidate()
    {
        return RandomPlayerSprites();
    }

    private void RandomizePartColor(string tag)
    {
        UnityEngine.Color randomColor = new UnityEngine.Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        ChangeCurrentPartColor(randomColor);
    }
}

