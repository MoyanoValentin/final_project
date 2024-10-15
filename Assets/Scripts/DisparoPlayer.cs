using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayer : MonoBehaviour{
    [SerializeField]
    private GameObject playerBall;
    [SerializeField]
    private GameObject otherPlayerBall;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;

    public AudioSource controlSonido;
    public AudioClip sonidoDisparo;

    void Update(){
        if (Input.GetButtonDown("Fire1")){ //detecta la presión del Clic Izquierdo
            if (Time.time>shotRateTime){ 
                GameObject newPlayerBall;
                newPlayerBall= Instantiate(playerBall,transform.position, transform.rotation); //instancia una bala
                shotRateTime = Time.time + shotRate; //limita la cadencia de disparo
                Destroy(newPlayerBall, 2); //hace que la bala dure 2 segundos
                controlSonido.PlayOneShot(sonidoDisparo);
            }
        }
        if (Input.GetButtonDown("Fire2")){
            if (Time.time>shotRateTime){
                GameObject otherplayerBall;
                GameObject newPlayerBall;
                newPlayerBall = Instantiate(playerBall, transform.position + new Vector3(-1f, 0f, 0f), transform.rotation);
                otherplayerBall = Instantiate(otherPlayerBall, transform.position + new Vector3(1f,0f,0f), transform.rotation);
                shotRateTime = Time.time + shotRate;
                Destroy(newPlayerBall, 2);
                Destroy(otherplayerBall, 2);
                controlSonido.PlayOneShot(sonidoDisparo);
            }
        }
    }
}
