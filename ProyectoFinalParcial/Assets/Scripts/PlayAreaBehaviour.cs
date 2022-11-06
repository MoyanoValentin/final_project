using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAreaBehaviour : MonoBehaviour{
    private GameObject player;
    private float rotationSpeed=2;

    void Start(){
        player=GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        transform.Rotate(new Vector3(0,1,0)*rotationSpeed*Time.deltaTime);
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            print("Perdiste :c");
            Cursor.lockState=CursorLockMode.None;
            Cursor.visible=true;
            SceneManager.LoadScene(4);
        }
    }
}
