using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour{
    public PlayerBehaviour player;

    void Start(){
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        Destroy(gameObject,2);
    }

    void OnTriggerEnter(Collider other){
        player.isLive=false;
    }
}