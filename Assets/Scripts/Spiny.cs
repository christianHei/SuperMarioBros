using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiny : MonoBehaviour
{
    //Movimiento Spiny
    public GameObject posicionInicial;
    public GameObject posicionFinal;
    private float velocidad = 0.01f;
    private bool derecha = true;

    //Animaciones
    Animator animator;

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

    // Animación de izquierda a derecha de Spiny
    void FixedUpdate()
    {
        if (derecha)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal.transform.position, velocidad);
            if (transform.position == posicionFinal.transform.position)
            {
                derecha = false;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (!derecha)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial.transform.position, velocidad);
            if (transform.position == posicionInicial.transform.position)
            {
                derecha = true;
                GetComponent<SpriteRenderer>().flipX = false;

            }
        }
    }    
}
