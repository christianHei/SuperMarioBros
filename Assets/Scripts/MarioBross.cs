using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * Controlador de Mario
 * */
public class MarioBross : MonoBehaviour
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
    public bool contactoSuelo;
    public bool muerto;
    public bool win;

    //Animaciones
    Animator animator;

    //Botón Start
    private GameObject button;

    //
    public GameObject Bowser;
    public Transform disparo;
    public bool disparar;

    void Start()
    {
        button = GameObject.Find("Start");
        button.SetActive(false);
        muerto = false;
        win = false;
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

        if (disparar)
        {
            //Disparo
            Instantiate(disparo, new Vector3(transform.position.x, -2.25f, 0), Quaternion.identity);
        }
        disparar = false;
        saltar = false;
    }

    //Detectar colisiones contra los tags
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goomba" && contactoSuelo)
        {
            //si Mario colisiona con Goomba, muere y cae.
            animator.SetBool("morir", true);
            GetComponent<CircleCollider2D>().isTrigger = true;
            muerto = true;
            GameOver();
        }

        if (collision.gameObject.tag == "Spiny" || collision.gameObject.tag == "Caer" 
            || collision.gameObject.tag == "Lava" || collision.gameObject.tag == "Bomba"
            || collision.gameObject.tag == "Bowser" || collision.gameObject.tag == "Fuego")
        {
            //si Mario colisiona con Spiny, muere y cae.
            animator.SetBool("morir", true);
            GetComponent<CircleCollider2D>().isTrigger = true;
            muerto = true;
            GameOver();
        }

        if (collision.gameObject.tag == "Puerta")
        {
            //Si Mario toca la Puerta
            GameWin();
        }

        if (collision.gameObject.tag == "Final")
        {
            Bowser.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            GameWinFinal();
        }
    }

    private void GameOver()
    {
        //Play sonido
        Sonido.sonido.PlayMuere();
        Sonido.sonido.audioFondo.Stop();
        //Detiene el juego y muestra el Botón de Reiniciar con un mensaje GAME OVER
        velX = 0;
        GameObject.Find("Mensaje").GetComponent<Text>().text = "GAME OVER";
        GameObject.Find("Mensaje").GetComponent<Text>().color = new Color(1f, 0, 0);
        button.SetActive(true);
        win = false;
    }

    private void GameWin()
    {
        //Play sonido
        Sonido.sonido.audioFondo.Stop();
        Sonido.sonido.PlayFinal();
        //Detiene el juego y muestra el Botón de Reiniciar con un mensaje MARIO WIN
        velX = 0;
        GameObject.Find("Mensaje").GetComponent<Text>().text = "MARIO WIN";
        GameObject.Find("Mensaje").GetComponent<Text>().color = new Color(0, 1f, 0);
        win = true;
        Constantes.NIVEL = 2;
        //luego de 4 segundos cargo el siguiente nivel
        StartCoroutine(Nextlevel(5));
    }

    private void GameWinFinal()
    {
        //Play sonido
        Sonido.sonido.audioFondo.Stop();
        Sonido.sonido.PlayFinal();
        //Detiene el juego y muestra el Botón de Reiniciar con un mensaje MARIO WIN
        velX = 0;
        GameObject.Find("Mensaje").GetComponent<Text>().text = "CONGRATULATION!!! MARIO";
        GameObject.Find("Mensaje").GetComponent<Text>().color = new Color(0, 1f, 0);
        button.SetActive(true);
        win = true;
        Constantes.NIVEL = 1;
    }

    /**
     * Next level
     **/
    IEnumerator Nextlevel(int valor)
    {
        //espera por una nueva intrucción durante el tiempo establecido en el parámetro valor
        yield return new WaitForSeconds(valor);
        SceneManager.LoadScene("Level2");

    }
}
