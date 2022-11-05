using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour{
    private GameObject player;
    [SerializeField]private GameObject explosion;
    private NavMeshAgent agente;
    private Transform objetivo;
    private Animator animador;

   
    public AudioSource controlSonido;
    
    public AudioClip sonidoExplosion;

    void Start(){
        player=GameObject.FindGameObjectWithTag("Player");
        objetivo=player.GetComponent<Transform>();
        agente=GetComponent<NavMeshAgent>();
        animador=GetComponent<Animator>();
    }

    void Update(){
        agente.destination=objetivo.position;
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
        Vector3 direction=objetivo.position-transform.position;
        Quaternion playerDirection=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=playerDirection;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("bala")){
            Instantiate(explosion,transform.position,transform.rotation);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(sonidoExplosion, gameObject.transform.position);
        }
        if(other.gameObject.CompareTag("Player")){
            Destroy(player);
        }
    }
}