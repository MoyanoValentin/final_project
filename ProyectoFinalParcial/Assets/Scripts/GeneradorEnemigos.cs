using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneradorEnemigos : MonoBehaviour{
    [SerializeField]
    private GameObject enemigo;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private int tipoGenerador;
    private int cont=0;
    public AudioClip sonidoExplosion;

    void Start(){
        switch(tipoGenerador){
        case 1:{
            InvokeRepeating("GenerarEnemigo",0,10);
            break;
        }
        case 2:{
            InvokeRepeating("GenerarEnemigo",0,1);
            break;
        }
      }    
    }

    public void GenerarEnemigo(){
        if(gameObject.activeSelf){
            switch(tipoGenerador){
                case 1:{
                    Instantiate(enemigo,transform.position,transform.rotation);
                    break;
                }
                case 2:{
                    if(cont<3){
                        Instantiate(enemigo,transform.position,transform.rotation);
                        cont++;
                    }
                    break;
                }
            }
        }
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("bala") || other.gameObject.CompareTag("NPCShield")){
            gameObject.SetActive(false);
            Instantiate(explosion,transform.position,transform.rotation);
            AudioSource.PlayClipAtPoint(sonidoExplosion, gameObject.transform.position);
        }
    }
}

