using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CandidateCreator
{
    public Character RandomCharacter;

    //TRYS
    public PlayerScript playerScript;
    //public ChSceneControllerScript chSceneController;
    //public Camera portraitCamera;
    //public RenderTexture portraitRenderTexture;



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
            NewCharacter.Surname = surnames[Random.Range(0, surnames.Count)];
            NewCharacter.Surname2 = surnames[Random.Range(0, surnames.Count)];
        }
        else
        {
            NewCharacter.Name = maleNames[Random.Range(0, maleNames.Count)];
            NewCharacter.Surname = surnames[Random.Range(0, surnames.Count)];
            NewCharacter.Surname2 = surnames[Random.Range(0, surnames.Count)];
        }

        NewCharacter.Age = Random.Range(18, 21);

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

    private Sprite CapturePortraitFromCamera(Camera cam)
    {
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = cam.targetTexture;

        Texture2D image = new Texture2D(cam.targetTexture.width, cam.targetTexture.height, TextureFormat.RGBA32, false);
        image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
        image.Apply();

        RenderTexture.active = currentRT;

        Sprite sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(0.5f, 0.5f));
        return sprite;
    }

    public Character GenerateFullRandomCandidate()
    {
        //instancia de personaje
        Character candidate = new Character();

        // atributos 
        FillCharacterAttributesRandomly(ref candidate);

        // apariencia
        //chSceneController = new ChSceneControllerScript();
        //chSceneController.RandomPlayerSprites();

        // retrato 
        ///candidate.PortraitSprite = CapturePortraitFromCamera(portraitCamera);

        // 5. guardar referencia 
        RandomCharacter = candidate;

        return candidate;
    }

}

