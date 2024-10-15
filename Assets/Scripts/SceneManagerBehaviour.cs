using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour{
    //Metodo de cambio de Escena asignado a un boton 
    public void Restart(){
        SceneManager.LoadScene(0); //vuelve al Menú Principal
    }
}