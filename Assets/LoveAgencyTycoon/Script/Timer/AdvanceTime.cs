using System;
using System.Collections;
using TMPro;
#if UNITY_EDITOR
using UnityEditor.UIElements;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceTime : MonoBehaviour
{
    [SerializeField] private int startingTime;
    [SerializeField] private float timeUntilHourChange = 2;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private int timeLimit;
    public bool Pm = false;
    public bool started;
    [NonSerialized] public int timeHours;

    private void Start()
    {
        timeHours = startingTime;
    }

    private void Update()
    {
        if (started)
        {
            
            if (!Pm)
            {
                timeText.text = timeHours + ":00 AM";
            }
            if (Pm)
            {
                timeText.text = timeHours + ":00 PM";
            }
        }
    }

    private IEnumerator advanceHourOverTime()
    {
        if (started)
        {
            yield return new WaitForSeconds(timeUntilHourChange);

            if (!Pm && timeHours == 12)
            {
                timeHours = 1;
                Pm = true;
            }
            else
            {
                timeHours++;
            }
            if (timeHours < timeLimit)
            {
                StartCoroutine(routine: advanceHourOverTime());

            }
            if (Pm && timeHours > 8)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void StartButton()
    {
        StartCoroutine(routine: advanceHourOverTime());
        started = true;
    }


}