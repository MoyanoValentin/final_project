using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMonitorBehaviour : MonoBehaviour{
    //Objeto vacio- metodo que calcula (con un if)cuando todos los objetos con el Tag Win han desaparecido y cambia de de escena a Victoria, tambien imprime en consola comiste el punto ganador
    // Necesaria la libreria SceneManagement para poder controlar escenas.
    void Update(){
        /*if (!GameObject.FindGameObjectWithTag("Win")){
            print("Comiste el punto Ganador");
                SceneManager.LoadScene(3);
        }*/

        //Tambien comprueba si el objeto con el tag Player desaparecio y cambia de escena y imprime en consola un Perdiste.

        if (!GameObject.FindGameObjectWithTag("Player")){
            print("Perdiste :c");
            SceneManager.LoadScene(4);
        }
    }
}