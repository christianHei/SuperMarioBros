using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase para el control de Goomba
public class Goomba : MonoBehaviour
{
    //Movimiento Goomba
    public GameObject posicionInicial;
    public GameObject posicionFinal;
    public float velGoomba = 0.01f;
    public bool mirandoDerecha = true;
   
    //Detectar pisada
    public GameObject Mario;
    //Varable para almacenar si Goomba fue pisado por Mario
    public bool pisada = false;

    //Animaciones
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (mirandoDerecha)
        {
            transform.position = posicionFinal.transform.position;
        } else
        {
            transform.position = posicionInicial.transform.position;

        }
    }

    // Animación de izquierda a derecha de Goomba
    void FixedUpdate()
    {
        if (mirandoDerecha)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal.transform.position, velGoomba);
            if (transform.position == posicionFinal.transform.position)
            {
                mirandoDerecha = false;
                GetComponent<SpriteRenderer>().flipX = true;
                animator.SetFloat("velX", velGoomba);

            }
        }

        if (!mirandoDerecha)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial.transform.position, velGoomba);
            if (transform.position == posicionInicial.transform.position)
            {
                mirandoDerecha = true;
                GetComponent<SpriteRenderer>().flipX = false;
                animator.SetFloat("velX", velGoomba);

            }
        }
    }

    //Detectar colisiones contra Mario
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifico si Mario pisa a Goomba
        if (Mario.gameObject.GetComponent<MarioBross>().contactoSuelo == false && collision.gameObject.tag == "Mario")
        {
            //Play sonido
            Sonido.sonido.PlayPisaGoomba();
            pisada = true;
            //Se muestra la animación de Goomba muerto
            animator.SetBool("pisada", true);
            //Se detiene la desplazamiento en X de Goomba
            velGoomba = 0;
            //incrementar el número de puntos de mario en 1000 por cada Goomba muerto
            Constantes.NUMERO_PUNTOS += 100;
        }
    }

    void LateUpdate()
    {
        // Si Goomba fue pisado por Mario y Mario ya toca el suelo. Quito del juego el Objeto Goomba.
        if (pisada && Mario.gameObject.GetComponent<MarioBross>().contactoSuelo == true)
        {
            Destroy(gameObject);
            pisada = false;
            animator.SetBool("pisada", false);
        }
    }
}
