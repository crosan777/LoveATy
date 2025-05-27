using UnityEngine;

public class CandidateSpawner : MonoBehaviour
{
    // es un script de prueba porque no se como almacenar y spawnear los candidates

    public GameObject candidateDisplayPrefab; // prefab del candidate
    public Transform contentParent; // content de ScrollView
    public CandidateCreator candidateCreator; // script del CandidateCreator

    public int numberOfCandidatesToGenerate = 5;

    void Start()
    {
        SpawnCandidates();

    }
    void SpawnCandidates()
    {
        for (int i = 0; i < numberOfCandidatesToGenerate; i++)
        {
            Character newCharacter = candidateCreator.GenerateFullRandomCandidate();

            GameObject candidateGO = Instantiate(candidateDisplayPrefab, contentParent);
            CandidateDisplayUI displayUI = candidateGO.GetComponent<CandidateDisplayUI>();
            displayUI.DisplayCandidate(newCharacter);
        }
    }
    void Update()
    {
        
    }
}
