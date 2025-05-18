using UnityEngine;

public class PortraitGenerator : MonoBehaviour
{
    public CandidateCreator candidateCreator;
    public CandidateDisplayUI candidateDisplay;

    void Start()
    {
        //Character newCandidate1 = candidateCreator.GenerateRandomCharacter();
        //Character newCandidate2 = candidateCreator.GenerateRandomCharacter();
        //Character newCandidate3 = candidateCreator.GenerateRandomCharacter();
        //Character newCandidate4 = candidateCreator.GenerateRandomCharacter();
        //Character newCandidate5 = candidateCreator.GenerateRandomCharacter();

        //candidateDisplay.DisplayCandidate(newCandidate1);
        //candidateDisplay.DisplayCandidate(newCandidate2);
        //candidateDisplay.DisplayCandidate(newCandidate3);
        //candidateDisplay.DisplayCandidate(newCandidate4);
        //candidateDisplay.DisplayCandidate(newCandidate5);


        //CAMBIA EL 10 PER EL NUM DE CANDIDATES
        for (int i = 0; i < 10; i++)
        {
            Character c = candidateCreator.GenerateRandomCharacter();
        }


    }

    void Update()
    {
        
    }
}
