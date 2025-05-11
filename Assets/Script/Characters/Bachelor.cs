using UnityEngine;

public class Client : Character
{
    public Client(string name, string surname, string surname2, string Description, int age,
           ActivityType activity, MethodologyType methodology,
           SocialType social, TraditionType tradition,
           RelationshipType relationship) : base (name, surname, surname2, Description,
           activity, methodology, social, tradition, relationship)
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
