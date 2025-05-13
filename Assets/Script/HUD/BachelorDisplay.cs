using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class BachelorDisplay : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text Name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public class  Bachelor
    {
        
        public string NameSurnames;
        public int age;
        public string description;

    }

    public class BachelorPanel : MonoBehaviour
    {
        public UnityEngine.UI.Image photoBachelor;
        public Text NameText;
        public Text edadTexto;
        public Text DescriptionText;

        public UnityEngine.UI.Button leftArrow;
        public UnityEngine.UI.Button rightArrow;    

        public Bachelor[] bachelors;
        private int actualIndex = 0;

    }

    private void Start()
    {

    }

    void ShowPanel() 
    { }
}
