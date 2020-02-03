using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    //movimiento en x
    private float movX;
    //velocidad en x
    private float velX = 0.05f;

    void FixedUpdate()
    {
        //Movimiento en x
        movX = transform.position.x - velX;
        transform.position = new Vector3(movX, transform.position.y, 0);
    }

    //Detectar colisiones contra los tags
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ParedFuego")
        {
            velX = 0;
            Destroy(gameObject);
        }
    }
}
