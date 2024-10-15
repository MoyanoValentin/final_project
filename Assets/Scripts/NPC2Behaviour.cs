using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC2Behaviour : MonoBehaviour{
    public bool isInNpc=false;
    [SerializeField] public int npcType;
    public PlayerBehaviour player;
    public SalmonBehaviour salmon;

    void Start(){
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        salmon=GameObject.FindGameObjectWithTag("Salmon").GetComponent<SalmonBehaviour>();
    }

    void OnTriggerEnter(Collider other){
        isInNpc=true; //se activa cuando está dentro de l acolisión del NPC
        if(player.hasSalmon>=10){
            //de acuerdo al Tipo del NPC, muestra el siguiente nivel o la pantalla de Victoria
            switch(npcType){
                case 1:{
                    SceneManager.LoadScene(2);
                    break;
                }
                case 2:{
                    Cursor.lockState=CursorLockMode.None;
                    Cursor.visible=true;
                    SceneManager.LoadScene(3);
                    break;
                }
            }
        }
    }

    void OnTriggerExit(Collider other){
        isInNpc=false; //se desactiva cuando está fuera  de la colisión del NPC
        if(player.hasSalmon>=10){ //desactiva la colisión al entregar 10 salmones
            gameObject.GetComponent<BoxCollider>().enabled=false;
        }
    }
}