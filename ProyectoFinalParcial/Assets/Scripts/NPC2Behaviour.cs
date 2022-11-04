using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC2Behaviour : MonoBehaviour{
    public bool isInNpc=false;
    [SerializeField]public int npcType;
    public PlayerBehaviour player;
    public SalmonBehaviour salmon;

    void Start(){
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        salmon=GameObject.FindGameObjectWithTag("Salmon").GetComponent<SalmonBehaviour>();
    }

    void OnTriggerEnter(Collider other){
        isInNpc=true;
        if(player.hasSalmon>=10){
            switch(npcType){
                case 1:{
                    SceneManager.LoadScene(2);
                    break;
                }
                case 2:{
                    SceneManager.LoadScene(3);
                    break;
                }
            }
        }
    }

    void OnTriggerExit(Collider other){
        isInNpc=false;
        if(player.hasSalmon>=10){
            gameObject.GetComponent<BoxCollider>().enabled=false;
        }
    }
}