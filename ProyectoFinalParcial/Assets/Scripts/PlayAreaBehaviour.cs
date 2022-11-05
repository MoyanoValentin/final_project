using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaBehaviour : MonoBehaviour{
    private GameObject player;

    void Start(){
        player=GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            Destroy(player);
        }
    }
}
