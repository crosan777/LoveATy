using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NuevoCandidato", menuName = "Candidatos")]
public class Candidatos : ScriptableObject
{
    public GameObject candidatoJugable;
    public Sprite imagen;
    public string nombre;

}
