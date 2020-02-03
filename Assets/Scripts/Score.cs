using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    // Update is called once per frame
    void LateUpdate()
    {
        //Contador de frutas
        GameObject.Find("numeroFrutas").GetComponent<Text>().text = Constantes.NUMERO_FRUTAS + "";
        //Contador de puntos
        GameObject.Find("puntos").GetComponent<Text>().text = Constantes.NUMERO_PUNTOS + "";
    }
}
