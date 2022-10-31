using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGenerator : MonoBehaviour{
    [SerializeField]
    private GameObject laser;

    void Start(){
        InvokeRepeating("GenerarLaser",4,8);
    }

    public void GenerarLaser(){
        Instantiate(laser,transform.position,transform.rotation);
    }
}