using UnityEngine;

public class ScrollSwitcher : MonoBehaviour
{
    [Header("Asigna aquí tus Scroll Views")]
    public GameObject initialScrollView;
    public GameObject secondScrollView;

    void Start()
    {
        initialScrollView.SetActive(true);
        secondScrollView.SetActive(false);
    }

    public void ShowSecondScroll()
    {
        initialScrollView.SetActive(false);
        secondScrollView.SetActive(true);
    }
}