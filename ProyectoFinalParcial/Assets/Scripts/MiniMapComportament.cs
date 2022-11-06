using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapComportament : MonoBehaviour{
    public Transform player;

    private void LateUpdate(){
        //toma de referencia la posición del jugador para mover la cámara
        transform.position=new Vector3(player.position.x, transform.position.y, player.position.z);
    }
}