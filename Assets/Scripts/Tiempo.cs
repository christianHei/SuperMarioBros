using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    //variable TIME, 200 segundos hasta terminar el juego
    public float tiempo = 201f;

    //Objeto Mario
    public GameObject Mario;
    //Start
    private GameObject button;

    private bool detener = false;

    void Awake()
    {
        button = GameObject.Find("Start");
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo - Time.deltaTime;
        GameObject.Find("tiempo").GetComponent<Text>().text = tiempo.ToString("f0");
        if (tiempo <= 0.0f)
        {
            detener = true;
            tiempo = 0.0f;

        }
    }

    void LateUpdate()
    {
        if (detener)
        {
            //Play sonido
            Sonido.sonido.PlayMuere();
            Sonido.sonido.audioFondo.Stop();
            //Detiene el juego y muestra el Botón de Reiniciar con un mensaje TIME OVER
            Mario.gameObject.GetComponent<ControladorMario>().velX = 0;
            GameObject.Find("Mensaje").GetComponent<Text>().text = "TIME OVER";
            GameObject.Find("Mensaje").GetComponent<Text>().color = new Color(1f, 0, 0);
            button.SetActive(true);
        }
    }
}
