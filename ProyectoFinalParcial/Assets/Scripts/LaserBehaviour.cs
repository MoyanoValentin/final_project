using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserBehaviour : MonoBehaviour{
    void Start(){
        Destroy(gameObject,2); //se autodestruye en 2 segundos
    }

    void OnTriggerEnter(Collider other){ //al tocar al jugador, muestra la pantalla de Fín del Juego
        print("Perdiste :c");
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
        SceneManager.LoadScene(4);
    }
}