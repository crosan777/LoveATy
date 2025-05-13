using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;
using static BachelorDisplay;
using System;

public class BachelorManager : MonoBehaviour
{
    public List<ScriptableObject> Bachelors = new List<ScriptableObject>();
    
    private void BachelorList (List<Bachelor> Bachelors)
    {
            Bachelors.Add(new Bachelor ("Ricard", "Perea", "Ros",
                "- Tu pareja quiere apuntarse a bailes de salón, tú... Pienso que me está tomando el peloç" +
                "Cuando miras la tele... Miro mi programa favorito y despúes apago" +
                "En una fiesta eres... el alma de la fiesta" +
                "¿Qué tipo de juegos prefieres? Los Videojuegos" +
                "Cuando compras una cama, tienes en cuenta...Lo bien que dormire en ella yo y mi pareja", 18,
                Bachelor.ActivityType.Tranquilo,
                Bachelor.MethodologyType.Metodico,
                Bachelor.SocialType.Extrovertido,
                Bachelor.TraditionType.Moderno,
                Bachelor.RelationshipType.Romantico));
            
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BachelorList(ScriptableObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {

    }
}
