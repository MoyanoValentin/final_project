using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
        agente=GetComponent<NavMeshAgent>(); //obtiene los valores del NavMesh (Enemigo)
        animador=GetComponent<Animator>();
    }

    void Update(){
        MoverEnemigo();
    }

    void MoverEnemigo(){
        agente.destination=objetivo.position; //dirige al enemigo hacia el jugador a través de NavMesh
        RaycastHit hit; //crea una variable para almacenar la información de la colisión
        if(Physics.Raycast(transform.position,transform.forward,out hit,15) && hit.transform.tag=="Player"){ //detecta si el rayo tocaa al jugador
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
        if(other.gameObject.CompareTag("bala") || other.gameObject.CompareTag("NPCShield")){ //si entra en contacto con una bala o el campo de fuerza del NPC, se destruye
            Instantiate(explosion,transform.position,transform.rotation);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(sonidoExplosion, gameObject.transform.position);
        }
        if(other.gameObject.CompareTag("Player")){ //si toca al jugador, carga la pantalla de Fín del Juego
            print("Perdiste :c");
            Cursor.lockState=CursorLockMode.None; //desbloquea la posición del cursor
            Cursor.visible=true; //vuelve a mostrar el cursor
            SceneManager.LoadScene(4); //carga escena de derrota
        }
    }
}