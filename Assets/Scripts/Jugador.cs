using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{

    public static int puntaje = 0;
    public float velocidad = 5.0f;
    public Text puntajemonedas;
    public Text ganaste;
    // Start is called before the first frame update
    void Start()
    {
        puntajemonedas.text = "Monedas: 0";
        ganaste.text = "";
        puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Principal");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("prueba hola mundo");
            transform.Translate(-velocidad * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("prueba hola mundo");
            transform.Translate(velocidad * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("prueba hola mundo");
            transform.Translate(0, velocidad * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("prueba hola mundo");
            transform.Translate(0, -velocidad * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigos")
        {
            SceneManager.LoadScene("Principal");
        }        
        if (collision.gameObject.tag == "Monedas")
        {
            Destroy(collision.gameObject);
            puntaje++;
            puntajemonedas.text = "Monedas: " + puntaje;
            if (puntaje == 5)
            {
                ganaste.text = "Ganaste! \n Click para reiniciar";
            }
        }
        if (collision.gameObject.tag == "Paredes")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Debug.Log("prueba hola mundo");
                transform.Translate(velocidad * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("prueba hola mundo");
                transform.Translate(-velocidad * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("prueba hola mundo");
                transform.Translate(0, -velocidad * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Debug.Log("prueba hola mundo");
                transform.Translate(0, velocidad * Time.deltaTime, 0);
            }
        }
    }



}

internal class Public
{
}