using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserBehaviour : MonoBehaviour{
    void Start(){
        Destroy(gameObject,2);
    }

    void OnTriggerEnter(Collider other){
        print("Perdiste :c");
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
        SceneManager.LoadScene(4);
    }
}