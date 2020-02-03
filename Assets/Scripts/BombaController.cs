using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaController : MonoBehaviour
{
    // Para obtener una instancia del prefab Bomba
    public Transform bomba;
    private float tiempo = 0.0f;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        tiempo = tiempo + Time.deltaTime;
        if (tiempo.ToString("f0") == "4")
        {
            Instantiate(bomba, new Vector3(29f, -3.8291f, 0), Quaternion.identity);
            tiempo = 0.0f;
        }

    }
}
