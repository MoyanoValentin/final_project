using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour{
    void Start(){
        Destroy(gameObject,4);
    }
}
