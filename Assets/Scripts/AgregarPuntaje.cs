using TMPro;
using UnityEngine;

public class AgregarPuntaje : MonoBehaviour
{
    public TMP_Text puntajeTxt;
    public int puntaje;
    
    public void AddPuntos(int puntos)
    {
        puntaje += puntos;
        puntajeTxt.text = puntaje.ToString();
    }

    public void ResetPuntos()
    {
        puntaje = 0;
        puntajeTxt.text = puntaje.ToString();
    }
}
