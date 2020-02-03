using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{

    //Objeto Mario para detectar las colisiones
    public GameObject Mario;
    //Animación
    Animator animator;
    //Número de goles que se puede dar al bloque para recibir puntos.
    int numeroGolpes;

    //private int 

    // Start is called before the first frame update
    void Start()
    {
        numeroGolpes = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Detectar colisiones contra Mario
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (Mario.gameObject.GetComponent<MarioBross>().contactoSuelo == false && numeroGolpes < Constantes.NUMERO_GOLPES_MAXIMO)
        {
            //Play sonido
            Sonido.sonido.PlayMoneda();
            // Cuando mario golpea el bloque se inicia la animación
            animator.SetBool("golpear", true);
            numeroGolpes++;
            //incrementar el número de frutas obtenidas
            Constantes.NUMERO_FRUTAS++;
            //incrementar el número de puntos de mario en 100 por cada fruta obtenida
            Constantes.NUMERO_PUNTOS+=100;
        }
    }

    //Actualizar variables
    void LateUpdate()
    {
        //Se resetea la animación luego del golpe al bloque
        if (Mario.gameObject.GetComponent<MarioBross>().contactoSuelo == true)
        {
            animator.SetBool("golpear", false);
        }
    }
}
