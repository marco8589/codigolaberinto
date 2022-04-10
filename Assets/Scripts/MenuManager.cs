using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   
    //empezar juego
    public void Botonempezar()
    { 
        SceneManager.LoadScene("Principal");
    }

    //salir del juego
    public void Botonsalir()
    {
        Application.Quit();
    }

 


}
