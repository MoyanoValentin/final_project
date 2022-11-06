using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour{
    [SerializeField] private GameObject door;
    public bool isInNpc=false;
    public PlayerBehaviour player;
    public SalmonBehaviour salmon;

    void Start(){
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        salmon=GameObject.FindGameObjectWithTag("Salmon").GetComponent<SalmonBehaviour>();
    }

    void OnTriggerEnter(Collider other){
        isInNpc=true;
        if(player.hasSalmon>=10){ //al recibir 10 salmones, destruye la puerta
            Destroy(door);
        }
    }

    void OnTriggerExit(Collider other){
        isInNpc=false;
        if(player.hasSalmon>=10){ //al recibir 10 salmones desactiva su colisión
            player.hasSalmon=0;
            gameObject.GetComponent<BoxCollider>().enabled=false;
        }
    }
}