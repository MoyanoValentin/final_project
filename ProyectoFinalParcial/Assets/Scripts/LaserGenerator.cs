using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGenerator : MonoBehaviour{
    [SerializeField] private GameObject laser;
    public AudioSource controlSonido;
    public AudioClip sonidoLaser;

    void Start(){
        InvokeRepeating("GenerarLaser",4,4); //llama al método cada 4 segundos
    }

    public void GenerarLaser(){
        Instantiate(laser,transform.position,transform.rotation); //crea un láser en su posición
        controlSonido.PlayOneShot(sonidoLaser);
    }
}