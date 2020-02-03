using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    //movimiento en x
    private float movX;
    //velocidad en x
    private float velX = 0.05f;
    private float tiempo = 0.0f;

    //Mario
    MarioBross Mario;

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        //Movimiento en x      
        Mario = GameObject.FindObjectOfType<MarioBross>();
        if (Mario.inputX == 1f)
        {
            velX = -0.05f;
        }
        //
        movX = transform.position.x + (-velX);
        transform.position = new Vector3(movX, transform.position.y, 0);
        tiempo = tiempo + Time.deltaTime;
        if (tiempo.ToString("f0") == "3")
        {
            Destroy(gameObject);
            tiempo = 0.0f;
        }        
    }

    //Detectar colisiones contra los tags
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goomba" || collision.gameObject.tag == "Bomba"
            || collision.gameObject.tag == "Spiny" || collision.gameObject.tag == "Bowser")
        {
            //Play sonido
            Sonido.sonido.PlayPisaGoomba();
            //incrementar el número de puntos de mario en 1000 por cada Goomba muerto
            Constantes.NUMERO_PUNTOS += 100;

            velX = 0;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
