using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase para manejo de sonidos en el juego
public class Sonido : MonoBehaviour
{

    public static Sonido sonido;
    //sonido para el salto
    public AudioSource audioSalto;
    //sonido para las frutas(monedas obtenidas) al golpear el bloque
    public AudioSource audioMoneda;
    //sonido si mario muere
    public AudioSource audioMuere;
    //Sonido cuando mario pisa a Goomba
    public AudioSource audioPisaGoomba;
    //Sonido al llegar al final del juego
    public AudioSource audioFinal;
    //sonido de fondo
    public AudioSource audioFondo;
    //sonido de fuego
    public AudioSource audioFuego;

    void Awake()
    {
        if (sonido == null)
        {
            sonido = this;
        } else if (sonido != this)
        {
            Destroy(gameObject);
        }
        audioSalto.Stop();
        audioPisaGoomba.Stop();
        audioMoneda.Stop();
        audioMuere.Stop();
        audioFinal.Stop();
    }

    void OnDestroy()
    {
        sonido = null;
    }

    public void PlaySalto()
    {
        audioSalto.Play();
    }

    public void PlayMoneda()
    {
        audioMoneda.Play();
    }

    public void PlayMuere()
    {
        audioMuere.Play();
    }

    public void PlayPisaGoomba()
    {
        audioPisaGoomba.Play();
    }

    public void PlayFinal()
    {
        audioFinal.Play();
    }

    public void PlayFuego()
    {
        audioFuego.Play();
    }

}
