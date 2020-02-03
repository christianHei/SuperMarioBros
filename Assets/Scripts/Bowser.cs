using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowser : MonoBehaviour
{
    //Movimiento Bowser
    public GameObject posicionInicial;
    public GameObject posicionFinal;
    private float velocidad = 0.01f;
    private bool derecha = true;

    //Controlador de Mario
    public GameObject Mario;

    //Animaciones
    Animator animator;

    // Para obtener una instancia del prefab Fuego
    public Transform fuego;
    private float tiempo = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (derecha)
        {
            transform.position = posicionFinal.transform.position;
        }
        else
        {
            transform.position = posicionInicial.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Animación de izquierda a derecha de Spiny
    void FixedUpdate()
    {  
        if (derecha)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal.transform.position, velocidad);
            if (transform.position == posicionFinal.transform.position)
            {
                derecha = false;
            }
        }

        if (!derecha)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial.transform.position, velocidad);
            if (transform.position == posicionInicial.transform.position)
            {
                derecha = true;
                //GetComponent<SpriteRenderer>().flipX = false;

            }
        }


        if (Mario.transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        tiempo = tiempo + Time.deltaTime;
        if (tiempo.ToString("f0") == "5" && !Mario.gameObject.GetComponent<MarioBross>().win)
        {           
            Instantiate(fuego, new Vector3(transform.position.x, -2.25f, 0), Quaternion.identity);
            tiempo = 0.0f;
        }
    }
}
