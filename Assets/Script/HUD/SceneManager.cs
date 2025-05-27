using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManacer : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void ExitGame()
    {
        Debug.Log("No salgas porfi...");
        Application.Quit();
    }


}
