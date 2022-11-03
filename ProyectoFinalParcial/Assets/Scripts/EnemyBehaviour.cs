using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour{
    private GameObject player;
    private NavMeshAgent agente;
    private Transform objetivo;
    private Animator animador;

    void Start(){
        player=GameObject.FindGameObjectWithTag("Player");
        objetivo=player.GetComponent<Transform>();
        agente=GetComponent<NavMeshAgent>();
        animador=GetComponent<Animator>();
    }

    void Update(){
        MoverEnemigo();
    }

    void MoverEnemigo(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,15) && hit.transform.tag=="Player"){
            animador.SetBool("Walk_Anim", false);
            animador.SetBool("Roll_Anim", true);
        }else{
            animador.SetBool("Roll_Anim", false);
            animador.SetBool("Walk_Anim", true);
        }
        agente.destination=objetivo.position;
        Vector3 direction=objetivo.position-transform.position;
        Quaternion playerDirection=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=playerDirection;
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("bala")){
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Player")){
            Destroy(player);
        }
    }
}