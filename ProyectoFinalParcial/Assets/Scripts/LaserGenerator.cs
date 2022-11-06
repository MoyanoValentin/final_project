using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGenerator : MonoBehaviour{
    [SerializeField]
    private GameObject laser;
    public AudioSource controlSonido;
    public AudioClip sonidoLaser;

    void Start(){
        InvokeRepeating("GenerarLaser",4,4);
       
    }

    public void GenerarLaser(){
        Instantiate(laser,transform.position,transform.rotation);
        controlSonido.PlayOneShot(sonidoLaser);
    }
}