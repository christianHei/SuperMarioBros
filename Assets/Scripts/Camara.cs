using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    //Objetro a seguir en el eje X
    public GameObject mario;
    private Vector3 posicionRelativa;
    // Start is called before the first frame update
    void Start()
    {
        posicionRelativa = transform.position - mario.transform.position;
        transform.position = new Vector3(-7, 0, -10);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Sse actualiza la posición  en el eje x
        transform.position = mario.transform.position + posicionRelativa;
        transform.position = new Vector3(transform.position.x, 0 , -10);
    }
}
