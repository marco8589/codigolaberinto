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
    public int nivel;
    bool victoria = false;
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
            switch (nivel)
            {
                case 1:
                    if (victoria==true)
                    {
                        SceneManager.LoadScene("Segundo nivel");
                    }
                    else
                    {
                        SceneManager.LoadScene("Primer nivel");
                    }
                    break;
                case 2:
                    if (victoria == true)
                    {
                        SceneManager.LoadScene("Primer nivel");
                    }
                    else
                    {
                        SceneManager.LoadScene("Segundo nivel");
                    }
                    break;
            }

          
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
            switch (nivel)
            {
                case 1:
                    SceneManager.LoadScene("Primer nivel");
                    break;
                case 2:
                    SceneManager.LoadScene("Segundo nivel");
                    break;
            }
          //  SceneManager.LoadScene("Principal");
        }        
        if (collision.gameObject.tag == "Monedas")
        {
            Destroy(collision.gameObject);
            puntaje++;
            puntajemonedas.text = "Monedas: " + puntaje;

            switch (nivel)
            {
                case 1:
                    if (puntaje == 4)
                    {
                        ganaste.text = "Ganaste El Primer Nivel!!! \n Click Para Ir Al Siguiente Nivel";
                        victoria = true;
                     
                    }
                    break;
                case 2:
                    if (puntaje == 5)
                    {
                        ganaste.text = "Ganaste! \n Click para reiniciar";
                        victoria = true;
                    }
                    break;
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