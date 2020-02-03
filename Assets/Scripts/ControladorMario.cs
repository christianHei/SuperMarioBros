using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controlador de Mario
 * */
public class ControladorMario : MonoBehaviour
{
    //Variables de movimiento
    public float velX;
    private float movX;
    public float inputX;
    public bool saltar;
    //Variables de salto
    public float jump;
    public Transform pie;
    public float radioPie;
    public LayerMask suelo;
    public LayerMask enemigos;
    public bool contactoSuelo;

    //Animaciones
    Animator animator;

    //Para obtener referencia del personaje Goomba
    public GameObject goomba;

    //Botón Start
    private GameObject button;

    void Start()
    {
        button = GameObject.Find("Start");
        button.SetActive(false);
    }

    //Inicializar
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Para activar las teclas de direccón del teclado: inputX = Input.GetAxis("Horizontal");
        //Verificar la velocidad ingresada
        if (inputX > 0)
        {
            movX = transform.position.x + (inputX * velX);
            transform.position = new Vector3(movX, transform.position.y,0);
            transform.localScale = new Vector3(5,5,0);
        }

        if (inputX < 0)
        {
            movX = transform.position.x + (inputX * velX);
            transform.position = new Vector3(movX, transform.position.y, 0);
            transform.localScale = new Vector3(-5, 5, 0);

        }

        if (inputX != 0 && contactoSuelo) {
            animator.SetFloat("velX", 1);
        } else {
            animator.SetFloat("velX", 0);
        }

        //verificar si esta en el suelo
        contactoSuelo = Physics2D.OverlapCircle(pie.position, radioPie, suelo);

        //verificar salto
        if (contactoSuelo) {
            animator.SetBool("contactoSuelo", true);
        } else {
            animator.SetBool("contactoSuelo", false);
        } 

        //Saltar
        //Para saltar con el teclado con el teclado: Input.GetKeyDown(KeyCode.Space)
        if (contactoSuelo && saltar)
        {
            //Play sonido
            Sonido.sonido.PlaySalto();
            GetComponent <Rigidbody2D>().AddForce(new Vector2(0, jump));
            animator.SetBool("contactoSuelo", false);
        }
        saltar = false;
    }
}
