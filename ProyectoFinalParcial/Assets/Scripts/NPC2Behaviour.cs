using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Behaviour : MonoBehaviour{
    public bool isInNpc=false;
    public PlayerBehaviour player;
    public SalmonBehaviour salmon;

    void Start(){
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        salmon=GameObject.FindGameObjectWithTag("Salmon").GetComponent<SalmonBehaviour>();
    }

    void OnTriggerEnter(Collider other){
        isInNpc=true;
        if(player.hasSalmon>=10){
            player.isLive=false;
        }
    }

    void OnTriggerExit(Collider other){
        isInNpc=false;
        if(player.hasSalmon>=10){
            gameObject.GetComponent<BoxCollider>().enabled=false;
        }
    }
}