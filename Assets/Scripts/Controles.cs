using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour
{
    //Controlador de Mario
    MarioBross Mario;

    //Start
    private GameObject button;

    void Start()
    {
        button = GameObject.Find("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Mario = GameObject.FindObjectOfType<MarioBross>();
    }

    //Mueve a Mario hacia adeante
    public void Adelante()
    {
        Mario.inputX = 1f;
    }

    //Detiene a mario
    public void Detener()
    {
        Mario.inputX = 0;
    }

    //Mueve a Mario hacia atras
    public void Atras()
    {
        Mario.inputX = -1f;
    }

    //Saltar Mario
    public void Saltar()
    {
        Mario.saltar = true;
    }

    //Disparar Mario
    public void Disparar()
    {
        Mario.disparar = true;
    }

    //Reiniciar el juego
    public void Iniciar()
    {
        Constantes.NUMERO_FRUTAS = 0;
        Constantes.NUMERO_PUNTOS = 0;
        if (Constantes.NIVEL == 2)
        {
            SceneManager.LoadScene("Level2");
        } else
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
